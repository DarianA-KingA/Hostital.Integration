using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models
{
    public class TipoTransaccion:BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }
        #region Navigation propeties
        public ICollection<Transacciones> Transacciones { get; set; }
        #endregion
    }
}
