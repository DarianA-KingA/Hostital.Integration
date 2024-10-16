using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models.SaveViewModel
{
    public class SaveUpdatedUserViewModel
    {
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(100)]
        [DataType(DataType.MultilineText)]

        public string Address { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        public string Cedula { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
