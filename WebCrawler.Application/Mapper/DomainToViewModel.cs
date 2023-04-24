using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Application.ViewModels;
using WebCrawler.Domain.Entities;

namespace WebCrawler.Application.Mapper
{
    public static class DomainToViewModel
    {
        public static ProcessoViewModel Processo(Processo processo)
        {
            var processoViewModel = new ProcessoViewModel 
            { 
                NumeroProcesso = processo.NumeroProcesso,
                Classe = processo.Classe,
                Area = processo.Area,
                Assunto = processo.Assunto,
                Origem = processo.Origem,
                Distribuicao = processo.Distribuicao,
                Relator = processo.Relator
            };

            foreach (var movimentacao in processo.Movimentacoes)
            {
                var movimentacaoViewModel = new MovimentacaoViewModel
                {
                    Data = movimentacao.Data.ToString(),
                    Descricao = movimentacao.Descricao,
                    Detalhes = movimentacao.Detalhes
                };

                processoViewModel.Movimentacoes.Add(movimentacaoViewModel);
            }

            return processoViewModel;
        }
    }
}
