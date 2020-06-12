using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionWebHotel.Modelo
{
    public class Cliente:Persona
    {
        private int idCliente;

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }
        public Cliente(){}

        public Cliente(string identificacion, string nombre, string correo)
            :base(identificacion, nombre, correo)
        {
            /*Aquí no hacemos nada pero si se ejecuta el llamado al
            constructor de La clase padre*/
        }
    }
}