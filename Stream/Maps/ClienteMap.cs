using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stream.Models;

namespace Stream.Maps
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(c => c.Senha).IsRequired();
            builder.Property(c => c.Cpf).IsRequired()
            .HasMaxLength(11);

            builder.Property(c=>c.Email).IsRequired();
        }
    }
}