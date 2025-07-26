using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stream.Models;


namespace Stream.Maps
{
    public class TemporadaMap : IEntityTypeConfiguration<Temporada>
    {
        public void Configure(EntityTypeBuilder<Temporada> builder)
        {
            builder.ToTable("Temporadas");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Numero).IsRequired();
        }
    }
}