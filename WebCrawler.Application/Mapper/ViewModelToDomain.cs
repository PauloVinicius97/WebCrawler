using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Application.ViewModels;
using WebCrawler.Domain.Entities;

namespace WebCrawler.Application.Mapper
{
    public static class ViewModelToDomain
    {
        public static Processo Processo(ProcessoViewModel processoViewModel)
        {
            var processo = new Processo(
                processoViewModel.NumeroProcesso,
                processoViewModel.Classe,
                processoViewModel.Area,
                processoViewModel.Assunto,
                processoViewModel.Origem,
                processoViewModel.Distribuicao,
                processoViewModel.Relator);

            var cultureInfo = new System.Globalization.CultureInfo("pt-BR");

            foreach (var movimentacaoViewModel in processoViewModel.Movimentacoes)
            {
                var movimentacao = new Movimentacao(
                processo.NumeroProcesso,
                    DateTime.Parse(movimentacaoViewModel.Data, cultureInfo),
                    movimentacaoViewModel.Descricao,
                    movimentacaoViewModel.Detalhes);

                processo.Movimentacoes.Add(movimentacao);
            }

            return processo;
        }
    }
}
