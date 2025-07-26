using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stream.Models;
namespace Stream.Maps
{
    public class EpisodioMap : IEntityTypeConfiguration<Episodio>
    {
        public void Configure(EntityTypeBuilder<Episodio> builder)
        {
            builder.ToTable("Episodios");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Duracao)
            .IsRequired()
            .HasMaxLength(5);
            
        }
    }
}