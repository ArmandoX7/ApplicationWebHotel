using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AplicacionWebHotel.Modelo;
using AplicacionWebHotel.Controlador;

namespace AplicacionWebHotel.Vista.Gerente
{
    public partial class FrmConsultarHabitacionesAlquiladasPorRango : System.Web.UI.Page
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
    }
}