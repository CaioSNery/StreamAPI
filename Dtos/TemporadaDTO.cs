using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stream.Models
{
    public class TemporadaDTO
    {
        public string Titulo { get; set; }
        public int Numero { get; set; }
        
        public int SerieId{ get; set; }
         
         public List<EpisodioDTO> Episodios { get; set; }
    }
}