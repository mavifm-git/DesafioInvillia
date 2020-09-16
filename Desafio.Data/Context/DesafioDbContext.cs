using Desafio.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio.Data.Context
{
    public class DesafioDbContext: DbContext
    {


        public DesafioDbContext(DbContextOptions<DesafioDbContext> options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCriacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCriacao").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}