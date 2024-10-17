using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Core.Models.ViewModel
{
    public class CitaViewModel
    {
        public int Id { get; set; }
        public string NombrePaciente { get; set; }
        public string IdPaciente { get; set; }
        public int IdServicio { get; set; }
        public string NombreServicio { get; set; }
        public string HorarioCita { get; set; }
        public DateTime FechaAgendada { get; set; }
        public bool Estado { get; set; }

    }
}
