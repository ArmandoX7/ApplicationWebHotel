using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionWebHotel.Modelo
{
    public class Persona
    {
        private int idPersona;        
        private string identificacion;       
        private string nombre;        
        private string correo;

        public Persona() { }

        /// <summary>
        /// Constructor clase persona
        /// </summary>
        /// <param name="identificacion">Número documeto de identidad</param>
        /// <param name="nombre">Nombre completo de la persona</param>
        /// <param name="correo">correo electrónico</param>
        public Persona(string identificacion, string nombre, string correo)
        {
            this.identificacion = identificacion;
            this.nombre = nombre;
            this.correo = correo;
        }

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }

        public string Identificacion
        {
            get { return identificacion; }
            set { identificacion = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }


    }
}