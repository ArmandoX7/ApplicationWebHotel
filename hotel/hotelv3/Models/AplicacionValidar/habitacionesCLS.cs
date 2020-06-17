using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hotelv3.Models
{
    [MetadataType(typeof(habitacionesMetaData))]
    public partial class habitacion
    {
    }

    public class habitacionesMetaData
    {
        [ScaffoldColumn(false)]
        [Display(Name = "id Habitacion")]
        public int idHabitacion { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Tipo Habitacion")]
        [StringLength(30, ErrorMessage = "La longitud maxima es de 30")]
        public string tipo { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Capacidad")] 
        [StringLength(20, ErrorMessage = "La longitud maxima es de 20")]
        public string capacidad { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Disponibilidad")]
        [StringLength(15, ErrorMessage = "La longitud maxima es de 15")]
        public string disponibilidad { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Precio")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int precio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registro> registro { get; set; }
    }
}