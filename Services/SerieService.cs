using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stream.Data;
using Stream.Interfaces;
using Stream.Models;

namespace Stream.Services
{
    public class SerieService : ISerieService
    {

        private readonly AppDbContext _context;
        public SerieService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<object> CriarSerieAsync(SerieDTO dto)
        {
            var serie = new Serie
            {
                Titulo = dto.Titulo,
                Genero=dto.Genero,
                Temporadas = dto.Temporadas.Select(t => new Temporada
            {
                Titulo = t.Titulo,
                Numero = t.Numero,
                Episodios = t.Episodios.Select(e => new Episodio
                {
                    Numero = e.Numero,
                    Duracao=e.Duracao
                }).ToList()
            }   ).ToList()
               
            };
            

                _context.Series.Add(serie);
                await _context.SaveChangesAsync();

                return serie;
        }

        public async Task<bool> DeletarSerieAsync(int id)
        {
            var serie = _context.Series.Find(id);
            _context.Series.Remove(serie);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<bool> EditarSerieAsync(int id, Serie serieupdate)
        {
            var serie = await _context.Series.FindAsync(id);
            if (serie == null) return false;

            serie.Temporadas = serieupdate.Temporadas;
            serie.Titulo = serieupdate.Titulo;

            _context.Series.Add(serie);
            await _context.SaveChangesAsync();

            return true;

        }

    }
}