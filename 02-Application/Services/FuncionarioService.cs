using _02_Application.DTOs;
using _02_Application.Interfaces;
using _04_Domain.Entities;
using _04_Domain.Interfaces;

namespace _02_Application.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<List<FuncionarioOutputDto>> GetAllAsync()
        {
            List<Funcionario> listaFuncionarios = await _funcionarioRepository.GetAllAsync();
            List<FuncionarioOutputDto> funcionariosOutput = [];

            foreach (var funcionario in listaFuncionarios)
            {
                FuncionarioOutputDto funcionarioDto = new FuncionarioOutputDto
                {
                    Id = funcionario.Id,
                    Name = funcionario.Name,
                    Department = funcionario.Department,
                    Position = funcionario.Position,
                    Salary = funcionario.Salary,
                    IsActive = funcionario.IsActive
                };

                funcionariosOutput.Add(funcionarioDto);
            }

            return funcionariosOutput;
        }

        public async Task<FuncionarioOutputDto?> GetByIdAsync(int id)
        {
            Funcionario? funcionario = await _funcionarioRepository.GetByIdAsync(id);

            if (funcionario == null)
            {
                throw new KeyNotFoundException();
            }

            FuncionarioOutputDto funcionarioDto = new FuncionarioOutputDto
            {
                Id = funcionario.Id,
                Name = funcionario.Name,
                Department = funcionario.Department,
                Position = funcionario.Position,
                Salary = funcionario.Salary,
                IsActive = funcionario.IsActive
            };

            return funcionarioDto;
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

            await _funcionarioRepository.AddAsync(newEmployee);
        }

        public async Task UpdateAsync(int id, FuncionarioInputDto dto)
        {
            Funcionario? funcionario = await _funcionarioRepository.GetByIdAsync(id);

            if (funcionario == null)
            {
                throw new KeyNotFoundException();
            }

            funcionario.Name = dto.Name;
            funcionario.Position = dto.Position;
            funcionario.Salary = dto.Salary;
            funcionario.Department = dto.Department;
            await _funcionarioRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Funcionario? funcionario = await _funcionarioRepository.GetByIdAsync(id);

            if (funcionario == null)
            {
                throw new KeyNotFoundException();
            }

            await _funcionarioRepository.DeleteAsync(funcionario);
        }
    }
}