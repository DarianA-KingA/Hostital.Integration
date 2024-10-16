using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models.SaveViewModel
{
    public class SaveServicioViewModel
    {
        public int Id { get; set; }
        [Required]
        public int IdTipoServico { get; set; }
        [Required]
        public int IdAreaMedica { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Costo { get; set; }
        public bool Estado { get; set; }
    }
}
