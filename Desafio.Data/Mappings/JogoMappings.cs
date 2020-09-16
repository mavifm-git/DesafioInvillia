using Desafio.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Data.Mappings
{
    public class JogoMappings : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");


            // 1 : N => Jogo : Emprestimo
            builder.HasMany(j => j.Emprestimo)
                .WithOne(e => e.Jogo)
                .HasForeignKey(e => e.JogoId);

            builder.ToTable("Jogos");
        }
    }
}
