using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hotelv3.Models
{
    [MetadataType(typeof(quejasMetaData))]
    public partial class queja
    {
    }

    public class quejasMetaData
    {
        [Display(Name ="id Queja")]
        public int idQueja { get; set; }

        [Display(Name ="Descripcion")]
        [StringLength(100, ErrorMessage = "La longitud maxima es de 100")]
        public string descripcion { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> fecha { get; set; }

        [Display(Name = "Hora")]
        [DataType(DataType.Time)]
        public Nullable<System.TimeSpan> hora { get; set; }
    }
}