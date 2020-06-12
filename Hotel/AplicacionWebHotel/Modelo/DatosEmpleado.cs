using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AplicacionWebHotel.Modelo
{
    public class DatosEmpleado
    {
        public SqlConnection conexion;
        public SqlTransaction transaccion;
        private string error;

        /// <summary>
        /// 
        /// </summary>
        public DatosEmpleado()
        {
            this.conexion = Conexion.getConexion();
        }

        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        public bool agregarEmpleado(Empleado unEmpleado)
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
                comando.Parameters.AddWithValue("@identifica", unEmpleado.Identificacion);
                comando.Parameters.AddWithValue("@nombre", unEmpleado.Nombre);
                comando.Parameters.AddWithValue("@correo", unEmpleado.Correo);
                comando.ExecuteNonQuery();
                //obtener idPersona
                comando.CommandText = "select max(idPersona) from Personas";
                int idPersona = Convert.ToInt32(comando.ExecuteScalar());
                //Agregar tabla Empleado
                comando.CommandText = "insert into Empleados values(@idPersona, @cargo)";
                comando.Parameters.AddWithValue("@idPersona", idPersona);
                comando.Parameters.AddWithValue("@cargo", unEmpleado.Cargo);
                comando.ExecuteNonQuery();
                //obtener idEmpleado
                comando.CommandText = "select max(idEmpleado) from Empleados";
                int idEmpleado = Convert.ToInt32(comando.ExecuteScalar());
                //Agregar a Tabla Usuario
                comando.CommandText = "insert into usuarios values(@idEmpleado,@login, @password)";
                comando.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                comando.Parameters.AddWithValue("@login", unEmpleado.Identificacion);
                comando.Parameters.AddWithValue("@password", unEmpleado.Identificacion);
                comando.ExecuteNonQuery();
                comando.Transaction.Commit();                
                agregado = true;
            }catch(SqlException ex){
                comando.Transaction.Rollback();
                this.error = ex.Message;
            }
            return agregado;
        }

        public Empleado iniciarSesion(string usuario, string password)
        {
            this.error = "";
            SqlCommand comando = new SqlCommand();
            comando.Connection = this.conexion;
            comando.CommandText = "select Empleados.idEmpleado, Empleados.empCargo from Empleados " +
                " inner join Personas on Empleados.empPersona = Personas.idPersona " +
                " inner join Usuarios on Usuarios.usuEmpleado = Empleados.idEmpleado " +
                " where Usuarios.usuLogin=@login and Usuarios.usuPassword=@password";
            comando.Parameters.AddWithValue("@login", usuario);
            comando.Parameters.AddWithValue("@password", password);
            Empleado unEmpleado = null;
            try
            {
                SqlDataReader registro = comando.ExecuteReader();
                if (registro.Read())
                {
                    unEmpleado = new Empleado();
                    unEmpleado.IdEmpleado = Convert.ToInt32(registro["idEmpleado"].ToString());
                    unEmpleado.Cargo = registro["empCargo"].ToString();
                }
                registro.Close();
            }catch(SqlException ex)
            {
                this.error = ex.Message;
            }
            return unEmpleado;
        }

    }
}