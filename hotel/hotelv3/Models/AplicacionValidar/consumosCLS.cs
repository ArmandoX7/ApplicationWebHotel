using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace hotelv3.Models
{
    [MetadataType(typeof(consumosMetaData))]
    public partial class consumo
    {
    }

    public class consumosMetaData
    {
        [Display(Name = "id Usuario")]
        public int idConsumo { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "id Huesped")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int idHuesped { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "id Servicio")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int idServicio { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Cantidad")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int cantidad { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        [Display(Name = "Fecha")]
        public System.DateTime fecha { get; set; }
        [DataType(DataType.Time)]
        public System.TimeSpan hora { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<factura> factura { get; set; }
        public virtual huesped huesped { get; set; }
        public virtual servicio servicio { get; set; }
    }
}