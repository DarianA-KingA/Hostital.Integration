using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models.SaveViewModel
{
    public class SaveHorarioCitaViewModel
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan HoraInicio { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan HoraFin { get; set; }
        public bool Estado { get; set; }

    }
}
