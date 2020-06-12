using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AplicacionWebHotel.Modelo
{
    public class DatosAlquiler
    {
        private SqlConnection conexion;
        private SqlTransaction transaccion;
        private string error;

        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        public DatosAlquiler()
        {
            this.conexion = Conexion.getConexion();
        }
        /// <summary>
        /// Alquilar habitación 
        /// </summary>
        /// <param name="unAlquiler">Objeto alquiler con todos sus datos</param>
        /// <returns>True o False</returns>
        public bool alquilarHabitacion(Alquiler unAlquiler)
        {
            bool alquilada = false;
            this.error = "";
            SqlCommand comando = new SqlCommand();
            comando.Connection = this.conexion;
            try
            {
                comando.Transaction = this.conexion.BeginTransaction();
                //agregar tabla alquiler
                comando.CommandText = "insert into Alquiler values " +
                " (@habitacion,@cliente,@fechaIngreso,@fechaSalida,@observacion,@estado,@costo,@usuario)";
                comando.Parameters.AddWithValue("@habitacion", unAlquiler.unaHabitacion.IdHabitacion);
                comando.Parameters.AddWithValue("@cliente", unAlquiler.unCliente.IdCliente);
                comando.Parameters.AddWithValue("@fechaIngreso", unAlquiler.fechaAlquiler);
                comando.Parameters.AddWithValue("@fechaSalida", unAlquiler.fechaSalida);
                comando.Parameters.AddWithValue("@observacion", unAlquiler.observaciones);
                comando.Parameters.AddWithValue("@estado", unAlquiler.estado);
                comando.Parameters.AddWithValue("@costo", unAlquiler.costo);
                comando.Parameters.AddWithValue("@usuario", unAlquiler.idUsuario);
                comando.ExecuteNonQuery();
                //actualizar estado habitación
                comando.Parameters.Clear();
                comando.CommandText = "update Habitaciones set habEstado = 'Alquilada' where idHabitacion=@habitacion";
                comando.Parameters.AddWithValue("@habitacion", unAlquiler.unaHabitacion.IdHabitacion);
                comando.ExecuteNonQuery();
                comando.Transaction.Commit();
                alquilada = true;
            }catch(SqlException ex)
            {
                this.error = ex.Message;
                comando.Transaction.Rollback();
            }
            return alquilada;
        }

        public DataSet obtenerAlquiladas()
        {
            this.error = "";
            SqlCommand comando = new SqlCommand();
            comando.Connection = this.conexion;
            comando.CommandText = "select Habitaciones.habNumero as Habitacion, Personas.perNombre as Cliente, " +
            " Alquiler.alqFechaIngreso as FechaIngreso from Personas " +
            " inner join Clientes on Clientes.cliPersona = Personas.idPersona" +
            " inner join Alquiler on Clientes.idCliente = Alquiler.alqCliente" +
            " inner join Habitaciones on Habitaciones.idHabitacion = Alquiler.alqHabitacion" + 
            " where Alquiler.alqEstado='Registrado'";          
            
            DataSet registros = new DataSet();
            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(registros, "Personas");
            }catch(SqlException ex)
            {
                this.error = ex.Message;
            }           
            return registros;            
        }

       
        public bool entregarHabitacion(Alquiler unAlquiler)
        {
            bool entregada = false;
            this.error = "";
            SqlCommand comando = new SqlCommand();
            comando.Connection = this.conexion;
            try
            {
                comando.Transaction = this.conexion.BeginTransaction();
                comando.CommandText = "update Alquiler set alqFechaSalida=@fechaSalida, " +
                    " alqEstado=@estado, alqCostoTotal=@costo, alqObservacion=@observacion " + 
                    " where idAlquiler=@idAlquiler" ;
                comando.Parameters.AddWithValue("@fechaSalida", unAlquiler.fechaSalida);
                comando.Parameters.AddWithValue("@observacion", unAlquiler.observaciones);
                comando.Parameters.AddWithValue("@estado", unAlquiler.estado);
                comando.Parameters.AddWithValue("@costo", unAlquiler.costo);
                comando.Parameters.AddWithValue("@idAlquiler", unAlquiler.idAlquiler);
                comando.ExecuteNonQuery();
                //actualizar estado habitación
                comando.Parameters.Clear();
                comando.CommandText = "update Habitaciones set habEstado = 'Disponible' where idHabitacion=@habitacion";
                comando.Parameters.AddWithValue("@habitacion", unAlquiler.unaHabitacion.IdHabitacion);
                comando.ExecuteNonQuery();
                comando.Transaction.Commit();
                entregada = true;
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
                comando.Transaction.Rollback();
            }
            return entregada;

        }

        public Alquiler obtenerAlquilerPorHabitacion(int numeroHabitacion)
        {
            Alquiler unAlquiler = null;
            this.error = null;
            SqlCommand comando = new SqlCommand();
            comando.Connection = this.conexion;
            comando.CommandText = "select * from Alquiler inner join Habitaciones " +
                " on Alquiler.alqHabitacion = Habitaciones.idHabitacion " + 
                " inner join Clientes on Alquiler.alqCliente = Clientes.idCliente " + 
                " inner join Personas on Clientes.cliPersona = Personas.idPersona " +
                " where Habitaciones.habNumero = @numero and Alquiler.alqEstado='Registrado'";
            comando.Parameters.AddWithValue("@numero", numeroHabitacion);
            try
            {
                 SqlDataReader registro = comando.ExecuteReader();
                if(registro.Read())
                {
                    unAlquiler = new Alquiler();
                    unAlquiler.idAlquiler = Convert.ToInt32(registro["idAlquiler"]);
                    unAlquiler.unaHabitacion.IdHabitacion = Convert.ToInt32(registro["alqHabitacion"]);
                    unAlquiler.unCliente.IdCliente = Convert.ToInt32(registro["alqCliente"]);
                    unAlquiler.unCliente.Nombre = registro["perNombre"].ToString();
                    unAlquiler.fechaAlquiler = Convert.ToDateTime(registro["alqFechaIngreso"]);
                    unAlquiler.fechaSalida = Convert.ToDateTime(registro["alqFechaSalida"]);
                    unAlquiler.estado = registro["alqEstado"].ToString();
                    unAlquiler.costo = Convert.ToInt32(registro["alqCostoTotal"]);
                    unAlquiler.observaciones = registro["alqObservacion"].ToString();
                    unAlquiler.idUsuario = Convert.ToInt32(registro["alqUsuario"]);
                }
                registro.Close();                
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
            }
            return unAlquiler;
        }

        public DataSet listarHabitacionesPorRangoDeFecha(DateTime fechaInicio, DateTime fechaFinal)
        {
            this.error = "";
            SqlCommand comando = new SqlCommand();
            comando.Connection = this.conexion;
            comando.CommandText = "select Habitaciones.habNumero as Numero_Habitacion, Personas.perNombre as Cliente, " + 
                " Alquiler.alqFechaIngreso as Fecha_Ingreso, Alquiler.alqFechaSalida as Fecha_salida, " + 
                " DATEDIFF(day, Alquiler.alqFechaIngreso, Alquiler.alqFechaSalida) as dias, TipoHabitaciones.tipCosto as Costo_Noche, " +
                " Alquiler.alqCostoTotal as Coto_Total from Habitaciones inner join Alquiler on Alquiler.alqHabitacion = Habitaciones.idHabitacion " +
                " inner join Clientes on Alquiler.alqCliente = Clientes.idCliente " +
                " inner join Personas on Clientes.cliPersona = Personas.idPersona " +
                " inner join TipoHabitaciones on Habitaciones.habTipoHabitacion = TipoHabitaciones.idTipoHabitacion " +
                " where Alquiler.alqFechaIngreso >= @fechaInicial and Alquiler.alqFechaIngreso<= @fechaFinal " +
                " and Alquiler.alqEstado='Entregada'";
            comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
            comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
            DataSet registros = new DataSet();
            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(registros, "Habitaciones");
            }catch(SqlException ex)
            {
                this.error = ex.Message;
            }           
            return registros; 
        }
    }
}