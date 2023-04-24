using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Application.ViewModels
{
    public class ProcessoViewModel
    {
        public string NumeroProcesso { get; set; }
        public string Classe { get; set; }
        public string Area { get; set; }
        public string Assunto { get; set; }
        public string Origem { get; set; }
        public string Distribuicao { get; set; }
        public string Relator { get; set; }

        public List<MovimentacaoViewModel> Movimentacoes { get; set; }

        public ProcessoViewModel()
        {
            NumeroProcesso = String.Empty;
            Classe = String.Empty;
            Area = String.Empty;
            Assunto = String.Empty;
            Origem = String.Empty;
            Distribuicao = String.Empty;
            Relator = String.Empty;
            Movimentacoes = new List<MovimentacaoViewModel>();
        }
    }
}
