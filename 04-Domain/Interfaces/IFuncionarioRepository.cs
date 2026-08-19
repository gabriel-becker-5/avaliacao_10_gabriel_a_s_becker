using _04_Domain.Entities;

namespace _04_Domain.Interfaces
{
    public interface IFuncionarioRepository
    {
        public Task<List<Funcionario>> GetAllAsync();

        public Task<Funcionario> GetByIdAsync(int id);

        public Task<Funcionario> AddAsync(Funcionario funcionario);

        public void UpdateAsync(Funcionario funcionario);

        public Task DeleteAsync(Funcionario funcionario);

        public Task SaveChangesAsync();
    }
}