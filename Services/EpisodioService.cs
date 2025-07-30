using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Stream.Data;
using Stream.Interfaces;
using Stream.Models;

namespace Stream.Services
{
    public class EpisodioService : IEpisodioService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public EpisodioService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<object> AddEpisodioNaSerie(EpisodioDTO dto)
        {
            var temporada = await _context.Temporadas
            .Include(t => t.Episodios)
            .FirstOrDefaultAsync(t => t.Id == dto.TemporadaId);

            if (temporada == null)
            {
                return $"Temporada com Id{dto.TemporadaId} nao encontrado";
            }

            var novoEpisodio = new Episodio
            {
                Duracao = dto.Duracao,
                Numero = dto.Numero,
                TemporadaId = temporada.Id
            };

            temporada.Episodios.Add(novoEpisodio);

            _context.Episodios.Add(novoEpisodio);
            await _context.SaveChangesAsync();

            return _mapper.Map<EpisodioResponseDTO>(novoEpisodio);
        }

        public async Task<Episodio> BuscarEpPorIdAsync(int id)
        {
            return await _context.Episodios.FindAsync(id);
        }

        public async Task<IEnumerable<Episodio>> ListarEpisodiosAsync(int temporadaId)
        {
            return await _context.Episodios
            .Where(e => e.TemporadaId == temporadaId)
            .ToListAsync();
        }

        public async Task<object> RegistrarVisualizaçaoSerie(int idCliente, int idEpisodio)
        {
            var cliente = await _context.Clientes.FindAsync(idCliente);
            var episodio = await _context.Episodios.FindAsync(idEpisodio);

            if (cliente == null || episodio == null) return false;
            if (cliente.Assinante == false)
            {
                return "Cliente com assinatura pendente";
            }

            var visualizacao = new Visualizacao
            {
                ClienteId = idCliente,
                EpisodioId = idEpisodio,
                DataHora = DateTime.Now

            };

            _context.Visualizacoes.Add(visualizacao);
            await _context.SaveChangesAsync();

            return true;

        }
    }
}