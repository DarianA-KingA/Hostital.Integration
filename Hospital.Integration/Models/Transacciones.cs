using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Integration.Models
{
    public class Transacciones:BaseEntity
    {
        [Required]
        [ForeignKey(nameof(Cajero))]
        public int IdCajero { get; set; }
        [Required]
        public int IdPaciente { get; set; }
        [Required]
        [ForeignKey(nameof(Servicios))]
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

        #region Navigation Properties
        public virtual Usuario Cajero { get; set; } // Propiedad de navegación para el Cajero (Usuario)
        public virtual Servicios Servicios { get; set; }
        public virtual TipoTransaccion TipoTransacciones { get; set; }
        public virtual EstadoTransaccion EstadoTransacciones { get; set; }
        //public virtual ICollection<Citas> Citas { get; set; }


        #endregion
    }
}
