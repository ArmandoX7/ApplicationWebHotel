using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;
using System.IO;
using itextsharp.pdfa;
using AplicacionWebHotel.Modelo;
using AplicacionWebHotel.Controlador;

namespace AplicacionWebHotel.Vista.Recepcionista
{
    public partial class frmListarAlquiladas : System.Web.UI.Page
    {
        ControllerAlquiler objControlerAlquiler = new ControllerAlquiler();
        static Document pdf;
        protected void Page_Load(object sender, EventArgs e)
        {
            tablaAlquiladas.DataSource = objControlerAlquiler.obtenerAlquiladas();
            tablaAlquiladas.DataBind();
        }

        protected void imgExportarPdf_Click(object sender, ImageClickEventArgs e)
        {
            String ruta = Server.MapPath("../../Recursos/Prueba.pdf");
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            this.Page.RenderControl(htw);
            StringReader sr = new StringReader(sw.ToString());
            pdf = new Document(PageSize.LETTER);
            HTMLWorker hw = new HTMLWorker(pdf);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdf, Response.OutputStream);
            pdf.Open();
            hw.Parse(sr);
            pdf.Close();
            Response.Write(pdf);
            Response.End();
        }

        private void crearTablaPdf()
        {
            pdf = new Document(PageSize.LETTER);
            string ruta = Server.MapPath(@"archivo.pdf");
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            FileStream file = new FileStream(ruta, FileMode.Create);            
            PdfWriter.GetInstance(pdf, Response.OutputStream);
            pdf.Open();
            pdf.AddAuthor("César Cuéllar");
            pdf.AddCreationDate();
            pdf.AddTitle("Ejemplo Creación Pdf dese C#");
            pdf.Add(new Paragraph("                  LISTA DE HABITACIONES ALQUILADAS"));
            pdf.Add(new Paragraph(" "));
        
            PdfPTable tabla = new PdfPTable(3);
            tabla.AddCell("Habitación");
            tabla.AddCell("Cliente");
            tabla.AddCell("Fecha de Ingreso");
           
            int registros = tablaAlquiladas.Rows.Count;
            for (int i = 0; i < registros; i++)
            {
                tabla.AddCell(tablaAlquiladas.Rows[i].Cells[0].Text);
                tabla.AddCell(tablaAlquiladas.Rows[i].Cells[1].Text);
                tabla.AddCell(tablaAlquiladas.Rows[i].Cells[2].Text);
            }
            pdf.Add(tabla);
            pdf.Close();
            Response.Write(pdf);
            Response.End();
        }
        protected void btnExportar_Click(object sender, EventArgs e)
        {
            crearTablaPdf();
           /* StringReader sr = new StringReader(Request.Form[grillaOculta.UniqueID]);
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=HTML.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();*/
        }

        protected void imgExportarCsv_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                String rutaArchivo = Server.MapPath("../../HabitacionesAlquiladas.csv");
                //creamos un archivo de streamwriter que es creado en una carpeta del servidor
                StreamWriter sw = new StreamWriter(rutaArchivo, false, System.Text.Encoding.UTF8);
                //agregar datos al archivo
                sw.WriteLine("Habitacion;Cliente;Fecha de Ingreso");
                int registros = tablaAlquiladas.Rows.Count;
                for (int i = 0; i < registros; i++)
                {
                    sw.WriteLine(tablaAlquiladas.Rows[i].Cells[0].Text + ";" +
                        tablaAlquiladas.Rows[i].Cells[1].Text + ";" +
                        tablaAlquiladas.Rows[i].Cells[2].Text);
                }
                //cerrar el archivo
                sw.Close();
                //Proceso para que pueda ser descargado en el cliente
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=habitacionesAlquiladas.csv");
                Response.ContentType = "application/vnd.csv";
                Response.Charset = "UTF-8";
                Response.ContentEncoding = System.Text.Encoding.UTF8;

                //Cargamos el archivo en memoria ...
                byte[] misDatos = (byte[])File.ReadAllBytes(rutaArchivo);
                Response.BinaryWrite(misDatos);

                //Eliminamos el archivo creado en el servidor
                File.Delete(rutaArchivo);

                //Terminamos el response ..
                Response.End();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock (this.GetType(), "CSV", "alert('Error al exportar el fichero')", true);
            }
        }

        

    }
}