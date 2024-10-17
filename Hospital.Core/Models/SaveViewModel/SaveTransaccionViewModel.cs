using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models.SaveViewModel
{
    public class SaveTransaccionViewModel
    {
        public int Id { get; set; }
        [Required]
        public string IdCajero { get; set; }
        [Required]
        public string IdPaciente { get; set; }
        [Required]
        public int IdTipoTransaccion { get; set; }
        [Required]
        public int IdEstadoTransaccion { get; set; }
        //[Required]
        //public int IdCita { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Monto { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comentario { get; set; }
        public bool Estado { get; set; }
    }
}
