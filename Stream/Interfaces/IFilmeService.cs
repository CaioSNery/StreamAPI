using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Stream.Models;

namespace Stream.Interfaces
{
    public interface IFilmeService
    {
        Task<object> AddFilmeAsync(FilmeDTO dto);
        Task<bool> DeletarFilmeAsync(int id);
        Task<bool> EditarFilmeAsync(int id, Filme filmeupdate);
        Task<object> RegistrarVisualizacaoFilme(int idCliente, int idFilme);
    }
}