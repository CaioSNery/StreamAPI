using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stream.Data;
using Stream.Interfaces;
using Stream.Models;

namespace Stream.Services
{
    public class FilmeService:IFilmeService
    {
        private readonly AppDbContext _context;
        public FilmeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<object> AddFilmeAsync(FilmeDTO dto)
        {
            var filme = new Filme
            {
                Titulo = dto.Titulo,
                Ano = dto.Ano,
                Genero = dto.Genero,
                Duracao=dto.Duracao
            };

            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();

            return filme;
        }

        public async Task<bool> DeletarFilmeAsync(int id)
        {
            var filme = _context.Filmes.Find(id);
            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditarFilmeAsync(int id, Filme filmeupdate)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null) return false;

            filme.Titulo = filmeupdate.Titulo;
            filme.Genero = filme.Genero;
            filme.Ano = filmeupdate.Ano;
            filme.Duracao = filmeupdate.Duracao;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<object> RegistrarVisualizacaoFilme(int idCliente, int idFilme)
        {
            var cliente = await _context.Clientes.FindAsync(idCliente);
            var filme = await _context.Filmes.FindAsync(idFilme);

            if (cliente == null || filme == null) return false;
            if (cliente.Assinante == false)
            {
                return "Cliente com assinatura pendente";
            }

            var visualizacao = new VizualizacaoFIlme
            {
                ClienteId = cliente.Id,
                FilmeId = filme.Id,
                DataHora = DateTime.Now
            };

            _context.VizualizacaoFIlmes.Add(visualizacao);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}