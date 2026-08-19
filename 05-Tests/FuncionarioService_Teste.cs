using _02_Application.DTOs;
using _03_Infrastructure.Data;
using _03_Infrastructure.Repositories;
using _04_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using _02_Application.Services;

namespace _05_Tests
{
    public class FuncionarioService_Teste
    {
        private AppDbContext CriarContextoDeTeste()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        private FuncionarioService CriarFuncionarioRepositoryServiceTeste(AppDbContext context)
        {
            var repository = new FuncionarioRepository(context);
            var service = new FuncionarioService(repository);
            return service;
        }

        [Fact]
        public async Task GetAllAsync_DeveRetornarFuncionariosCadastrados()
        {
            // Arrange
            var context = CriarContextoDeTeste();
            context.Funcionarios.Add(new Funcionario
            {
                Name = "Jorge",
                Position = "Analista de Marketing",
                Department = "Marketing",
                Salary = 2500.00m
            });

            context.Funcionarios.Add(new Funcionario
            {
                Name = "Paulo",
                Position = "Analista de Contas a Pagar",
                Department = "Financeiro",
                Salary = 2690.00m
            });

            await context.SaveChangesAsync();
            var service = CriarFuncionarioRepositoryServiceTeste(context);

            // Act
            List<FuncionarioOutputDto> resultado = await service.GetAllAsync();

            // Assert
            Assert.Equal(2, resultado.Count);
        }

        [Fact]
        public async Task GetByIdAsync_IdInexistente_DeveLancarKeyNotFoundException()
        {
            // Arrange
            var context = CriarContextoDeTeste();
            var service = CriarFuncionarioRepositoryServiceTeste(context);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => service.GetByIdAsync(999));
        }

        [Fact]
        public async Task CreateAsync_DeveSalvarERetornarFuncionario()
        {
            // Arrange
            var context = CriarContextoDeTeste();
            var service = CriarFuncionarioRepositoryServiceTeste(context);

            FuncionarioInputDto novoFuncionario = new FuncionarioInputDto
            {
                Name = "Teste",
                Department = "Teste",
                Position = "Teste",
                Salary = 999.99m
            };

            // Act
            var resultado = await service.CreateAsync(novoFuncionario);

            // Assert
            Assert.True(resultado.Id > 0);
        }
    }
}