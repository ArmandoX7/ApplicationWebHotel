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
    public partial class frmContactenos : System.Web.UI.Page
    {
        private static Random aleatorio;
        private static int resultado = 0;
        ControllerContactenos objControlerContactenos = new ControllerContactenos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                generarAleatorio();         
            }
        }

        private void generarAleatorio()
        {
            aleatorio = new Random();
            int numero1 = aleatorio.Next(1, 100);
            int numero2 = aleatorio.Next(1, 100);
            resultado = numero1 + numero2;
            txtOperacion.Text = numero1 + "+" + numero2;             
        }

        private void limpiar()
        {
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtComentario.Text = "";
            txtResultado.Text = "";
            txtOperacion.Text = "";
        }

        protected void btnRegistrarComentario_Click(object sender, EventArgs e)
        {
            int resul = Convert.ToInt32(txtResultado.Text);
            if (resul == resultado)
            {
                Contactenos unContactenos = new Contactenos(txtNombre.Text,txtCorreo.Text, txtComentario.Text);
                bool agregado = objControlerContactenos.agregarComentario(unContactenos);
                if (agregado)
                {
                    lblMensaje.Text = "Se ha enviado su comentario a nuestro sistema";
                    limpiar();
                    generarAleatorio();
                }
                else{
                    lblMensaje.Text="Se ha producido un error en el envío de su comentario, vuelva a intentarlo";
                }
            }
            else
            {
                lblMensaje.Text = "El resultado de la operación no es correcto";
            }
        }
    }
}