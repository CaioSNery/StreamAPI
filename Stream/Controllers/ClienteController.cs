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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarCliente([FromBody] Cliente cliente)
        {
            var resultado = await _clienteService.AdicionarCLienteAsync(cliente);
            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarCliente(int id, [FromBody] Cliente cliente)
        {
            var resultado = await _clienteService.EditarClienteAsync(id, cliente);
            if (!resultado) return NotFound("Nao Encontrado");
            return Ok("Cliente atualizado com sucesso!");
        }

        [HttpPut("AssinaturaCliente")]
        public async Task<IActionResult> AtualizarAssinatura(int id, [FromBody] Cliente clientesign)
        {
            var resultado = await _clienteService.AtualizarAssinaturaCliente(id, clientesign);
            if (!resultado) return NotFound();
            return Ok("Assinatura atualizada");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarCliente(int id)
        {
            var resultado = await _clienteService.DeletarClienteAsync(id);
            if (!resultado) return NotFound();
            return Ok("Conta deletada com sucesso");
        }
    }
}