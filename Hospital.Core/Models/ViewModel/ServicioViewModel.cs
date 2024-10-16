namespace Hospital.Core.Models.ViewModel
{
    public class ServicioViewModel
    {
        public int Id { get; set; }
        public int IdTipoServico { get; set; }
        public string DescricionTipoServcio { get; set; }
        public int IdAreaMedica { get; set; }
        public string DescripcionAreaMedica { get; set; }
        public double Costo { get; set; }
        public bool Estado { get; set; }
    }
}
