using System.ComponentModel.DataAnnotations;

namespace Hospital.Integration.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool Estado { get; set; }
    }
}
