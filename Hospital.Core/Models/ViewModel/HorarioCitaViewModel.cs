namespace Hospital.Core.Models.ViewModel
{
    public class HorarioCitaViewModel
    {
        public int Id { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public bool Estado { get; set; }
    }
}
