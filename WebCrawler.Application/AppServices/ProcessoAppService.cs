using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Application.Mapper;
using WebCrawler.Application.ViewModels;
using WebCrawler.Data;

namespace WebCrawler.Application.AppServices
{
    public class ProcessoAppService
    {
        private WebCrawlerContext _context;

        public ProcessoAppService()
        {
            _context = new WebCrawlerContext();
        }

        public List<ProcessoViewModel> GetAllProcessos()
        {
            var processos = _context.Processo.Include(p => p.Movimentacoes).ToList();
            var processoViewModels = new List<ProcessoViewModel>();

            foreach (var processo in processos)
            {
                var processoViewModel = DomainToViewModel.Processo(processo);

                processoViewModels.Add(processoViewModel);
            }

            return processoViewModels;
        }

        public ResultViewModel AddProcesso(ProcessoViewModel processoViewModel)
        {
            var result = new ResultViewModel();
            result.Success = false;

            var validDates = ValidateMovements(processoViewModel.Movimentacoes);

            if (!validDates)
            { 
                result.Errors.Add("Verifique as datas das movimentações.");

                return result;
            }

            var processo = ViewModelToDomain.Processo(processoViewModel);

            try
            {
                _context.Processo.Add(processo);
                _context.SaveChanges();

                result.Success = true;
                result.Logs.Add("Processo adicionado com sucesso.");
            } 
            catch (Exception e)
            {
                result.Errors.Add(e.Message);
            }

            return result;
        }

        public ResultViewModel UpdateProcesso(string processNumber, ProcessoViewModel processoViewModel)
        {
            var resultViewModel = new ResultViewModel();
            resultViewModel.Success = false;

            var validDates = ValidateMovements(processoViewModel.Movimentacoes);

            if (!validDates)
            {
                resultViewModel.Errors.Add("Verifique as datas das movimentações.");

                return resultViewModel;
            }

            var updatedProcesso = ViewModelToDomain.Processo(processoViewModel);

            try
            {
                var processo = _context.Processo
                    .Where(p => p.NumeroProcesso.Equals(processNumber))
                    .AsNoTracking()
                    .FirstOrDefault();

                if (processo is null)
                {
                    resultViewModel.Errors.Add("Processo não existe no banco de dados.");

                    return resultViewModel;
                }
                _context.Remove(processo);
                _context.Add(updatedProcesso);
                _context.SaveChanges();

                resultViewModel.Success = true;
                resultViewModel.Logs.Add("Processo atualizado com sucesso.");
            } 
            catch (Exception e)
            {
                resultViewModel.Errors.Add(e.Message);
            }

            return resultViewModel;
        }    

        private bool ValidateMovements(List<MovimentacaoViewModel> movementViewModels)
        {
            foreach (var movimentacao in movementViewModels)
            {
                var cultureInfo = new System.Globalization.CultureInfo("pt-BR");

                var validDate = DateTime.TryParse(movimentacao.Data, cultureInfo, DateTimeStyles.None, out var dateTime);

                if (!validDate)
                {
                    return false;
                }
            }

            return true;
        }

        public ResultViewModel RemoveProcesso(string processNumber)
        {
            var resultViewModel = new ResultViewModel();
            resultViewModel.Success = false;

            try
            {
                var processo = _context.Processo.Where(p => p.NumeroProcesso.Equals(processNumber)).FirstOrDefault();

                if (processo is null)
                {
                    resultViewModel.Errors.Add("Processo não encontrado.");

                    return resultViewModel;
                }

                _context.Remove(processo);
                _context.SaveChanges();

                resultViewModel.Success = true;
                resultViewModel.Logs.Add("Processo removido com sucesso.");
            }
            catch (Exception e)
            {
                resultViewModel.Errors.Add(e.Message);
            }

            return resultViewModel;
        }
    }
}
