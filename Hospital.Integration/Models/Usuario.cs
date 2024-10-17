using Hospital.Integration.DTO.SaveViewModel;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Integration.Models
{
    public class Usuario:BaseEntity
    {
        public string UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string Cedula { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string RoleName { get; set; }


    }

}
