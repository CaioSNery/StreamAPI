using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stream.Models
{
    public class VizualizacaoFIlme
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int FilmeId { get; set; }
        public Filme Filme{ get; set; }

        public DateTime DataHora { get; set; } = DateTime.Now;

    }
}