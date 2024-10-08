using System.ComponentModel.DataAnnotations;

namespace Hospital.Integration.Models
{
    public class Usuario:BaseEntity
    {

        [Required]
        [MaxLength(100)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellidos { get; set; }

        [Required]
        [MaxLength(100)]
        public string Correo { get; set; }

        [Required]
        [MaxLength(200)]
        public string Clave { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; } 

        [Required]
        [MaxLength(11)]
        public string Cedula { get; set; }

        [Required]
        [MaxLength(250)]
        public string Direccion { get; set; }

        public DateTime FechaCreacion { get; set; } 
        public DateTime UltimaModificacion { get; set; }

        #region Navigation propeties
        public virtual ICollection<Perfiles> Perfiles { get; set; }
        public virtual ICollection<Transacciones> TransaccionesCajero { get; set; }
        public virtual ICollection<Transacciones> TransaccionesPaciente { get; set; }
        public virtual ICollection<Citas> Citas { get; set; }
        #endregion


    }

}
