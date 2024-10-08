using System.ComponentModel.DataAnnotations;

namespace Hospital.Integration.Models
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

