using _02_Application.DTOs;
using _04_Domain.Entities;

namespace _02_Application.Interfaces
{
    public interface IFuncionarioService
    {
        public Task<List<FuncionarioOutputDto>> GetAllAsync();

        public Task<FuncionarioOutputDto> GetByIdAsync(int id);

        public Task<FuncionarioOutputDto> CreateAsync(FuncionarioInputDto dto);

        public Task UpdateAsync(int id, FuncionarioInputDto dto);
        
        public Task DeleteAsync(int id);
    }
}