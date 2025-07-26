using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Stream.Models;

namespace Stream.Interfaces
{
    public interface IClienteService
    {
        Task<object> AdicionarCLienteAsync(Cliente cliente);
        Task<bool> EditarClienteAsync(int id,Cliente clienteUpdate);

        Task<bool> AtualizarAssinaturaCliente(int id, Cliente clientesign);

        Task<bool> DeletarClienteAsync(int id);
        
    }

    
}