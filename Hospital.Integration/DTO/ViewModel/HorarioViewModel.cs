using System.ComponentModel.DataAnnotations;

namespace Hospital.Integration.DTO.ViewModel
{
    public class HorarioViewModel
    {
        public int Id { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public bool Estado { get; set; }
    }
}
