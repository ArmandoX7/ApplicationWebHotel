using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using AplicacionWebHotel.Controlador;
using AplicacionWebHotel.Modelo;

namespace AplicacionWebHotel.Vista
{
    public partial class SolicitudAjax : System.Web.UI.Page
    {
        private static ControllerCliente objControlerCliente = new ControllerCliente();
        private static ControllerHabitacion objControlerHabitacion = new ControllerHabitacion();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static Cliente obtenerClientePorIdentificacion(string identificacion)
        {
            Cliente unCliente = objControlerCliente.obtenerClientePorIdentificacion(identificacion);
            return unCliente;
        }

        [WebMethod]
        public static string obtenerClientePorIdentificacion2(string identificacion)
        {
            Cliente unCliente = objControlerCliente.obtenerClientePorIdentificacion(identificacion);
            return unCliente.IdCliente + unCliente.Nombre;
        }

        [WebMethod]
        public static string prueba()
        {
            return "Funcionando";
        }

        [WebMethod]
        public List<Habitacion> obtenerHabitacionesDisponibles(int piso, int tipo)
        {
            List<Habitacion> listaHabitaciones = objControlerHabitacion.listaDisponibles(piso, tipo);
            return listaHabitaciones;
        }

        [WebMethod]
        public static Habitacion obtenerHabitacionPorNumero(int numero)
        {
            Habitacion unaHabitacion = objControlerHabitacion.obtenerhabitacionPorNumero(numero);
            return unaHabitacion;
        }

         [WebMethod]
        public static string obtenerCantidadHabitacionesPorTipo()
        {
           
          
             int cantidad = objControlerHabitacion.obtenerCantidadHabitacionesPorTipo().Tables[0].Rows.Count;
             string jsonString = "[['Tipo', 'Cantidad']";
             
             for (int i = 0; i < cantidad; i++)
             {
                 jsonString += ",['" + objControlerHabitacion.obtenerCantidadHabitacionesPorTipo().Tables[0].Rows[i][0].ToString() + "'";
                 jsonString += "," + Convert.ToInt32(objControlerHabitacion.obtenerCantidadHabitacionesPorTipo().Tables[0].Rows[i][1].ToString()) + "]";
             }
             jsonString += "]";
             return jsonString;
        }
    }
}