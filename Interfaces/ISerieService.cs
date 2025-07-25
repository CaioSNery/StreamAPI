using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stream.Models;

namespace Stream.Interfaces
{
    public interface ISerieService
    {
        Task<object> CriarSerieAsync(SerieDTO dto);
        Task<bool> DeletarSerieAsync(int id);
        Task<bool> EditarSerieAsync(int id,Serie serieupdate);

    }
}