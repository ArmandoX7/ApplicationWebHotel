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
    public class ControllerHabitacion
    {
        private string error;        
        DatosHabitacion objDatosHabitacion;

        public ControllerHabitacion()
        {
            this.objDatosHabitacion = new DatosHabitacion();
        }

        public string Error
        {
            get { return error; }
        }

        /// <summary>
        /// Permite agregar una habitación
        /// </summary>
        /// <param name="unaHabitacion">Objeto Habitación con todos sus atributos</param>
        /// <returns>True o False</returns>
        public bool agregarHabitacion(Habitacion unaHabitacion)
        {
            this.error = "";
            bool agregada = objDatosHabitacion.agregarHabitacion(unaHabitacion);
            this.error = objDatosHabitacion.Error;
            return agregada;
        }

        public List<TipoHabitacion> listarTiposHabitacion()
        {
            this.error = "";
            List<TipoHabitacion> listaTipos = objDatosHabitacion.obtenerTipoHabitacion();
            this.error = objDatosHabitacion.Error;
            return listaTipos;
        }

        public List<Habitacion> listaDisponibles(int piso, int tipo)
        {
            this.error = "";
            List<Habitacion> lista = objDatosHabitacion.obtenerHabitacionesDisponibles(piso, tipo);
            this.error = objDatosHabitacion.Error;
            return lista;
        }

        public List<Habitacion> listaDisponibles()
        {
            this.error = "";
            List<Habitacion> lista = objDatosHabitacion.obtenerHabitacionesDisponibles();
            this.error = objDatosHabitacion.Error;
            return lista;
        }

        public int obtenerCostoHabitacionPorNumero(int numeroHabitacion)
        {
            int costo = objDatosHabitacion.obtenerCostoHabitacionPorNumero(numeroHabitacion);
            this.error = objDatosHabitacion.Error;
            return costo;
        }

        public bool actualizarDescripcion(int numero, string descripcion)
        {
            bool actualizada = objDatosHabitacion.actualizarDescripcion(numero, descripcion);
            this.error = objDatosHabitacion.Error;
            return actualizada;
        }

        public Habitacion obtenerhabitacionPorNumero(int numero)
        {
            Habitacion unaHabitacion = objDatosHabitacion.obtenerhabitacionPorNumero(numero);
            this.error = objDatosHabitacion.Error;
            return unaHabitacion;
        }

        public DataSet  obtenerCantidadHabitacionesPorTipo()
        {
            return objDatosHabitacion.obtenerCantidadHabitacionesPorTipo();
        }

       
       
    }
}