using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _04_Domain.Entities
{
    public class Funcionario
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name field is required.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Position field is required.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Salary field is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Salary must be greather than zero.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Department field is required.")]
        public string Department { get; set; }
        public bool IsActive { get; set; }
    }
}