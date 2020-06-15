using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hotelv3.Models
{
    [MetadataType(typeof(registrosMetaData))]
    public partial class registro
    {
    }

    public class registrosMetaData
    {
        [Display(Name ="id Registro")]
        public int idRegistro { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "id Huesped")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int idHuesped { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "id Habitacion")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int idHabitacion { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime fecha { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Hora")]
        [DataType(DataType.Time)]
        public System.TimeSpan hora { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Display(Name = "Dias")]
        public int dias { get; set; }

        [Display(Name = "Descuento")]
        public Nullable<int> descuento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<factura> factura { get; set; }
        public virtual habitacion habitacion { get; set; }
        public virtual huesped huesped { get; set; }
    }
}