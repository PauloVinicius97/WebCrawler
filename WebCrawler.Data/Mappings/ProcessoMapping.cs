using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Domain.Entities;

namespace WebCrawler.Data.Mappings
{
    public class ProcessoMapping : IEntityTypeConfiguration<Processo>
    {
        public void Configure(EntityTypeBuilder<Processo> builder)
        {
            builder.HasKey(p => p.NumeroProcesso);

            builder.HasMany(p => p.Movimentacoes)
                .WithOne()
                .HasForeignKey(m => m.NumeroProcessoFK);
        }
    }
}
