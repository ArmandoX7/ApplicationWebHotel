using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using AplicacionWebHotel.Modelo;
using AplicacionWebHotel.Controlador;

namespace AplicacionWebHotel.Vista
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServiceAjax
    {
        private ControllerHabitacion objControlerHabitacion = new ControllerHabitacion();
        private ControllerCliente objControlerCliente = new ControllerCliente();
        [OperationContract]
        public IEnumerable<Habitacion> obtenerHabitacionesDisponibles(int piso, int tipo)
        {
            List<Habitacion> listaHabitaciones = objControlerHabitacion.listaDisponibles(piso, tipo);
            return listaHabitaciones;
        }
        [OperationContract]
        public string obtenerNombreByIdentificacion()
        {
            return "Encontrado";
        }
        [OperationContract]
        public Cliente obtenerClientePorIdentificacion()
        {
            Cliente unCliente = objControlerCliente.obtenerClientePorIdentificacion("99");
            return (unCliente);
        }


    }
}
