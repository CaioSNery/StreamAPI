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
    public class ViewService : IViewService
    {

        private readonly AppDbContext _service;
        public ViewService(AppDbContext service)
        {
            _service = service;
        }

        public async Task<IEnumerable<Filme>> ListarFilmesAsync()
        {
            return await _service.Filmes
            .AsNoTracking()
            .ToListAsync();
            
        }

        public async Task<IEnumerable<Serie>> ListarSeriesAsync()
        {
            return await _service.Series
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<Filme> SelecionarFilmeId(int id)
        {
            return await _service.Filmes
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id==id);
        }

        public async Task<Serie> SelecionarSerieId(int id)
        {
            return await _service.Series
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id==id);
        }
    }
}