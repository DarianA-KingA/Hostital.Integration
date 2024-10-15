using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models
{
    public class AreasMedicas:BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }
        #region Navigation propeties
        public virtual ICollection<Servicios> Servicios { get; set; }
        #endregion
    }
}

