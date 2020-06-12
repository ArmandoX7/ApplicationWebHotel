using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AplicacionWebHotel.Vista.Recepcionista
{
    public partial class frmReportesRecepcionista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
           ReportViewer1.ServerReport.Refresh();
        }
    }
}