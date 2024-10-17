using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models
{
    public class HorariosCitas:BaseEntity
    {
        [Required]
        public TimeSpan HoraInicio { get; set; }
        [Required]
        public TimeSpan HoraFin { get; set; }

        public virtual ICollection<Citas> Citas { get; set; }
    }
}
