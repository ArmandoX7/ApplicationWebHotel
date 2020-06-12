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
    public partial class frmActualizarDescripcion : System.Web.UI.Page
    {
        ControllerHabitacion objControlerHabitacion = new ControllerHabitacion();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            int numero = Convert.ToInt32(txtNHabita.Text);
            string descripcion = txtDHabita.Text;
            Habitacion unaHabitacion = new Habitacion();
            unaHabitacion.Numero = Convert.ToInt32(txtNHabita.Text);
            unaHabitacion.Descripcion = txtDHabita.Text;
            bool actualizado = objControlerHabitacion.actualizarDescripcion(numero, descripcion);
            if (actualizado)
            {
                lblMensaje.Text = "Se ha actualizado la descripción a la Habitación";
                txtNHabita.Text="";
                txtDHabita.Text = "";
            }
            else
            {
                lblMensaje.Text = "No se pudo actualizar la Habitación " + objControlerHabitacion.Error;
            }
        }
    }
}