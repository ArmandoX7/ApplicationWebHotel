using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AplicacionWebHotel.Modelo;
using AplicacionWebHotel.Controlador;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;
using System.IO;
using itextsharp.pdfa;

namespace AplicacionWebHotel.Vista.Recepcionista
{
    public partial class frmEntregarHabitacion : System.Web.UI.Page
    {
        ControllerAlquiler objControlerAlquiler = new ControllerAlquiler();
        ControllerHabitacion objControlerHabitacion = new ControllerHabitacion();
        static Alquiler unAlquiler = null;
        static Document pdf;
        static int costoNoche;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void limpiar()
        {
           
            txtCosto.Text = "";
            txtDias.Text = "";
            txtFechaIngreso.Text = "";
            txtFechaSalida.Text = "";
            txtNombre.Text = "";
            txtObservaciones.Text = "";
        }
        protected void imgConsultarAlquiler_Click(object sender, ImageClickEventArgs e)
        {
            lblMensaje.Text = "";
            limpiar();
            if (txtHabitacion.Text != "")
            {
                int numeroHabitacion = Convert.ToInt32(txtHabitacion.Text);
                costoNoche = objControlerHabitacion.obtenerCostoHabitacionPorNumero(numeroHabitacion);
                unAlquiler = objControlerAlquiler.obtenerAlquilerPorhabitacion(numeroHabitacion);
                if (unAlquiler != null)
                {
                    txtFechaIngreso.Text = unAlquiler.fechaAlquiler.ToShortDateString();
                    txtFechaSalida.Text = DateTime.Now.Date.ToShortDateString();
                    txtNombre.Text = unAlquiler.unCliente.Nombre;
                    TimeSpan interval = DateTime.Now.Date - unAlquiler.fechaAlquiler;
                    txtDias.Text = interval.Days.ToString();
                    txtCosto.Text = (costoNoche * interval.Days).ToString();                  
                }
                else
                {
                    lblMensaje.Text = "Habitación no alquilada o no existe. Verifique";
                }
            }
            else
            {
                lblMensaje.Text = "Debe ingresar Número de habitación. ";
            }

        }

        protected void btnEntregar_Click(object sender, EventArgs e)
        {
            unAlquiler.fechaSalida = Convert.ToDateTime(txtFechaSalida.Text);
            unAlquiler.costo = Convert.ToInt32(txtCosto.Text);
            unAlquiler.estado = "Entregada";
            unAlquiler.observaciones = txtObservaciones.Text;
            bool entregado = objControlerAlquiler.entregarHabitacion(unAlquiler);
            if (entregado)
            {
                generarFactura();
                limpiar();
                txtHabitacion.Text = "";
                lblMensaje.Text = "Registrada la entrega de la Habitación";
               
            }
            else
            {
                lblMensaje.Text = "Problemas al registrar la entrega. " + objControlerAlquiler.Error;
            }
        }

        public void generarFactura()
        {
            pdf = new Document(PageSize.LETTER);
            string rutaImagen = Server.MapPath("../../Recursos/Imagenes/logo.jpg");
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Factura.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //FileStream file = new FileStream(ruta, FileMode.Create);
            PdfWriter.GetInstance(pdf, Response.OutputStream);
            pdf.Open();
            pdf.AddAuthor("César Cuéllar");
            pdf.AddCreationDate();
            pdf.AddTitle("FACTURA HOTEL SENA ADSI 1094253");
            // Creamos la imagen y le ajustamos el tamaño
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(rutaImagen);
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_LEFT;           
            float percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage*50);

            // Insertamos la imagen en el documento
            pdf.Add(imagen);
            Paragraph parrafo = new Paragraph("FACTURA HOTEL SENA ADSI 1094253");
            parrafo.Alignment = Element.ALIGN_CENTER;
            //agregar el titulo al documento
            pdf.Add(parrafo);
            pdf.Add(new Paragraph(" "));
            pdf.Add(new Paragraph(" "));
       
            //crear la tabla con los datos de la factura
            PdfPTable tabla = new PdfPTable(2);
            tabla.HorizontalAlignment = Element.ALIGN_CENTER;
            tabla.AddCell("Nombre Cliente:"); tabla.AddCell(unAlquiler.unCliente.Nombre);
            tabla.AddCell("Fecha:"); tabla.AddCell(DateTime.Now.Date.ToShortDateString());
            tabla.AddCell("Habitación:"); tabla.AddCell(txtHabitacion.Text);
            tabla.AddCell("Fecha de Ingreso:"); tabla.AddCell(unAlquiler.fechaAlquiler.ToShortDateString());
            tabla.AddCell("Fecha de Salida:"); tabla.AddCell(unAlquiler.fechaSalida.ToShortDateString());
            tabla.AddCell("Número de Días:"); tabla.AddCell(txtDias.Text);
            tabla.AddCell("Costo Noche:"); tabla.AddCell("$" + costoNoche.ToString());
            tabla.AddCell("Costo Total:"); tabla.AddCell(("$" + costoNoche * Convert.ToInt32(txtDias.Text)).ToString());
            //agrega la tabla al documento
            pdf.Add(tabla);
            //agrega varias líneas vacías
            pdf.Add(new Paragraph(" ")); pdf.Add(new Paragraph(" ")); pdf.Add(new Paragraph(" "));
            pdf.Add(new Paragraph(" ")); pdf.Add(new Paragraph(" ")); pdf.Add(new Paragraph(" "));
            rutaImagen = Server.MapPath("../../Recursos/Imagenes/firma.png");
            imagen = iTextSharp.text.Image.GetInstance(rutaImagen);
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_CENTER;
            percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage * 50);
            pdf.Add(imagen);
            parrafo = new Paragraph("________________________________");
            parrafo.Alignment = Element.ALIGN_CENTER;
            pdf.Add(parrafo);
            parrafo = new Paragraph("Gerente");
            parrafo.Alignment = Element.ALIGN_CENTER;            
            pdf.Add(parrafo);         
            pdf.Close();
            Response.Write(pdf);
            Response.End();
        }

       
    }
}