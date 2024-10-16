using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models
{
    public class TipoServicio:BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }
        #region Navigation propeties
        [ValidateNever]
        public  virtual ICollection<Servicios> Servicios { get; set; }
        #endregion
    }
}
