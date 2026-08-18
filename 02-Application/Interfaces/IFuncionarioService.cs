using _02_Application.DTOs;

namespace _02_Application.Interfaces
{
    public interface IFuncionarioService
    {
        public Task<List<FuncionarioOutputDto>> GetAllAsync();

        public Task<FuncionarioOutputDto> GetByIdAsync(int id);

        public Task CreateAsync(FuncionarioInputDto dto);

        public Task UpdateAsync(int id);
        
        public Task DeleteAsync(int id);
    }
}