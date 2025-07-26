using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stream.Interfaces;
using Stream.Models;

namespace Stream.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpisodioController : ControllerBase
    {
        private readonly IEpisodioService _service;
        public EpisodioController(IEpisodioService service)
        {
            _service = service;
        }

        [HttpGet("temporadas/{temporadaId}/episodios")]
        public async Task<IActionResult> ListarPorTemporada(int temporadaId)
        {
            var episodios = await _service.ListarEpisodiosAsync(temporadaId);
            return Ok(episodios);
        }

        [HttpGet("episodios{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var episodio = await _service.BuscarEpPorIdAsync(id);
            if (episodio == null) return NotFound();

            return Ok(episodio);
        }

        [HttpPost("assistir")]
        public async Task<IActionResult> RegistrarVisualizacao([FromQuery] int idCliente, [FromQuery] int idEpisodio)
        {
            var resultado = await _service.RegistrarVisualizaçaoSerie(idCliente, idEpisodio);
            if (resultado is string erro) return BadRequest(erro);

            return Ok("Visualização Registrada!");
        }

        [HttpPost]
        public async Task<IActionResult> CriarEpisodio([FromBody] EpisodioDTO dto)
        {
            var resultado = await _service.AddEpisodioNaSerie(dto);
            return Ok(resultado);
        }
    }
}