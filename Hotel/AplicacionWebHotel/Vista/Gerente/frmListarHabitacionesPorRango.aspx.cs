using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AplicacionWebHotel.Modelo;
using AplicacionWebHotel.Controlador;
using System.IO;

namespace AplicacionWebHotel.Vista.Gerente
{
    public partial class frmListarHabitacionesPorRango : System.Web.UI.Page
    {
        ControllerAlquiler objControlerAlquiler = new ControllerAlquiler();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicial = Convert.ToDateTime(txtFechaInicial.Text);
            DateTime fechaFinal = Convert.ToDateTime(txtFechaFinal.Text);
            tablaHabitaciones.DataSource = objControlerAlquiler.listarHabitacionesPorRangoDeFecha(fechaInicial, fechaFinal);
            tablaHabitaciones.DataBind();
        }

        protected void imgExportarCsv_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                String rutaArchivo = Server.MapPath("../../IngresosHabitacionesRangoFechas.csv");
                //creamos un archivo de streamwriter que es creado en una carpeta del servidor
                StreamWriter sw = new StreamWriter(rutaArchivo, false, System.Text.Encoding.UTF8);
                //agregar datos al archivo
                sw.WriteLine("Habitacion;Cliente;Fecha de Ingreso;Fecha de Salida; Días Servicio;Costo Noche; Costo Total");
                int registros = tablaHabitaciones.Rows.Count;
                for (int i = 0; i < registros; i++)
                {
                    sw.WriteLine(tablaHabitaciones.Rows[i].Cells[0].Text + ";" +
                        tablaHabitaciones.Rows[i].Cells[1].Text + ";" + Convert.ToDateTime(tablaHabitaciones.Rows[i].Cells[2].Text).ToShortDateString() + ";" +
                        Convert.ToDateTime(tablaHabitaciones.Rows[i].Cells[3].Text).ToShortDateString() + ";" + tablaHabitaciones.Rows[i].Cells[4].Text + ";" +
                        tablaHabitaciones.Rows[i].Cells[5].Text + ";" + tablaHabitaciones.Rows[i].Cells[6].Text);
                }
                //cerrar el archivo
                sw.Close();
                //Proceso para que pueda ser descargado en el cliente
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=IngresosHabitacionesRangoFechas_" + 
                    txtFechaInicial.Text + "-" + txtFechaFinal.Text + ".csv");
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
                ClientScript.RegisterClientScriptBlock(this.GetType(), "CSV", "alert('Error al exportar el fichero')", true);
            }
        }
    }
}