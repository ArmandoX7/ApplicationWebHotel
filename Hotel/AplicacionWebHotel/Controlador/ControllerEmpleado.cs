using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AplicacionWebHotel.Modelo;

namespace AplicacionWebHotel.Controlador
{
    public class ControllerEmpleado
    {
        private string error;        
        DatosEmpleado objDatosEmpleado;

        public ControllerEmpleado()
        {
            objDatosEmpleado = new DatosEmpleado();
        }
        ///

        public bool agregarEmpleado(Empleado unEmpleado)
        {
            this.error = "";
            bool agrega = objDatosEmpleado.agregarEmpleado(unEmpleado);
            this.error = objDatosEmpleado.Error;
            return agrega;
        }

        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        public Empleado iniciarSesion(string usuario, string password)
        {
            Empleado unEmpleado = objDatosEmpleado.iniciarSesion(usuario, password);
            this.error = objDatosEmpleado.Error;
            return unEmpleado;
        }
    }
}