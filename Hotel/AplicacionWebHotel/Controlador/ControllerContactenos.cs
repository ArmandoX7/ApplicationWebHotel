using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using AplicacionWebHotel.Modelo;

namespace AplicacionWebHotel.Controlador
{
    public class ControllerContactenos
    {
        private DatosContactenos objDatosContactenos;
        private string error;

        public string Error
        {
            get { return error; }
            set { error = value; }
        }
      

        public ControllerContactenos()
        {
            this.objDatosContactenos = new DatosContactenos();
        }

        public bool agregarComentario(Contactenos unContactenos)
        {
            bool agregado = objDatosContactenos.agregarComentario(unContactenos);
            this.error = objDatosContactenos.Error;
            return agregado;
        }
    }
}