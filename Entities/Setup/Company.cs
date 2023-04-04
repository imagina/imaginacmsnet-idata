using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Setup
{
    public class Company : EntityBase
    {
        public Company()
        {

            searchable_fields = "id,company_name,company_code,workday_code,workday_wid";

        }
        [NotMapped]
        public string? full_name { get; set; }

        //[Required]
        //[Display(Name = "Company Name")]
        [MaxLength(100)]
        public string company_name { get; set; }

        //[Required]
        //[Display(Name = "Company Code")]
        [MaxLength(10)]
        public string company_code { get; set; }

        //[Display(Name = "WorkDay Code")]
        [MaxLength(50)]
        public string workday_code { get; set; }

        //[Display(Name = "WID")]
        [MaxLength(50)]
        public string workday_wid { get; set; }
        [RelationalField]
        public virtual List<Building> buildings { get; set; }
        public long? old_id { get; set; }

        public override void Initialize()
        {
            this.full_name = $"{this.company_name} ({this.company_code}) ";
        }
    }
}
