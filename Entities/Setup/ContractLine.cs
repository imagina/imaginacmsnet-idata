using Idata.Data.Entities.Ramp;
using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Setup
{
    public class ContractLine : EntityBase
    {
        //[ScaffoldColumn(false)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int ContractLineId { get; set; }

        //[Display(Name = "Contract Line")]
        //[MaxLength(100)]
        public string? contract_line_name { get; set; }
        [NotMapped]
        public string? full_name { get; set; }

        //[Display(Name = "Contract Line desc")]
        public string? contract_line_description { get; set; }

        //[Display(Name = "WorkDay ID")]
        //[MaxLength(100)]
        public string? contract_line_workday_id { get; set; }

        //[Display(Name = "Contract")]
        public long? contract_id { get; set; }

        [ForeignKey("contract_id")]
        [RelationalField]
        public virtual Contract contract { get; set; }

        [RelationalField]
        public virtual List<ContractRule> contractRules { get; set; }


        //[RelationalField]
        //public virtual List<WorkdayTransaction> workdayTransactions { get; set; }

        //[Display(Name = "Line Number")]
        public int? line_number { get; set; }

        public string? workday_wid { get; set; }
        public string? workday_contract_line_type { get; set; }
        public string? workday_sales_line_item_id { get; set; }
        public string? workday_contract_line_status { get; set; }

        public long? old_id { get; set; }

        public override void Initialize()
        {
            string? workdayStatus = this.workday_contract_line_status == "COMPLETE" ? " - " + this.workday_contract_line_status : "";
            this.full_name = $"({this.contract_line_workday_id}) {this.contract_line_name} - {this.contract_line_description} - {workday_sales_line_item_id}" + workdayStatus;
        }
    }
}
