using Microsoft.EntityFrameworkCore;
using GerenciadorDeTarefas.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GerenciadorDeTarefas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Mapear o DbSet para a entidade Tarefa
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração adicional de mapeamento, se necessário (usuario para tarefa, login para tarefa, etc...)
        }
    }
}
