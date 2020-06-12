using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AplicacionWebHotel.Modelo
{
    public class DatosHabitacion
    {
        public SqlConnection conexion;
        public SqlTransaction transaccion;
        private string error;

        public DatosHabitacion()
        {
            this.conexion = Conexion.getConexion();
        }
        /// <summary>
        /// Agrega una habitación a la base de datos
        /// </summary>
        /// <param name="unaHabitacion">Objeto tipo Habitacion</param>
        /// <returns>True o False</returns>
        public bool agregarHabitacion(Habitacion unaHabitacion)
        {
            this.error = "";
            bool agregada = false;
            SqlCommand comando = new SqlCommand();
            comando.Connection = this.conexion;
            comando.CommandText = "insert into Habitaciones " +
                " values(@numero,@piso,@descripcion,@estado,@tipo)";
            comando.Parameters.AddWithValue("@numero", unaHabitacion.Numero);
            comando.Parameters.AddWithValue("@piso", unaHabitacion.Piso);
            comando.Parameters.AddWithValue("@descripcion", unaHabitacion.Descripcion);
            comando.Parameters.AddWithValue("@estado", unaHabitacion.Estado);
            comando.Parameters.AddWithValue("@tipo", unaHabitacion.Tipo.IdTipoHabitacion);
            try
            {
                comando.ExecuteNonQuery();
                agregada = true;
            }catch(SqlException ex){
                this.error = ex.Message;
            }
            return agregada;
        }
        /// <summary>
        /// Obtener un listado de todos los tipos de habitaciones
        /// </summary>
        /// <returns>Lista con todos los tipos</returns>
        public List<TipoHabitacion> obtenerTipoHabitacion()
        {
            List<TipoHabitacion> listaTipos = new List<TipoHabitacion>();
            SqlCommand comando = new SqlCommand();
            comando.Connection = this.conexion;
            comando.CommandText = "select * from TipoHabitaciones";
            try
            {
                SqlDataReader registro = comando.ExecuteReader();
                while(registro.Read()){
                    TipoHabitacion tipoH = new TipoHabitacion();
                    tipoH.IdTipoHabitacion = registro.GetInt32(0);
                    tipoH.Nombre = registro.GetString(1);
                    tipoH.Costo = registro.GetInt32(2);
                    listaTipos.Add(tipoH);
                }
                registro.Close();
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
            }
            return listaTipos;
        }
        /// <summary>
        /// Obtener habitaciones disponibles por piso y tipo
        /// </summary>
        /// <returns>Lista de habitaciones disponibles</returns>
        public List<Habitacion> obtenerHabitacionesDisponibles(int piso, int tipo)
        {
            List<Habitacion> listaDisponibles = new List<Habitacion>();
            this.error = "";
            SqlCommand comando = new SqlCommand();
            comando.Connection = this.conexion;
            comando.CommandText = "select * from Habitaciones" +
            " where habPiso = @piso and " +
            " habTipoHabitacion = @tipo and " +
            " habEstado = 'Disponible'";
            comando.Parameters.AddWithValue("@piso", piso);
            comando.Parameters.AddWithValue("@tipo", tipo);
            try
            {
                SqlDataReader registro = comando.ExecuteReader();
                while(registro.Read()){
                    Habitacion unaHabitacion = new Habitacion();
                    unaHabitacion.IdHabitacion = registro.GetInt32(0);
                    unaHabitacion.Numero = registro.GetInt32(1);
                    unaHabitacion.Piso = registro.GetInt32(2);
                    unaHabitacion.Descripcion = registro.GetString(3);
                    unaHabitacion.Estado = registro.GetString(4);
                    unaHabitacion.Tipo.IdTipoHabitacion = registro.GetInt32(5);
                    listaDisponibles.Add(unaHabitacion);
                }
                registro.Close();
            }catch(SqlException ex)
            {
                this.error = ex.Message;
            }
            return listaDisponibles;
        }

        /// <summary>
        /// Obtener Habitaciones Disponibles
        /// </summary>
        /// <returns>Lista de Objetos Habitacion</returns>
        public List<Habitacion> obtenerHabitacionesDisponibles()
        {
            List<Habitacion> listaDisponibles = new List<Habitacion>();
            this.error = "";
            SqlCommand comando = new SqlCommand();
            comando.Connection = this.conexion;
            comando.CommandText = "select * from Habitaciones" +
            " where habEstado = 'Disponible'";            
            try
            {
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    Habitacion unaHabitacion = new Habitacion();
                    unaHabitacion.IdHabitacion = registro.GetInt32(0);
                    unaHabitacion.Numero = registro.GetInt32(1);
                    unaHabitacion.Piso = registro.GetInt32(2);
                    unaHabitacion.Descripcion = registro.GetString(3);
                    unaHabitacion.Estado = registro.GetString(4);
                    unaHabitacion.Tipo.IdTipoHabitacion = registro.GetInt32(5);
                    listaDisponibles.Add(unaHabitacion);
                }
                registro.Close();
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
            }
            return listaDisponibles;
        }

        /// <summary>
        /// obtener el valor de la noche de acuerdo al tipo de habitacion
        /// </summary>
        /// <param name="numeroHabitacion">número de habitacion</param>
        /// <returns>Enero: Costo de una noche</returns>
        public int obtenerCostoHabitacionPorNumero(int numeroHabitacion)
        {
            this.error = "";
            int costo=0;
            SqlCommand comando = new SqlCommand();
            comando.Connection = this.conexion;
            comando.CommandText = "select TipoHabitaciones.tipCosto from TipoHabitaciones " +
                " inner join Habitaciones on Habitaciones.habTipohabitacion = TipoHabitaciones.idTipoHabitacion " +
                " where Habitaciones.habNumero=@numero";
            comando.Parameters.AddWithValue("@numero", numeroHabitacion);
            try
            {
                costo = Convert.ToInt32(comando.ExecuteScalar());
               
            }catch(SqlException ex)
            {
                this.error = ex.Message;
            }
            return costo;
        }

        public bool actualizarDescripcion(int numero, string descripcion)
        {
            bool actualizada = false;
            this.error = "";
            SqlCommand comando = new SqlCommand();
            comando.Connection = this.conexion;
            comando.CommandText = "actualizarDescripcion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@numeroHabitacion", numero);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            try
            {
                comando.ExecuteNonQuery();
                actualizada = true;
            }catch(SqlException ex)
            {
                this.error = ex.Message;
            }

            return actualizada;
        }

        public Habitacion obtenerhabitacionPorNumero(int numero)
        {
            this.error = "";
            Habitacion unaHabitacion = null;
            SqlCommand comando = new SqlCommand();
            comando.Connection = this.conexion;
            comando.CommandText = "select * from Habitaciones where habNumero = @numero";
            comando.Parameters.AddWithValue("@numero", numero);
            try
            {
                SqlDataReader registro = comando.ExecuteReader();
                if (registro.Read()){
                    unaHabitacion = new Habitacion();
                    unaHabitacion.IdHabitacion = registro.GetInt32(0);
                    unaHabitacion.Numero = registro.GetInt32(1);
                    unaHabitacion.Piso = registro.GetInt32(2);
                    unaHabitacion.Descripcion = registro.GetString(3);
                    unaHabitacion.Estado = registro.GetString(4);
                    unaHabitacion.Tipo.IdTipoHabitacion = registro.GetInt32(5);
                }
                registro.Close();
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
            }
            return unaHabitacion;
        }

        public DataSet obtenerCantidadHabitacionesPorTipo()
        {
            this.error = "";
            SqlCommand comando = new SqlCommand();
            comando.Connection = this.conexion;
            comando.CommandText = "select * from VistaCantidadHabitacionesPorTipo";
            DataSet registros = new DataSet();
            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(registros, "VistaCantidadHabitacionesPorTipo");
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
            }
            return registros;
        }

        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        
    }
}