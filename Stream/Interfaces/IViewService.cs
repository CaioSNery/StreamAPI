using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stream.Models;

namespace Stream.Interfaces
{
    public interface IViewService
    {
        Task<Serie> SelecionarSerieId(int id);
        Task<IEnumerable<Serie>> ListarSeriesAsync();

        Task<Filme> SelecionarFilmeId(int id);
        Task<IEnumerable<Filme>> ListarFilmesAsync();

    
    }
}