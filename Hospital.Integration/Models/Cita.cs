using System.ComponentModel.DataAnnotations;

namespace Hospital.Integration.Models
{
    public class Cita:BaseEntity
    {
        public int IdCita { get; set; }
        [Required]
        public string IdPaciente { get; set; }
        [Required]
        public int IdServicio { get; set; }
        [Required]
        public DateTime FechaAgendada { get; set; }
        [Required]
        public int IdHorarioCita { get; set; }
    }
}
