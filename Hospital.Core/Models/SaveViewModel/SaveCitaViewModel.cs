using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models.SaveViewModel
{
    public class SaveCitaViewModel
    {
        public int Id { get; set; }
        [Required]
        public string IdPaciente { get; set; }
        [Required]
        public int IdServicio { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaAgendada { get; set; }
        public int idHorarioCita { get; set; }

        public bool Estado { get; set; }
    }
}
