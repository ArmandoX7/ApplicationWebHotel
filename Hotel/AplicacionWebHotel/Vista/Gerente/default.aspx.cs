using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWebHotel.Vista.Gerente
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idEmpleado"] == null)
            {
                Response.Redirect("../frmIniciarSesion.aspx?x=1");
            }
        }
    }
}