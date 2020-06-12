using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace AplicacionWebHotel.Modelo
{
    public class DatosContactenos
    {
        private SqlConnection conexion;
        private SqlTransaction transaccion;
        private string error;

        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        public DatosContactenos()
        {
            this.conexion = Conexion.getConexion();
        }

        public bool agregarComentario(Contactenos unContactenos)
        {
            this.error=null;
            bool agregado = false;
            SqlCommand comando = new SqlCommand();
            comando.Connection = this.conexion;
            comando.CommandText = "insert into Contactenos values(@nombre, @correo, @comentario)";
            comando.Parameters.AddWithValue("@nombre", unContactenos.nombre);
            comando.Parameters.AddWithValue("@correo", unContactenos.correo);
            comando.Parameters.AddWithValue("@comentario", unContactenos.comentario);
            try
            {
                comando.ExecuteNonQuery();
                agregado=true;
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;

            }
            return agregado;
        }
    }
}