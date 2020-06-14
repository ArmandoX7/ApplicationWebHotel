using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace hotelv3.Models
{
    [MetadataType(typeof(empleadosMetaData))]
    public partial class empleado
    {
        
    }

    public class empleadosMetaData
    {
        [ScaffoldColumn(false)]
        [Display(Name = "id Empleado")]
        public int idEmpleado { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Nombres")]
        [StringLength(20, ErrorMessage = "La longitud maxima es de 20")]
        [MinLength(2, ErrorMessage = "{0} debe tener una longitud mayor a 1 caracter")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Apellido Paterno")]
        [StringLength(15, ErrorMessage = "La longitud maxima es de 15")]
        [MinLength(2, ErrorMessage = "{0} debe tener una longitud mayor a 1 caracter")]
        public string apellido_pat { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Apellido Materno")]
        [StringLength(15, ErrorMessage = "La longitud maxima es de 15")]
        [MinLength(2, ErrorMessage = "{0} debe tener una longitud mayor a 1 caracter")]
        public string apellido_mat { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Sexo")]
        [StringLength(15, ErrorMessage = "La longitud maxima es de 15")]
        [MinLength(2, ErrorMessage = "{0} debe tener una longitud mayor a 1 caracter")]
        public string sexo { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Telefono")]
        [StringLength(20, ErrorMessage = "La longitud maxima es de 20")]
        [MinLength(2, ErrorMessage = "{0} debe tener una longitud mayor a 1 caracter")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Correo Electronico")]
        [StringLength(60, ErrorMessage = "La longitud maxima es de 60")]
        [MinLength(2, ErrorMessage = "{0} debe tener una longitud mayor a 1 caracter")]
        public string correo { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "RFC")]
        [StringLength(15, ErrorMessage = "La longitud maxima es de 15")]
        public string rfc { get; set; }
    }
}