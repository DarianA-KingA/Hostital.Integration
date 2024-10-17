using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Integration.Models
{
    public class Transacciones:BaseEntity
    {

        public int TransaccionesId { get; set; }
        [Required]
        public string IdCajero { get; set; }
        [Required]
        public string IdPaciente { get; set; }
        [Required]
        public int IdTipoTransaccion { get; set; }
        [Required]
        public int IdEstadoTransaccion { get; set; }
        [Required]
        public double Monto { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }


    }
}
