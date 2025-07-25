using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stream.Models;

namespace Stream.Maps
{
    public class VisualizacaoFilmeMap : IEntityTypeConfiguration<VizualizacaoFIlme>
    {
        public void Configure(EntityTypeBuilder<VizualizacaoFIlme> builder)
        {
            builder.ToTable("VisualizacoesFilmes");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.DataHora).IsRequired();

            builder.HasOne(v => v.Cliente)
            .WithMany()
            .HasForeignKey(v => v.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(v => v.Filme)
            .WithMany()
            .HasForeignKey(v => v.FilmeId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}