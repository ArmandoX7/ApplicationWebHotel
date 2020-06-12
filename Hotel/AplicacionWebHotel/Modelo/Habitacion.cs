using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionWebHotel.Modelo
{
    public class Habitacion
    {
        private int idHabitacion;        
        private int numero;        
        private int piso;       
        private string descripcion;        
        private string estado;        
        private TipoHabitacion tipo;

        public Habitacion() 
        {
            tipo = new TipoHabitacion();
        }
        public Habitacion(int numero, int piso, string descripcion,
            string estado, TipoHabitacion tipo)
        {
            this.numero = numero;
            this.piso = piso;
            this.descripcion = descripcion;
            this.estado = estado;
            this.tipo = tipo;
        }
        public int IdHabitacion
        {
            get { return idHabitacion; }
            set { idHabitacion = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public int Piso
        {
            get { return piso; }
            set { piso = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public TipoHabitacion Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }


    }
}