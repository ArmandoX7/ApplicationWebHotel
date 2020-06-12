using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AplicacionWebHotel.Modelo;
using AplicacionWebHotel.Controlador;

namespace AplicacionWebHotel.Vista
{
    public partial class frmIniciarSesion : System.Web.UI.Page
    {
        ControllerEmpleado objControlerEmpleado = new ControllerEmpleado();
        Empleado unEmpleado = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["x"] != null)
            {
                int valor = Convert.ToInt32(Request.QueryString["x"]);
                switch (valor)
                {
                    case 1: lblMensaje.Text = "Debe Iniciar primero con su usuario y contraseña";
                        break;
                    case 2: lblMensaje.Text = "Ha cerrado la sesión. Hasta pronto";
                        break;
                }              
            }
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            unEmpleado = objControlerEmpleado.iniciarSesion(txtUsuario.Text, txtPassword.Text);
            if (unEmpleado != null)
            {               
                switch (unEmpleado.Cargo)
                {
                    case "Gerente":
                        //aquí declaramos una variable de sesión
                        Session["idEmpleado"] = unEmpleado.IdEmpleado;
                        Response.Redirect("Gerente/default.aspx");
                        break;

                    case "Recepcionista":
                        //aquí declaramos una variable de sesión
                        Session["idEmpleado"] = unEmpleado.IdEmpleado;
                        Response.Redirect("Recepcionista/default.aspx");
                        break;
                }
            }
            else
            {
                lblMensaje.Text = "No Existe usuario con los datos ingresados. Revisar";
            }           
        }
    }
}