using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models.ViewModel
{
    public class UserViewModel
    {

        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public string Cedula { get; set; }
        public string RoleName { get; set; }
        public bool Estado { get; set; }
    }
}
