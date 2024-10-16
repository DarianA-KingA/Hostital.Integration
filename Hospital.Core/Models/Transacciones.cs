using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Core.Models
{
    public class Transacciones:BaseEntity
    {
        [Required]
        public int IdCajero { get; set; }
        [Required]
        public int IdPaciente { get; set; }
        [Required]
        public int IdServicio { get; set; }
        [Required]
        [ForeignKey(nameof(TipoTransacciones))]
        public int TipoTransaccion { get; set; }
        [Required]
        [ForeignKey(nameof(EstadoTransacciones))]
        public int EstadoTransaccion { get; set; }
        [Required]
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        [Required]
        [ForeignKey(nameof(Citas))]
        public int IdCita { get; set; }

        #region Navigation Properties
        public virtual TipoTransaccion TipoTransacciones { get; set; }
        public virtual EstadoTransaccion EstadoTransacciones { get; set; }
        public virtual Citas Citas { get; set; }


        #endregion
    }
}
