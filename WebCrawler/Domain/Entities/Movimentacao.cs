using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Domain.Entities
{
    public class Movimentacao
    {
        public Guid Id { get; private set; }
        public string NumeroProcesso { get; private set; }
        public DateTime Data { get; private set; }
        public string Descricao { get; private set; }
        public string Detalhes { get; private set; }

        public Movimentacao(string numeroProceso, DateTime data, string descricao, string detalhes)
        {
            Id = Guid.NewGuid();
            NumeroProcesso = numeroProceso;
            Data = data;
            Descricao = descricao;
            Detalhes = detalhes;
        }
    }
}
