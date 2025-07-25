using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stream.Maps;
using Stream.Models;

namespace Stream.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) {}


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Serie> Series { get; set; }

        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Temporada> Temporadas { get; set; }

        public DbSet<Episodio> Episodios { get; set; }
        
        public DbSet<Visualizacao> Visualizacoes{ get; set; }

        public DbSet<VizualizacaoFIlme>VizualizacaoFIlmes{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}