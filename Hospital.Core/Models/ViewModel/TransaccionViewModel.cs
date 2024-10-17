using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Core.Models.ViewModel
{
    public class TransaccionViewModel
    {
        public int Id { get; set; }
        public string NombreCajero { get; set; }
        public string NombrePaciente { get; set; }
        public string TipoTransaccion { get; set; }
        public string EstadoTransaccion { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public bool Estado { get; set; }
    }
}
