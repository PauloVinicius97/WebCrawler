using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Domain.Entities
{
    public class Movimentacao
    {
        public Guid Id { get; private set; }
        public string NumeroProcessoFK { get; private set; }
        public DateTime Data { get; private set; }
        public string Descricao { get; private set; }
        public string Detalhes { get; private set; }

        protected Movimentacao() { }

        public Movimentacao(string numeroProcesoFK, DateTime data, string descricao, string detalhes)
        {
            Id = Guid.NewGuid();
            NumeroProcessoFK = numeroProcesoFK;
            Data = data;
            Descricao = descricao;
            Detalhes = detalhes;
        }
    }
}
