using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using AplicacionWebHotel.Controlador;
using AplicacionWebHotel.Modelo;
namespace AplicacionWebHotel.Vista.Gerente
{
    public partial class SolicitudesAjax : System.Web.UI.Page
    {
        private static ControllerHabitacion objControlerHabitacion = new ControllerHabitacion();
        private static ControllerCliente objControlerCliente = new ControllerCliente();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<Habitacion> obtenerHabitacionesDisponibles(int tipo, int piso)
        {
            List<Habitacion> listaHabitaciones = objControlerHabitacion.listaDisponibles(piso, tipo);
            return listaHabitaciones;
        }
        [WebMethod]
        public static Cliente obtenerClientePorIdentificacion(string identificacion)
        {
            Cliente unCliente = objControlerCliente.obtenerClientePorIdentificacion(identificacion);
            return (unCliente);
        }

         [WebMethod]
        public static Habitacion obtenerHabitacionPorNumero(int numero){
            Habitacion unaHabitacion = objControlerHabitacion.obtenerhabitacionPorNumero(numero);
            return unaHabitacion;
         }
    }
}