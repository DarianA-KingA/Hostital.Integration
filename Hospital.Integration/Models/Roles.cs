using System.ComponentModel.DataAnnotations;

namespace Hospital.Integration.Models
{
    public class Roles:BaseEntity
    {


        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(250)]
        public string Descripcion { get; set; }
        #region Navigation propeties
        public virtual ICollection<Perfiles> Perfiles { get; set; }
        #endregion
    }
}
