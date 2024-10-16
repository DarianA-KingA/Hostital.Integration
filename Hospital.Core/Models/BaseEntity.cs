using System.ComponentModel.DataAnnotations;

namespace Hospital.Core.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool Estado { get; set; }
    }
}
