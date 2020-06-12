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
    public class ControllerAlquiler
    {
        private string error;

        public string Error
        {
            get { return error; }
            set { error = value; }
        }
        private DatosAlquiler objDatosAlquiler;

        public ControllerAlquiler()
        {
            this.objDatosAlquiler = new DatosAlquiler();
        }
        /// <summary>
        /// Controlador alquilar Habitacion
        /// </summary>
        /// <param name="unAlquiler">Objeto alquiler con todos sus atributos</param>
        /// <returns>True o False</returns>
        public bool alquilarHabitacion(Alquiler unAlquiler)
        {
            this.error = "";
            bool alquilada = objDatosAlquiler.alquilarHabitacion(unAlquiler);
            this.error = objDatosAlquiler.Error;
            return alquilada;
        }

        public DataSet obtenerAlquiladas()
        {
            return objDatosAlquiler.obtenerAlquiladas();
        }

       
        public Alquiler obtenerAlquilerPorhabitacion(int numeroHabitacion)
        {
            Alquiler unAlquiler = objDatosAlquiler.obtenerAlquilerPorHabitacion(numeroHabitacion);
            this.error = objDatosAlquiler.Error;
            return unAlquiler;
        }

        public bool entregarHabitacion(Alquiler unAlquiler)
        {
            bool entregada = objDatosAlquiler.entregarHabitacion(unAlquiler);
            this.error = objDatosAlquiler.Error;
            return entregada;
        }

        public DataSet listarHabitacionesPorRangoDeFecha(DateTime fechaInicio, DateTime fechaFinal)
        {
            return objDatosAlquiler.listarHabitacionesPorRangoDeFecha(fechaInicio, fechaFinal);
        }
    }
}