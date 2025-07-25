using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stream.Interfaces;

namespace Stream.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViewController : ControllerBase
    {
        private readonly IViewService _context;
        public ViewController(IViewService context)
        {
            _context = context;
        }

        [HttpGet("filmes")]
        public async Task<IActionResult> ListarFilmes()
        {
            var filmes = await _context.ListarFilmesAsync();
            return Ok(filmes);
        }

        [HttpGet("filmes{id}")]
        public async Task<IActionResult> EscolherFilmeById(int id)
        {
            var filme = await _context.SelecionarFilmeId(id);
            if (filme == null) return NotFound();
            return Ok(filme);
        }

        [HttpGet("series")]
        public async Task<IActionResult> ListarSeries()
        {
            var series = await _context.ListarSeriesAsync();
            return Ok(series);
        }

        [HttpGet("serie{id}")]
        public async Task<IActionResult> EscolherSerieById(int id)
        {
            var serie = await _context.SelecionarSerieId(id);
            if (serie == null) return NotFound();
            return Ok(serie);
        }

    }
}