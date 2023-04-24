using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Application.ViewModels
{
    public class MovimentacaoViewModel
    {
        public string Data { get; set; }
        public string Descricao { get; set; }
        public string Detalhes { get; set; }

        public MovimentacaoViewModel()
        {
            Data = String.Empty;
            Descricao = String.Empty;
            Detalhes = String.Empty;
        }
    }
}
