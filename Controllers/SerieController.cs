using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stream.Data;
using Stream.Interfaces;
using Stream.Models;

namespace Stream.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SerieController : ControllerBase
    {
        private readonly ISerieService _service;
        
        public SerieController(ISerieService service)
        {
            _service = service;
             
        }

        [HttpPost]
        public async Task<IActionResult> AddSerie([FromBody] SerieDTO dto)
        {
             var resultado = await _service.CriarSerieAsync(dto);

            if (resultado is string erro) return BadRequest(erro);

              return Ok(new { mensagem = "Série adicionada com sucesso!" });

        }

        [HttpDelete("serie{id}")]
        public async Task<IActionResult> DeletarSerie(int id)
        {
            var resultado = await _service.DeletarSerieAsync(id);
            if (!resultado) return NotFound("404");
            return Ok("Serie apagada!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSerie(int id, [FromBody] Serie serie)
        {
            var resultado = await _service.EditarSerieAsync(id, serie);
            if (!resultado) return NotFound();

            return Ok("Serie atualizada com sucesso");
        }
        
    }
}