using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace hotelv3.Models
{
    [MetadataType(typeof(facturasMetaData))]
    public partial class factura
    {
    }

    public class facturasMetaData
    {
        [Display(Name = "Numero de Factura")]
        public int numFactura { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Nombre del Emisor")]
        [StringLength(50, ErrorMessage = "La longitud debe ser mayor a 50 caracteres")]
        public string nombreEmisor { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Telefono Emisor")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [StringLength(20, ErrorMessage = "La longitud debe ser mayor a 20 caracter")]
        public string telEmisor { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> fecha { get; set; }
       
        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Time)]
        public Nullable<System.TimeSpan> hora { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "id Huesped")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int idHuesped { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "id Registro")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int idRegistro { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "id Consumo")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int idConsumo { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Total")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int total { get; set; }

        public virtual consumo consumo { get; set; }
        public virtual huesped huesped { get; set; }
        public virtual registro registro { get; set; }
    }
}