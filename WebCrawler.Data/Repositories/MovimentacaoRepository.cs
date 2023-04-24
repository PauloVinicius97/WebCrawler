using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Domain.Entities;
using WebCrawler.Domain.Interfaces.Repositories;

namespace WebCrawler.Data.Repositories
{
    public class MovimentacaoRepository : BaseRepository<Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(WebCrawlerContext context) : base(context)
        {
        }
    }
}
