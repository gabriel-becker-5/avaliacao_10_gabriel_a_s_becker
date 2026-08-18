namespace _02_Application.DTOs
{
    public class FuncionarioOutputDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
        public bool IsActive { get; set; }
    }
}