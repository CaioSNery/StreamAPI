using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stream.Models;

namespace Stream.Maps
{
    public class SerieMap : IEntityTypeConfiguration<Serie>
    {
        public void Configure(EntityTypeBuilder<Serie> builder)
        {
            builder.ToTable("Series");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Titulo)
            .IsRequired()
            .HasMaxLength(100);

            
        }
    }
}