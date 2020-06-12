using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AplicacionWebHotel.Modelo;

namespace AplicacionWebHotel.Controlador
{
    public class ControllerCliente
    {
        private DatosCliente objDatosCliente;
        private string error;

        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        public ControllerCliente()
        {
            this.objDatosCliente = new DatosCliente();
        }

        /// <summary>
        /// Método controlador qye agrega un cliente
        /// </summary>
        /// <param name="unCliente">Objeto cliente con todos su atributos</param>
        /// <returns>True o False</returns>
        public bool agregarCliente(Cliente unCliente)
        {
            this.error = "";
            bool agregado = objDatosCliente.agregarCliente(unCliente);
            this.error = objDatosCliente.Error;
            return agregado;
        }

        /// <summary>
        /// Método que obtiene los datos del cliente de acuerdo a su número de documento
        /// </summary>
        /// <param name="identificacion">número de documento de identidad</param>
        /// <returns>Cliente con todos sus datos</returns>
        public Cliente obtenerClientePorIdentificacion(string identificacion)
        {
            this.error = "";
            Cliente unCliente = objDatosCliente.obtenerClientePorIdentificacion(identificacion);
            this.error = objDatosCliente.Error;
            return unCliente;
        }

    }
}