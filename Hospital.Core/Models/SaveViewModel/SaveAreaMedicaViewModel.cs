using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models.SaveViewModel
{
    public class SaveAreaMedicaViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
