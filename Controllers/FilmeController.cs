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
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _service;
        public FilmeController(IFilmeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddFilme([FromBody] FilmeDTO dto)
        {
            var resultado = await _service.AddFilmeAsync(dto);
            if (resultado is string erro) return BadRequest(erro);
            return Ok(resultado);
        }

        [HttpDelete("filme{id}")]
        public async Task<IActionResult> DeletarFilme(int id)
        {
            var resultado = await _service.DeletarFilmeAsync(id);
            if (!resultado) return NotFound();
            return Ok("Filme apagado!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarFilme(int id, [FromBody] Filme filmeupdate)
        {
            var resultado = await _service.EditarFilmeAsync(id, filmeupdate);
            if (!resultado) return NotFound();

            return Ok("Filme Atualizado com sucesso!");
        }

        [HttpPost("assistir")]
        public async Task<IActionResult> AssistirFilme([FromQuery] int idCliente, [FromQuery] int idFilme)
        {
            var resultado = await _service.RegistrarVisualizacaoFilme(idCliente, idFilme);
            if (resultado is string erro) return BadRequest(erro);

            return Ok("Visualização Registrada");
        }


    }
}