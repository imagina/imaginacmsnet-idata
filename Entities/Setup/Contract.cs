using Idata.Data.Entities.Iflight;
using Idata.Data.Entities.Ramp;
using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Idata.Data.Entities.Setup
{
    public class Contract : EntityBase
    {
        public Contract()
        {
            this.flightSchedules = new List<FlightSchedule>();
            default_include = "customer";
        }

        //////[display(Name = "Contract title")]
        //[MaxLength(100)]
        public string? contract_name { get; set; }

        ////[display(Name = "Contract desc")]
        public string? contract_description { get; set; }


        ////[display(Name = "WorkDay ID")]
        //[MaxLength(100)]
        public string workday_id { get; set; }

        //[Required]
        ////[display(Name = "Contract Type")]




        //[display(Name = "Work Tag")]
        public string? worktag { get; set; }

        public DateTime contract_signed_date { get; set; }
        public DateTime contract_effective_date { get; set; }

        //[display(Name = "Production")]
        public bool? ready_to_post_wd { get; set; }
        //[display(Name = "One click Post")]
        public bool? one_click_post { get; set; }
        [RelationalField]
        public virtual List<FlightSchedule> flightSchedules { get; set; }
        [RelationalField]
        public virtual List<ContractLine> contractLines { get; set; }

        [RelationalField]
        public virtual List<ContractRule> contractRules { get; set; }
        public long? contract_type_id { get; set; }
        [ForeignKey("contract_type_id")]
        [RelationalField]
        public ContractType contractType { get; set; }

        //[display(Name = "Status")]

        public long? contract_status_id { get; set; }

        [ForeignKey("contract_status_id")]
        [RelationalField]
        public ContractStatus contractStatus { get; set; }

        //[display(Name = "Customer")]
        public long? customer_id { get; set; }

        [ForeignKey("customer_id")]
        [RelationalField]
        public virtual Customer customer { get; set; }

        [NotMapped]
        public string customer_name { get; set; }

        //[display(Name = "Building")]n
        public long? building_id { get; set; }

        [ForeignKey("building_id")]
        [RelationalField]
        public virtual Building building { get; set; }
        public long? cost_center_id { get; set; }

        [ForeignKey("cost_center_id")]
        [RelationalField]
        public virtual CostCenter costCenter { get; set; }
        public long? business_unit_id { get; set; }

        [ForeignKey("business_unit_id")]
        public virtual BusinessUnit business_unit { get; set; }


        public long? company_id { get; set; }

        [ForeignKey("company_id")]
        [RelationalField]
        public virtual Company company { get; set; }
        public long? old_id { get; set; }

        public override void Initialize()
        {
            if (customer != null)
                customer_name = customer.customer_name;
        }
    }
}
