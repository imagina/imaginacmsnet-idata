using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idata.Entities.Ireport.ViewModels
{
    public class CsvReportViewModel
    {
        public string? CsvString { get; set; }

        public List<string>? CsvList { get; set; }
        public CsvReportViewModel()
        {
            if(!string.IsNullOrEmpty(CsvString))
            {
                CsvList = CsvString.Split("\r\n").ToList();
            }
        }
    }
}
