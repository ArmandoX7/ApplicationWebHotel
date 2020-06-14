using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hotelv2.Models
{
    public class EmpleadoCLS
    {
        [Display(Name ="id Empleado")]
        public int idEmpleado { get; set; }
        [Display(Name = "Nombres")]
        public string nombre { get; set; }
        [Display(Name = "Apellido Paterno")]
        public string apellido_pat { get; set; }
        [Display(Name = "Apellido Materno")]
        public string apellido_mat { get; set; }
        [Display(Name = "Sexo")]
        public string sexo { get; set; }
        [Display(Name = "Telefono")]
        public string telefono { get; set; }
        [Display(Name = "Correo Electronico")]
        public string correo { get; set; }
        [Display(Name = "RFC")]
        public string rfc { get; set; }
    }
}