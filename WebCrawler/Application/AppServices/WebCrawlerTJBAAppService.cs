﻿using HtmlAgilityPack;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Application.ViewModels;

namespace WebCrawler.Application.AppServices
{
    public class WebCrawlerTJBAAppService
    {
        public WebCrawlerTJBAAppService() { }

        public async Task GetProcess(string processNumber)
        {
            var htmlDocument = await GetPageContentAsHtmlDocument(processNumber);

            var processData = GetProcessData(htmlDocument);
            var movementData = GetMovementData(htmlDocument);

            var processoViewModel = GetProcessoViewModel(processNumber, processData, movementData);
        }

        private async Task<HtmlDocument> GetPageContentAsHtmlDocument(string processNumber)
        {
            using var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision);

            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            var page = await browser.NewPageAsync();

            await page.GoToAsync("http://esaj.tjba.jus.br/cpo/sg/open.do");

            await page.ClickAsync("[id=\"radioNumeroAntigo\"][value=\"SAJ\"]");
            await page.TypeAsync("[id=\"nuProcessoAntigoFormatado\"]", processNumber);
            await page.ClickAsync("[id=\"botaoPesaquisar\"]");

            await page.WaitForNavigationAsync();

            var content = await page.GetContentAsync();

            await browser.CloseAsync();

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(content);

            return htmlDocument;
        }

        private List<ProcessData> GetProcessData(HtmlDocument htmlDocument)
        {
            var processNodes = htmlDocument
                .DocumentNode
                .SelectNodes("//table[@class='secaoFormBody'][@id='']/tbody/tr");

            var processData = new List<ProcessData>();

            foreach (var node in processNodes)
            {
                var data = new ProcessData();

                if (node.InnerHtml.Contains("Área"))
                {
                    data.Name = node.SelectSingleNode("td/table/tbody/tr/td/span").InnerText;
                    data.Value = node.SelectSingleNode("td/table/tbody/tr/td")
                        .InnerText
                        .Replace(data.Name, String.Empty);

                    processData.Add(data);
                }
                else if (node.InnerHtml.Contains("Processo") || node.InnerHtml.Contains("Classe"))
                {
                    data.Name = node.SelectSingleNode("td/div").InnerText;
                    data.Value = node.SelectSingleNode("td/table/tbody").InnerText;

                    processData.Add(data);
                }
                else if (!node.InnerHtml.Contains("Volume / Apenso") 
                    && !node.InnerHtml.Contains("Última carga")
                    && !node.InnerHtml.Contains("Recebimento"))
                {
                    data.Name = node.SelectSingleNode("td/div").InnerText;
                    data.Value = node.SelectSingleNode("td/span").InnerText;

                    processData.Add(data);
                }
            }

            ClearProcessData(processData);

            return processData;
        }

        private void ClearProcessData(List<ProcessData> processData)
        {
            foreach (var data in processData)
            {
                data.Value = data.Value.Replace("\n", String.Empty);
                data.Value = data.Value.Replace("\t", String.Empty);
                data.Value = data.Value.Trim();
            }
        }

        private List<MovementData> GetMovementData(HtmlDocument htmlDocument)
        {
            var movementsNodes = htmlDocument
               .DocumentNode
               .SelectNodes("//table[@id='tabelaUltimasMovimentacoes']/tbody/tr");

            var movementsData = new List<MovementData>();

            foreach (var node in movementsNodes)
            {
                var data = new MovementData();

                data.Date = node.SelectSingleNode("td").InnerText;

                data.Description = node
                    .SelectSingleNode("td[@style='vertical-align: top; padding-bottom: 5px']")
                    .InnerText;

                data.Details = node.SelectSingleNode("td/span").InnerText;

                if (!String.IsNullOrWhiteSpace(data.Details))
                {
                    data.Description = data.Description.Replace(data.Details, String.Empty);
                }

                movementsData.Add(data);
            }

            ClearMovementData(movementsData);

            return movementsData;
        }

        private void ClearMovementData(List<MovementData> movementsData)
        {
            foreach (var data in movementsData)
            {
                data.Date = data.Date.Replace("\n", String.Empty);
                data.Date = data.Date.Replace("\t", String.Empty);
                data.Date = data.Date.Trim();

                data.Description = data.Description.Replace("\n", String.Empty);
                data.Description = data.Description.Replace("\t", String.Empty);
                data.Description = data.Description.Trim();

                data.Details = data.Details.Replace("\n", String.Empty);
                data.Details = data.Details.Replace("\t", String.Empty);
                data.Details = data.Details.Trim();
            }
        }

        private ProcessoViewModel GetProcessoViewModel(
            string processNumber, 
            List<ProcessData> processData, 
            List<MovementData> movementsData)
        {
            var processo = new ProcessoViewModel();

            processo.NumeroProcesso = processNumber;

            foreach (var data in processData)
            {
                if (data.Name.Equals("Classe:"))
                {
                    processo.Classe = data.Value;
                }
                else if (data.Name.Equals("Área:"))
                {
                    processo.Area = data.Value;
                } 
                else if (data.Name.Equals("Assunto:"))
                {
                    processo.Assunto = data.Value;
                }
                else if (data.Name.Equals("Origem:"))
                {
                    processo.Origem = data.Value;
                }
                else if (data.Name.Equals("Distribuição:"))
                {
                    processo.Distribuicao = data.Value;
                }
                else if (data.Name.Equals("Relator:"))
                {
                    processo.Relator = data.Value;
                }
            }

            var cultureInfo = new System.Globalization.CultureInfo("pt-BR");

            foreach (var movement in movementsData)
            {
                var viewModel = new MovimentacaoViewModel();

                viewModel.Data = DateTime.Parse(movement.Date, cultureInfo);
                viewModel.Descricao = movement.Description;
                viewModel.Detalhes = movement.Details;

                processo.Movimentacoes.Add(viewModel);
            }

            return processo;
        }
    }
}
