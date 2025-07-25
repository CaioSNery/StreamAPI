using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stream.Models
{
    public class SerieDTO
    {
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public List<TemporadaDTO> Temporadas { get; set; }
        public List<EpisodioDTO> Episodios{ get; set; }
    }
}