using Idata.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idata.Data.Entities.Ramp
{
    public class ScheduleStatus : EntityBase
    {
        public string? name { get; set; }

        public string? color { get; set; }
    }
}
