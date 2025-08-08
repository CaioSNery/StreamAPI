using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stream.Data;
using Stream.Interfaces;
using Stream.Models;

namespace Stream.Services
{
    public class ClienteService : IClienteService
    {

        private readonly AppDbContext _appDb;
        private readonly IEmailService _emailService;

        public ClienteService(AppDbContext appDb, IEmailService emailService)
        {
            _appDb = appDb;
            _emailService = emailService;
        }

        public async Task<object> AdicionarCLienteAsync(Cliente cliente)
        {
            _appDb.Clientes.Add(cliente);
            await _appDb.SaveChangesAsync();

            var mensagem = $@"
            <h2>Olá, {cliente.Nome}!</h2>
            <p>Seu cadastro foi realizado com sucesso na nossa plataforma <strong>Filmes&Series</strong>.</p>
            <p>Planos com Preços exclusivo para novos assinantes!</p>
            <p>Seja bem-vindo(a)!</p>";


            await _emailService.EnviarEmailAsync(cliente.Email, "Cadastro confirmado", mensagem);
            return cliente;
        }

        public async Task<bool> AtualizarAssinaturaCliente(int id, Cliente clientesign)
        {
            var cliente = await _appDb.Clientes.FindAsync(id);
            if (cliente == null) return false;

            cliente.Assinante = clientesign.Assinante;


            await _appDb.SaveChangesAsync();

            var mensagem = $@"
            <h2>Olá, {cliente.Nome}!</h2>
            <p>Sua Conta esta com a assinatura vencida em nossa plataforma <strong>Filmes&Series</strong>.</p>
            <p>Entre em contato para conhecer nossos planos ou atualizar o ja ativo.</p>
            <p>Te Esperamos de volta!</p>";


            await _emailService.EnviarEmailAsync(cliente.Email, "Atualização de Conta", mensagem);
            return true;



        }

        public async Task<bool> DeletarClienteAsync(int id)
        {
            var cliente = _appDb.Clientes.Find(id);
            if (cliente == null) return false;
            _appDb.Clientes.Remove(cliente);
            await _appDb.SaveChangesAsync();

            return true;

        }

        public async Task<bool> EditarClienteAsync(int id, Cliente clienteUpdate)
        {
            var cliente = await _appDb.Clientes.FindAsync(id);
            if (cliente == null) return false;

            cliente.Nome = clienteUpdate.Nome;
            cliente.Email = clienteUpdate.Email;
            cliente.Senha = clienteUpdate.Senha;
            cliente.Cpf = clienteUpdate.Cpf;



            await _appDb.SaveChangesAsync();



            var mensagem = $@"
            <h2>Olá, {cliente.Nome}!</h2>
            <p>Seu cadastro foi alterado com sucesso na nossa plataforma <strong>Filmes&Series</strong>.</p>
            <p>Se Nao reconhece essa mudança,entre em contato com a nossa central!</p>
            <p>Seja bem-vindo(a)!</p>";


            await _emailService.EnviarEmailAsync(cliente.Email, "Cadastro confirmado", mensagem);
            return true;


        }


    }
}