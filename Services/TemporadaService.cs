using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stream.Data;
using Stream.Interfaces;
using Stream.Models;

namespace Stream.Services
{
    public class TemporadaService : ITemporadaService
    {
        
        private readonly AppDbContext _context;
        public TemporadaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<object> AddTemporadaNaSerie(TemporadaDTO dto)
        {
            var serie = await _context.Series
            .Include(s => s.Temporadas)
            .FirstOrDefaultAsync(s => s.Id == dto.SerieId);

            if (serie == null)
            {
                return $"Serie com Id{dto.SerieId} não encontrada !";
            }

            var novaTemporada = new Temporada
            {
                Numero = dto.Numero,
                Titulo = dto.Titulo,
                SerieId = dto.SerieId
            };

            serie.Temporadas.Add(novaTemporada);

            _context.Temporadas.Add(novaTemporada);
            await _context.SaveChangesAsync();

            return new TemporadaResponseDTO
            {
                Id = novaTemporada.Id,
                Numero = novaTemporada.Numero,
                Titulo = novaTemporada.Titulo,
                SerieId = novaTemporada.SerieId
            };

        }

        public async Task<IEnumerable<TemporadaResponseDTO>> ListarTemporadas(int serieId)
        {
            var temporadas = await _context.Temporadas
            .Where(t => t.SerieId == serieId)
            .Include(t => t.Episodios)
            .ToListAsync();

            return temporadas.Select(t => new TemporadaResponseDTO
            {
                Id = t.Id,
                Numero = t.Numero,
                Titulo = t.Titulo,
                Episodios = t.Episodios.Select(e => new EpisodioResponseDTO
                {
                    Id = e.Id,
                    Numero = e.Numero,
                    Duracao = e.Duracao

                }).ToList()
            });
        }

        
    }
}