using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionWebHotel.Modelo
{
    public class Empleado:Persona
    {
        private int idEmpleado;        
        private string cargo;
        public Empleado() { }
        /// <summary>
        /// Constructor clase Empleado
        /// </summary>
        /// <param name="cargo">Cargo del empleado</param>
        /// <param name="identificacion">Número documeto de identidad</param>
        /// <param name="nombre">Nombre completo de la persona</param>
        /// <param name="correo">correo electrónico</param>
        public Empleado(string cargo, string identificacion, string nombre, string correo)
            :base(identificacion, nombre, correo)
        {
            this.cargo = cargo;
        }
        public int IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }
        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }        
    }
}