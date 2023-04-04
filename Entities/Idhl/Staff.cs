using Idata.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ihelpers.DataAnotations;
using Idata.Entities.Core;
using Idata.Data.Entities.Setup;
using Idata.Data.Entities.Iprofile;

namespace Idata.Entities.Idhl
{

    public class Staff : EntityBase
    {

        public Staff()
        {
         
            default_include = "station";
        
        }
        [ForeignKey("station_id")]
        [RelationalField]
        public virtual Station station { get; set; }
        public long? station_id { get; set; }

        [ForeignKey("created_by")]
        [RelationalField]
        public virtual User user { get; set; }

        public int shift { get; set; }
        public DayOfWeek day_of_week { get; set; }
        public int qty { get; set; }
        [NotMapped]
        public string? full_name { get; set; }
        [NotMapped]
        public string? day_of_week_name { get; set; }
        public override void Initialize()
        {
            this.full_name = $"{this.station.station_code} ({ this.day_of_week.ToString() +"/"+ (this.shift == 0 ? "AM" : "PM")}) ({this.qty})";
            this.day_of_week_name = this.day_of_week.ToString();
        }
    }
}
