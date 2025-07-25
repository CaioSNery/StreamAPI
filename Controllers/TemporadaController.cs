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
    public class TemporadaController : ControllerBase
    {
        private readonly ITemporadaService _service;
        public TemporadaController(ITemporadaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Listar(int serieId)
        {
            var temporadas = await _service.ListarTemporadas(serieId);
            return Ok(temporadas);
        }

        [HttpPost]
        public async Task<IActionResult> CriarNovaTemporada([FromBody] TemporadaDTO dto)
        {
            var resultado = await _service.AddTemporadaNaSerie(dto);
            return Ok(resultado);
        }  
    }
}