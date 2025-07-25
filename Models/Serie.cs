using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stream.Models
{
    public class Serie
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }

        public List<Temporada> Temporadas { get; set; } = new();
        public List<Episodio> Episodios { get; set; } = new();
    }
}