using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hotelv3.Models
{
    [MetadataType(typeof(satisfaccionesMetaData))]
    public partial class satisfaccion
    {
    }

    public class satisfaccionesMetaData
    {
        [Display(Name ="id Satisfaccion")]
        public int idSatisfaccion { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Descripcion")]
        [StringLength(100, ErrorMessage = "La longitud maxima es de 100")]
        public string descripcion { get; set; }

        [Display(Name = "Calificacion")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public Nullable<int> calificacion { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> fecha { get; set; }

        [Display(Name = "Hora")]
        [DataType(DataType.Time)]
        public Nullable<System.TimeSpan> hora { get; set; }
    }
}