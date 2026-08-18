using _04_Domain.Entities;

namespace _04_Domain.Interfaces
{
    public interface IFuncionarioRepository
    {
        public Task<List<Funcionario>> GetAllAsync();

        public Task<Funcionario> GetByIdAsync(int id);

        public Task AddAsync(Funcionario funcionario);

        public Task UpdateAsync(int id);

        public Task DeleteAsync(Funcionario funcionario);

        public Task SaveChangesAsync();
    }
}