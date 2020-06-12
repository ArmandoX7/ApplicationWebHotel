using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AplicacionWebHotel.Controlador;
using AplicacionWebHotel.Modelo;

namespace AplicacionWebHotel.Vista.Recepcionista
{
    public partial class frmAgregarAlquiler : System.Web.UI.Page
    {
        ControllerHabitacion objControlerHabitacion = new ControllerHabitacion();
        ControllerCliente objControlerCliente = new ControllerCliente();
        ControllerAlquiler objControlerAlquiler = new ControllerAlquiler();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idEmpleado"] == null)
            {
                Response.Redirect("../frmIniciarSesion.aspx?x=1");
            }
            
            if (IsPostBack == false)
            {
                List<TipoHabitacion> tipos = objControlerHabitacion.listarTiposHabitacion();
                cbTipo.DataSource = tipos;
                cbTipo.DataTextField = "Nombre";
                cbTipo.DataValueField = "idTipoHabitacion";
                cbTipo.DataBind();

                List<Habitacion> habitaciones = objControlerHabitacion.listaDisponibles();
                cbHabitacion.DataSource = habitaciones;
                cbHabitacion.DataTextField = "Numero";
                cbHabitacion.DataValueField = "IdHabitacion";
                cbHabitacion.DataBind();
            }
        }

        private void limpiar()
        {
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtIdCliente.Value = "";
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int idUsuario = 1; //aquí lo asignamos estáticamente                       
            Alquiler unAlquiler = new Alquiler();
            unAlquiler.unCliente.IdCliente = Convert.ToInt32(txtIdCliente.Value);
            unAlquiler.unaHabitacion.IdHabitacion = Convert.ToInt32(cbHabitacion.SelectedValue);
            unAlquiler.fechaAlquiler = DateTime.Now.Date;
            unAlquiler.fechaSalida = DateTime.Now.Date;
            unAlquiler.estado = "Registrado";
            unAlquiler.costo = 0;
            unAlquiler.idUsuario = idUsuario;
            unAlquiler.observaciones = "";
            bool alquilado = objControlerAlquiler.alquilarHabitacion(unAlquiler);
            if (alquilado)
            {
                lblMensaje.Text = "Alquiler registrado";
                limpiar();
            }
            else
            {
                lblMensaje.Text = "Problemas alquilar habitacion " + objControlerAlquiler.Error;
            }
        }

    }
}