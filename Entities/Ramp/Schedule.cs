using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Idata.Data.Entities;
using Idata.Data.Entities.Setup;
using Idata.Entities.Core;
using Ihelpers.DataAnotations;

namespace Idata.Data.Entities.Ramp
{
    public class Schedule : EntityBase
    {

        #region Relations

        //[RelationalField]
        //[ForeignKey("schedule_status_id")]
        //public virtual ScheduleStatus? scheduleStatus { get; set; }
        public long? schedule_status_id { get; set; }

        [RelationalField]
        [ForeignKey("station_id")]
        public virtual Station? station { get; set; }
        public long? station_id { get; set; }

        [RelationalField]
        [ForeignKey("gate_id")]
        public virtual Gate? gate { get; set; }
        public long? gate_id { get; set; }

       
        #endregion
        public string? flight_number { get; set; }
        [NoUserTimezone]
        public DateTime? date { get; set; }
      
        public TimeSpan? sta { get; set; }
        
        public TimeSpan? std { get; set; }

 
    }
}
