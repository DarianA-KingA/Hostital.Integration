using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Integration.Models
{
    public class Citas:BaseEntity
    {
        [Required]
        [ForeignKey(nameof(Usuario))]
        public int IdPaciente { get; set; }
        [Required]
        [ForeignKey(nameof(Servicios))]
        public int IdServicio { get; set; }
        [Required]
        [ForeignKey(nameof(Transacciones))]
        public int IdTransaccion { get; set; }
        public DateTime FechaAgendada { get; set; }

        #region Navigation properties
        public virtual Usuario Usuario { get; set; }
        public virtual Servicios Servicios { get; set; }
        public virtual Transacciones Transacciones { get; set; }
        #endregion
    }
}
