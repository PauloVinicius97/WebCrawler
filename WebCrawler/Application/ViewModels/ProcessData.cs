using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebCrawler.Application.ViewModels
{
    public class ProcessData
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public ProcessData()
        {
            Name = String.Empty;
            Value = String.Empty;
        }
    }
}
