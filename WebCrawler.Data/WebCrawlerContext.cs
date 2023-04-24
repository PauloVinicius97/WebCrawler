using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Data.Mappings;
using WebCrawler.Domain.Entities;

namespace WebCrawler.Data
{
    public class WebCrawlerContext : DbContext
    {
        public WebCrawlerContext() {}

        public DbSet<Processo> Processo { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder
                    .UseSqlite("Data Source=" + System.IO.Directory.GetCurrentDirectory() + "\\WebCrawlerDB.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProcessoMapping());
            builder.ApplyConfiguration(new MovimentacaoMapping());
        }
    }
}
