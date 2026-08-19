using _03_Infrastructure.Data;
using _04_Domain.Entities;
using _04_Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _03_Infrastructure.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly AppDbContext _context;

        public FuncionarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Funcionario>> GetAllAsync()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        public async Task<Funcionario> GetByIdAsync(int id)
        {
            return await _context.Funcionarios.FindAsync(id);
        }

        public async Task<Funcionario> AddAsync(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();
            return funcionario;
        }

        public void UpdateAsync(Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);
        }

        public async Task DeleteAsync(Funcionario funcionario)
        {
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}