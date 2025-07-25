using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stream.Models;

namespace Stream.Interfaces
{
    public interface IEpisodioService
    {
        Task<IEnumerable<Episodio>> ListarEpisodiosAsync(int temporadaId);
        Task<Episodio> BuscarEpPorIdAsync(int id);

        Task<object> RegistrarVisualizaçaoSerie(int idCliente, int idEpisodio);

        Task<object> AddEpisodioNaSerie(EpisodioDTO dto);
    }
}