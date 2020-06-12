using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionWebHotel.Modelo
{
    public class TipoHabitacion
    {
        private int idTipoHabitacion;        
        private string nombre;        
        private int costo;

        public TipoHabitacion() { }

        /// <summary>
        /// Constructor clase TipoHabitación
        /// </summary>
        /// <param name="nombre">Nombre tipo Hbitación: sencilla, doble, familiar</param>
        /// <param name="costo">Valor noche en el tipo de habitación</param>
        public TipoHabitacion(string nombre, int costo)
        {
            this.nombre = nombre;
            this.costo = costo;
        }

        public int IdTipoHabitacion
        {
            get { return idTipoHabitacion; }
            set { idTipoHabitacion = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Costo
        {
            get { return costo; }
            set { costo = value; }
        }


    }
}