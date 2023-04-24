using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Application.ViewModels
{
    public class ResultViewModel
    {
        public bool Success { get; set; }
        public List<string> Logs { get; set; }
        public List<string> Errors { get; set; }

        public ResultViewModel()
        {
            Logs = new List<string>();
            Errors = new List<string>();
        }
    }
}
