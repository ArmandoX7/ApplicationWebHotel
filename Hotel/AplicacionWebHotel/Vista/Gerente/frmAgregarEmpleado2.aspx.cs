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
    public partial class frmAgregarEmpleado2 : System.Web.UI.Page
    {
        ControllerEmpleado controlerEmpleado = new ControllerEmpleado();
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
            txtCorreo.Text = "";
            txtNombre.Text = "";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            String ruta = Server.MapPath("../Fotos/");
            Empleado unEmpleado = new Empleado();
            unEmpleado.Identificacion = txtIdentificacion.Text;
            unEmpleado.Nombre = txtNombre.Text;
            unEmpleado.Cargo = cbCargo.SelectedValue;
            unEmpleado.Correo = txtCorreo.Text;
            bool agregado = controlerEmpleado.agregarEmpleado(unEmpleado);
            if (agregado)
            {
                //envío de correo con usuario y contraseña de ingreso
                string remitente = "ccuellar@misena.edu.co";
                string asunto = "Registro Aplicación web del Hotel SENA";
                string mensaje = "<br>Cordial saludo, " + unEmpleado.Nombre + " me permito informarle que usted ha sido " +
                    " registrado en la aplicación web del hotel con las siguientes credenciales: <br><br> " +
                    "<b>Usuario:</b> " + unEmpleado.Identificacion + "<br>" +
                    "<b>Contraseña:</b> " + unEmpleado.Identificacion + "<br>" +
                    "<br> Para el ingreso<a href='http://localhost:54880/AplicacacionWebHotel/'>" +
                    "http://localhost:54880/AplicacacionWebHotel/</a> <br><br><br> Atentamente, Administrador";
                Correo correo = new Correo(unEmpleado.Correo, remitente, asunto, mensaje);
                try
                {
                    bool correoEnviado = correo.envioCorreo();
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Problemas envío de correo " + ex.Message + " " + correo.error;
                }
                //subir foto
                if (fileFoto.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(fileFoto.FileName).ToLower();
                    if (extension == ".jpg")
                    {
                        try
                        {
                            fileFoto.PostedFile.SaveAs(ruta + txtIdentificacion.Text + extension);
                            lblMensaje.Text = "Persona Agregada Correctamente incluyendo su Foto";
                        }
                        catch (Exception ex)
                        {
                            lblMensaje.Text = lblMensaje.Text + " No se puedo cargar la foto " + ex.Message;
                        }
                    }
                    else
                    { lblMensaje.Text = lblMensaje.Text + " Persona Agregada Correctamente sin foto"; }
                }
                limpiar();
            }
            else
                lblMensaje.Text = controlerEmpleado.Error;


        }
    }
}