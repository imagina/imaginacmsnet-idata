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
using Idata.Data.Entities.Iflight;

namespace Idata.Entities.Idhl
{

    public class ScoreCard : EntityBase
    {
        #region relations

        [ForeignKey("company_id")]
        [RelationalField]
        public virtual Company company { get; set; }
        public long? company_id { get; set; }

        [ForeignKey("flight_id")]
        [RelationalField]
        public virtual Flight flight { get; set; }
        public long? flight_id { get; set; }
    

        [ForeignKey("staff_id")]
        [RelationalField]
        public virtual Staff? staff { get; set; }
        public long? staff_id { get; set; }


        #endregion

        public DateTime date { get; set; } //score_card_date
        public DateTime? std { get; set; } //score_card_date
        public DateTime? atd { get; set; } //score_card_date
        public int? flight_type { get; set; }  //0 arrival 1 departure
        public bool? gse { get; set; }
        public bool? fuel { get; set; }
        public int actual_hct { get; set; }
        public string? out_of_service { get; set; }
        public string? delay_details { get; set; }
        public string? other_comments { get; set; }
        public string? pre_ops { get; set; }
        public string? post_ops { get; set; }
        public string? safety { get; set; }
        public string? dhl_supervisor_name { get; set; }

        
        [NotMapped]
        //Used for transformer to track relations given in front
        public string staffing { get; set; }

        public override void Initialize()
        {
            this.staffing = $"{actual_hct}/{(this.staff!=null ? this.staff.qty : 0)}";
        }

    }
}