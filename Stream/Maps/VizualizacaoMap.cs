using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stream.Models;

using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Stream.Maps
{
    public class VizualizacaoMap : IEntityTypeConfiguration<Visualizacao>
    {
        public void Configure(EntityTypeBuilder<Visualizacao> builder)
        {
            builder.ToTable("Visualizacoes");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.DataHora).IsRequired();

            builder.HasOne(v => v.Cliente)
            .WithMany()
            .HasForeignKey(v => v.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(v => v.Episodio)
            .WithMany()
            .HasForeignKey(v => v.EpisodioId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}