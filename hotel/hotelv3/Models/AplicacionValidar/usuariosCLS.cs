using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace hotelv3.Models
{
    [MetadataType(typeof(usuariosMetaData))]
    public partial class usuario
    {
    }

    public class usuariosMetaData
    {
        [ScaffoldColumn(false)]
        [Display(Name ="id Usuario")]
        public int idUser { get; set; }

        [Required(ErrorMessage ="{0} es requerido")]
        [Display(Name = "Correo Electronico")]
        [StringLength(30,ErrorMessage ="La longitud maxima es de 30")]
        [MinLength(6,ErrorMessage ="{0} debe tener una longitud mayor a 5 caracteres")]
        public string email { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Contraseña")]
        [StringLength(30, ErrorMessage = "La longitud maxima es de 30")]
        [MinLength(6, ErrorMessage = "{0} debe tener una longitud mayor a 5 caracteres")]
        public string password { get; set; }
    }
}