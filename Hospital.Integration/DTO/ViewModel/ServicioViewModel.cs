namespace Hospital.Integration.DTO.ViewModel
{
    public class ServicioViewModel
    {
        public int Id { get; set; }
        public int IdAreaMedica { get; set; }
        public int IdTipoServicio { get; set; }
        public double Costo { get; set; }
        public bool Estado { get; set; }
        public AreasMedicasViewModel AreasMedicas { get; set; }
        public TipoServicioViewModel TipoServicio { get; set; }
    }
}
