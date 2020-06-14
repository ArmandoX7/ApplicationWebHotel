using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hotelv2.Models
{
    public class UsuarioCLS
    {
        [Display(Name = "id Usuario")]
        public int idUser { get; set; }
        [Display(Name = "correo electronico")]
        [Required]
        [StringLength(30, ErrorMessage = "La longit maxima es de 30")]
        public string email { get; set; }
        [Display(Name = "contraseña")]
        [Required]
        [StringLength(30, ErrorMessage = "La longit maxima es de 30")]
        public string password { get; set; }
    }
}