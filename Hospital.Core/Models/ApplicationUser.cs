using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        [MaxLength(11)]
        public string Cedula { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }
        [Required]
        public bool Estado { get; set; }

        public virtual ICollection<Citas> Citas { get; set; }

    }
}
