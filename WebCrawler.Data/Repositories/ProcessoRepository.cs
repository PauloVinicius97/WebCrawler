using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Domain.Entities;
using WebCrawler.Domain.Interfaces.Repositories;

namespace WebCrawler.Data.Repositories
{
    public class ProcessoRepository : BaseRepository<Processo>, IProcessoRepository
    {
        public ProcessoRepository(WebCrawlerContext context) : base(context)
        {
        }
    }
}
