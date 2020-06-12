using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AplicacionWebHotel.Controlador;
using AplicacionWebHotel.Modelo;

namespace AplicacionWebHotel.Vista.Gerente
{
    public partial class frmAgregarHabitacion : System.Web.UI.Page
    {
        ControllerHabitacion objControlerHabitacion = new ControllerHabitacion();
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["idEmpleado"] == null)
            {
                Response.Redirect("../frmIniciarSesion.aspx?x=1");
            }

            if (IsPostBack == false)
            {
                List<TipoHabitacion> listaTipos = objControlerHabitacion.listarTiposHabitacion();
                cbTipo.DataSource = listaTipos;
                cbTipo.DataTextField = "Nombre";
                cbTipo.DataValueField = "IdTipoHabitacion";
                cbTipo.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Habitacion unaHabitacion = new Habitacion();
            int numero = int.Parse(txtNumero.Text);
            int piso = int.Parse(cbPiso.Text);
            string descripcion = txtDescripcion.Text;
            int tipo = Convert.ToInt32(cbTipo.SelectedValue);
            unaHabitacion.Numero = numero;
            unaHabitacion.Piso = piso;
            unaHabitacion.Descripcion = descripcion;
            unaHabitacion.Tipo.IdTipoHabitacion = tipo;
            unaHabitacion.Estado = "Disponible";
            bool agregada = objControlerHabitacion.agregarHabitacion(unaHabitacion);
            if (agregada)
            {
                lblMensaje.Text = "Habitación agregada";
                limpiar();
            }
            else
            {
                lblMensaje.Text = objControlerHabitacion.Error;
            }
        }

        private void limpiar()
        {
            txtNumero.Text = "";
            txtDescripcion.Text = "";
        }
    }
}