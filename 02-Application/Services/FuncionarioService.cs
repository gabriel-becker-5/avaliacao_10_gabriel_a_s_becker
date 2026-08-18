using _02_Application.DTOs;
using _02_Application.Interfaces;
using _04_Domain.Entities;

namespace _02_Application.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioService(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        public async Task<List<FuncionarioOutputDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<FuncionarioOutputDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(FuncionarioInputDto dto)
        {
            Funcionario newEmployee = new Funcionario
            {
                Name = dto.Name,
                Department = dto.Department,
                Salary = dto.Salary,
                Position = dto.Position
            };

            // Chamar contexto e salvar no banco. Retornar cadastro criado.
            
        }

        public async Task UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}