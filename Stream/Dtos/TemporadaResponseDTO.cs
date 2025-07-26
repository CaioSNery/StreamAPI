using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stream.Models
{
    public class TemporadaResponseDTO
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Titulo { get; set; }
        public int SerieId { get; set; }

    public List<EpisodioResponseDTO> Episodios { get; set; }
    }
}