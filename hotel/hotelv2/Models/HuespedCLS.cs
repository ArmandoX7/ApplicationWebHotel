using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace hotelv2.Models
{
    public class HuespedCLS
    {
        [Display(Name ="id Huesped")]
        public int idHuesped { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        [StringValidator]
        public string nombres { get; set; }
        [Display(Name = "Apellido Paterno")]
        public string apellido_pat { get; set; }
        [Display(Name = "Apellido Materno")]
        public string apellido_mat { get; set; }
        [Display(Name = "Edad")]
        public int edad { get; set; }
        [Display(Name = "Sexo")]
        public string sexo { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime fecha_nac { get; set; }
        [Display(Name = "Lugar de Nacimiento")]
        public string lugar_nac { get; set; }
        [Display(Name = "Direccion")]
        public string direccion { get; set; }
        [Display(Name = "Telefono casa")]
        public string tel_casa { get; set; }
        [Display(Name = "Telefono celular")]
        public string tel_celular { get; set; }
        [Display(Name = "Correo Electronico")]
        public string correo { get; set; }
        [Display(Name = "RFC")]
        public string rfc { get; set; }
        [Display(Name = "Numero de Visitas")]
        public int numVisita { get; set; }

    }
}