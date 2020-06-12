using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AplicacionWebHotel.Modelo
{
    public class DatosCliente
    {
        private SqlConnection conexion;
        private SqlTransaction transaccion;
        private string error;

        public string Error
        {
            get { return error; }            
        }

        /// <summary>
        /// Constructor inicializa la conexión
        /// </summary>
        public DatosCliente()
        {
            this.conexion = Conexion.getConexion();
        }

        /// <summary>
        /// Método que agrega cliente a la base de datos
        /// </summary>
        /// <param name="unCliente">Objeto cliente con todos sus atributos</param>
        /// <returns>True o False</returns>
        public bool agregarCliente(Cliente unCliente)
        {
            this.error = "";
            bool agregado = false;
            SqlCommand comando = new SqlCommand();
            comando.Connection = this.conexion;
            try
            {
                comando.Transaction = this.conexion.BeginTransaction();
                //Agregar a tabla Persona
                comando.CommandText = "insert into Personas values(@identifica, @nombre, @correo)";
                comando.Parameters.AddWithValue("@identifica", unCliente.Identificacion);
                comando.Parameters.AddWithValue("@nombre", unCliente.Nombre);
                comando.Parameters.AddWithValue("@correo", unCliente.Correo);
                comando.ExecuteNonQuery();
                //obtener idPersona
                comando.CommandText = "select max(idPersona) from Personas";
                int idPersona = Convert.ToInt32(comando.ExecuteScalar());
                //agregar a tabla Clientes
                comando.CommandText = "insert into clientes values(@idPersona)";
                comando.Parameters.AddWithValue("@idPersona", idPersona);
                comando.ExecuteNonQuery();
                comando.Transaction.Commit();
                agregado = true;
            }catch(SqlException ex)
            {
                comando.Transaction.Rollback();
                this.error = ex.Message;
            }
            return agregado;
        }

        /// <summary>
        /// Obtener datos de un cliente por Identificación
        /// </summary>
        /// <param name="identificacion">Número documento de identidad</param>
        /// <returns>Retorna un objeto cliente con todos sus atributos</returns>
        public Cliente obtenerClientePorIdentificacion(string identificacion)
        {
            this.error = "";
            Cliente unCliente = null;
            SqlCommand comando = new SqlCommand();
            comando.Connection = this.conexion;
            comando.CommandText = "select Clientes.idCliente, Personas.*  from Personas" +
            " inner join Clientes on Clientes.cliPersona = Personas.idPersona" +
            " where Personas.perIdentificacion = @identifica";
            comando.Parameters.AddWithValue("@identifica", identificacion);
            try
            {
                SqlDataReader registro = comando.ExecuteReader();
                if (registro.Read())
                {
                    unCliente = new Cliente();
                    unCliente.IdCliente = registro.GetInt32(0);
                    unCliente.IdPersona = registro.GetInt32(1);
                    unCliente.Identificacion = registro.GetString(2);
                    unCliente.Nombre = registro.GetString(3);
                    unCliente.Correo = registro.GetString(4);
                }
                registro.Close();
            }catch(SqlException ex)
            {
                this.error = ex.Message;
            }
            return unCliente;
        }


    }
}