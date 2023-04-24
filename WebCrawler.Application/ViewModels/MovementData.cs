using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Application.ViewModels
{
    public class MovementData
    {
        public string Date { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }

        public MovementData()
        {
            Date = String.Empty;
            Description = String.Empty;
            Details = String.Empty;
        }
    }
}
