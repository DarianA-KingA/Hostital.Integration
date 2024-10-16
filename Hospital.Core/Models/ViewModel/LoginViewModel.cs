using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Passsword { get; set; }
        
    }
}
