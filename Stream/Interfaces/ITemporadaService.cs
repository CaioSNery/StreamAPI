using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stream.Models;

namespace Stream.Interfaces
{
    public interface ITemporadaService
    {
        Task<IEnumerable<TemporadaResponseDTO>> ListarTemporadas(int serieId);

        Task<object> AddTemporadaNaSerie(TemporadaDTO dto);
        
    }
}