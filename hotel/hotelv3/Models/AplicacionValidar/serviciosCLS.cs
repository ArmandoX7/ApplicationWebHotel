using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace hotelv3.Models
{
    [MetadataType(typeof(serviciosMetaData))]
    public partial class servicio
    {
        

    }

    public class serviciosMetaData
    {

        [ScaffoldColumn(true)]
        [Display(Name = "id Servicio")]
        public int idServicio { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Tipo")]
        [StringLength(10, ErrorMessage = "La longitud maxima es de 10")]
        public string tipo { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Descripcion")]
        [StringLength(50, ErrorMessage = "La longitud maxima es de 50")]
        public string descripcion { get; set; }
        
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> fecha { get; set; }

        [Display(Name = "Hora")]
        [DataType(DataType.Time)]
        public Nullable<System.TimeSpan> hora { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Display(Name = "Costo")]
        public int costo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<consumo> consumo { get; set; }

    }
}