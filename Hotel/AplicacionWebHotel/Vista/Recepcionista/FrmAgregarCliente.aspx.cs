using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AplicacionWebHotel.Modelo;
using AplicacionWebHotel.Controlador;

namespace AplicacionWebHotel.Vista.Recepcionista
{
    public partial class FrmAgregarCliente : System.Web.UI.Page
    {
        ControllerCliente objControlerCliente = new ControllerCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idEmpleado"] == null)
            {
                Response.Redirect("../frmIniciarSesion.aspx?x=1");
            }
        }

        private void limpiar()
        {
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string identificacion = txtIdentificacion.Text;
            string correo = txtCorreo.Text;
            Cliente unCliente = new Cliente(identificacion, nombre, correo);
            bool agregado = objControlerCliente.agregarCliente(unCliente);
            if (agregado)
            {
                lblMensaje.Text = "Cliente Agregado Correctamente";
                limpiar();
            }
            else
            {
                lblMensaje.Text = "Problemas al agregar " + objControlerCliente.Error;
            }
        }
    }
}