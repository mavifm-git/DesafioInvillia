using Desafio.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Data.Mappings
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Telefone)
                .IsRequired()
                .HasColumnType("varchar(12)");

            // 1 : N => Jogo : Emprestimo
            builder.HasMany(p => p.Emprestimo)
                .WithOne(e => e.Pessoa)
                .HasForeignKey(e => e.PessoaId);


            builder.ToTable("Pessoas");
        }


    }
}