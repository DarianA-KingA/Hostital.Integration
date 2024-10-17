using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Core.Models
{
    public class Citas:BaseEntity
    {
        [Required]
        [ForeignKey(nameof(Usuario))]
        public string IdPaciente { get; set; }
        [Required]
        [ForeignKey(nameof(Servicios))]
        public int IdServicio { get; set; }
        [Required]
        public DateTime FechaAgendada { get; set; }

        [Required]
        [ForeignKey(nameof(HorariosCitas))]
        public int idHorarioCita { get; set; }

        #region Navigation properties
        public virtual ApplicationUser Usuario { get; set; }
        public virtual Servicios Servicios { get; set; }
        public virtual HorariosCitas HorariosCitas { get; set; }
        #endregion
    }
}
