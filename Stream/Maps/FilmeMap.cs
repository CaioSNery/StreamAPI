using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stream.Models;

namespace Stream.Maps
{
    public class FilmeMap : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("Filmes");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Titulo)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(f => f.Duracao).IsRequired();
            builder.Property(f => f.Genero).HasMaxLength(50);
        }
    }
}