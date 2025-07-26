using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stream.Models
{
    public class Visualizacao
    {
        public int Id { get; set; }

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }

    public int EpisodioId { get; set; }
    public Episodio Episodio { get; set; }

    public DateTime DataHora { get; set; } = DateTime.Now;
    }
}