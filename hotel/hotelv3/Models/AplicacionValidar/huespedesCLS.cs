using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace hotelv3.Models
{
    [MetadataType(typeof(huespedesMetaData))]
    public partial class huesped
    {

    }

    public class huespedesMetaData
    {
        [ScaffoldColumn(false)]
        [Display(Name = "id Usuario")]
        public int idHuesped { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Nombres")]
        [StringLength(25, ErrorMessage = "La longitud maxima es de 25")]
        public string nombres { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Apellido Paterno")]
        [StringLength(15, ErrorMessage = "La longitud maxima es de 15")]
        public string apellido_pat { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Apellido Materno")]
        [StringLength(15, ErrorMessage = "La longitud maxima es de 15")]
        public string apellido_mat { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Edad")]
        public int edad { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Sexo")]
        [StringLength(15, ErrorMessage = "La longitud maxima es de 15")]
        public string sexo { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Fecha de Nacimiento")]
        public System.DateTime fecha_nac { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Lugar de Nacimiento")]
        [StringLength(25, ErrorMessage = "La longitud maxima es de 25")]
        public string lugar_nac { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Direccion")]
        [StringLength(50, ErrorMessage = "La longitud maxima es de 50")]
        public string direccion { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Telefono de Casa")]
        [StringLength(25, ErrorMessage = "La longitud maxima es de 25")]
        public string tel_casa { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Telefono Celular")]
        [StringLength(25, ErrorMessage = "La longitud maxima es de 25")]
        public string tel_celular { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Correo Electronico")]
        [StringLength(30, ErrorMessage = "La longitud maxima es de 30")]
        public string correo { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "RFC")]
        [StringLength(15, ErrorMessage = "La longitud maxima es de 15")]
        public string rfc { get; set; }

        
        [Display(Name = "Numero de Visitas")]
        public Nullable<int> numVisita { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<consumo> consumo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<factura> factura { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registro> registro { get; set; }
    }
}