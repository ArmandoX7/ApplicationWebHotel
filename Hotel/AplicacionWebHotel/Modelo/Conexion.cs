using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AplicacionWebHotel.Modelo
{
    public class Conexion
    {
        private static SqlConnection objConexion;
        private static string error;

        /// <summary>
        /// Método que crea una conexión de tipo sqlConnection sino existe y la retorna
        /// </summary>
        /// <returns>retorna objeto sqlConnection</returns>
        public static SqlConnection getConexion()
        {
            if (objConexion != null)
                return objConexion;
            objConexion = new SqlConnection();
          //  objConexion.ConnectionString = "Data Source=POPDFPRCC8F094; Initial Catalog=Hotel;Integrated Security=True";
            objConexion.ConnectionString = "Data Source=DESKTOP-T85NLC8; Initial Catalog=Hotel;Integrated Security=True";
            try
            {
                objConexion.Open();
                return objConexion;
            }
            catch (Exception e)
            {
                error = e.Message;
                return null;
            }
        }

        public static void cerrarConexion()
        {
            if (objConexion != null)
                objConexion.Close();
        }
    }
}