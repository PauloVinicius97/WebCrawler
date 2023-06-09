﻿using Microsoft.AspNetCore.Mvc;
using WebCrawler.Application.AppServices;
using WebCrawler.Application.ViewModels;

namespace WebCrawler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoController : ControllerBase
    {
        private ProcessoAppService _processoAppService;
        private WebCrawlerTJBAAppService _webCrawlerTJBAAppService;

        public ProcessoController()
        {
            _processoAppService = new ProcessoAppService();
            _webCrawlerTJBAAppService = new WebCrawlerTJBAAppService();
        }

        [HttpGet("processos")]
        public List<ProcessoViewModel> GetProcessos()
        {
            var processos = _processoAppService.GetAllProcessos();

            return processos;
        }

        [HttpPost("getProcessoFromTJBA")]
        public ActionResult<ResultViewModel> GetProcessoFromTJBA(string processNumber)
        {
            var result = _webCrawlerTJBAAppService.GetProcessoFromTJBA(processNumber);

            if (result.Result.Success == true)
            {
                return Ok(result.Result);
            }

            return BadRequest(result.Result);
        }

        [HttpPost("addProcesso")]
        public ActionResult<ResultViewModel> AddProcesso([FromBody] ProcessoViewModel processo) 
        {
            var result = _processoAppService.AddProcesso(processo);

            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("updateProcesso/{processNumber}")]
        public ActionResult<ResultViewModel> UpdateProcesso([FromBody] ProcessoViewModel processo, string processNumber)
        {
            var result = _processoAppService.UpdateProcesso(processNumber, processo);

            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("removeProcesso/{processNumber}")]
        public ActionResult<ResultViewModel> RemoveProcesso(string processNumber)
        {
            var result = _processoAppService.RemoveProcesso(processNumber);

            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
