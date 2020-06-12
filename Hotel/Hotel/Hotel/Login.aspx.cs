using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text;
            string password = txtPassword.Text;
            string userName = "Hola";
            string passName = "123";

            if (user.Equals(userName) && password.Equals(passName))
            {
                Response.Write("<script>alert('Usuario y contraseña correctas')</script>");
            }
            else
            {
                Response.Write("<script>alert('Usuario y contraseña incorrectas')</script>");
                txtUsuario.Text = "";
                txtPassword.Text = "";
            }

        }
    }
}