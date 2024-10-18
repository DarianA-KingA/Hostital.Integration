using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.DTO
{
    public class SaveCitaViewModelDTO
    {
        public int Id { get; set; }
        public string IdPaciente { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaAgendada { get; set; }
        public int idHorarioCita { get; set; }
        public bool Estado { get; set; }
        public string Token { get; set; }
    }
}
