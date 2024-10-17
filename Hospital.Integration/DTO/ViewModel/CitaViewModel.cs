namespace Hospital.Integration.DTO.ViewModel
{
    public class CitaViewModel
    {
        public int Id { get; set; }
        public string IdPaciente { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaAgendada { get; set; }
        public int IdHorarioCita { get; set; }
        public bool Estado { get; set; }
    }
}
