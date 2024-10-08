using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Integration.Models
{
    public class Perfiles:BaseEntity
    {

        [Required]
        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }
        [Required]
        [ForeignKey(nameof(Roles))]
        public int IdRol { get; set; }

        #region Navigation properties
        public virtual Usuario Usuario { get; set; }
        public virtual Roles Roles { get; set; }
        #endregion
    }
}
