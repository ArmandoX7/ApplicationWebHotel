using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.exceptions;
using iTextSharp.text.factories;
using itextsharp.pdfa;

namespace AplicacionWebHotel.Vista.Recepcionista
{
    public partial class frmEjemploPdf : System.Web.UI.Page
    {
        private static Document documento = null;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            documento = new Document(PageSize.LETTER);
            string ruta = Server.MapPath(@"archivo.pdf");
            FileStream file = new FileStream(ruta, FileMode.Create);
            PdfWriter.GetInstance(documento, file);
            documento.Open();
            documento.AddAuthor("César Cuéllar");
            documento.AddCreationDate();
            documento.AddTitle("Ejemplo Creación Pdf dese C#");
            documento.Add(new Paragraph("EJEMPLO TITULO DOCUMENTO PDF"));
            documento.Add(new Paragraph("Aquí inicia contenido del documento......"));
            PdfPTable tabla = new PdfPTable(3);
            tabla.AddCell("Identificación");
            tabla.AddCell("Nombre");
            tabla.AddCell("Correo");
            for (int i = 0; i < 15; i++)
            {
                tabla.AddCell("celda " + i);
            }
            documento.Add(tabla);
            documento.Close();
        }

        protected void btnCrearTabla_Click(object sender, EventArgs e)
        {
          /*  PdfPTable tabla = new PdfPTable(3);
            for (int i = 0; i < 15; i++)
            {
                tabla.AddCell("celda " + i);
            }
            documento.Add(tabla);*/
        }
    }
}