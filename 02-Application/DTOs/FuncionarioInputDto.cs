using System.ComponentModel.DataAnnotations;

namespace _02_Application.DTOs
{
    public class FuncionarioInputDto
    {
        [Required(ErrorMessage = "Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Position field is required.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Salary field is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Salary must be greather than zero.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Department field is required.")]
        public string Department { get; set; }
    }
} 