using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Application.ViewModels;

namespace WebCrawler.Domain.Entities
{
    public class Processo
    {
        public string NumeroProcesso { get; private set; }
        public string Classe { get; private set; }
        public string Area { get; private set; }
        public string Assunto { get; private set; }
        public string Origem { get; private set; }
        public string Distribuicao { get; private set; }
        public string Relator { get; private set; }

        public List<Movimentacao> Movimentacoes { get; private set; }

        public Processo(string numeroProcesso,
            string classe,
            string area,
            string assunto,
            string origem,
            string distribuicao,
            string relator,
            List<Movimentacao> movimentacoes)
        {
            NumeroProcesso = numeroProcesso;
            Classe = classe;
            Area = area;
            Assunto = assunto;
            Origem = origem;
            Distribuicao = distribuicao;
            Relator = relator;
            Movimentacoes = movimentacoes;
        }

        public Processo(string numeroProcesso, 
            string classe, 
            string area, 
            string assunto, 
            string origem, 
            string distribuicao, 
            string relator)
        {
            NumeroProcesso = numeroProcesso;
            Classe = classe;
            Area = area;
            Assunto = assunto;
            Origem = origem;
            Distribuicao = distribuicao;
            Relator = relator;
            Movimentacoes = new List<Movimentacao>();
        }
    }
}
