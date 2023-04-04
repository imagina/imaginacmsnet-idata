using Idata.Data.Entities;
using Idata.Data.Entities.Setup;
using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Ramp
{

    public class AircraftTypeOptionRule
    {
        public List<long?>? acTypes { get; set; }
        public long contractLineId { get; set; }
    }


    public class KilosTypeRule
    {
        public string type { get; set; }

        public float quantityRule { get; set; }

        public List<long?>? operationTypes { get; set; }
        public long noExceedContractLineId { get; set; }
        public long exceedContractLineId { get; set; }
    }

    public enum ContractRuleType
    {
        Included = 1,
        Parking = 2,
        AircraftType = 3,
        OperationType = 4,
        CargoKilos = 5

    }

    public class ContractRule : EntityBase
    {
        public ContractRuleType type { get; set; }
        [NotMapped]
        public string type_name { get; set; }
        public bool status { get; set; } = true;

        public double quantity_rule { get; set; }

        public long? product_origin_id { get; set; }
        [ForeignKey("product_origin_id")]
        [RelationalField]
        public virtual Product product { get; set; }



        public long? contract_line_id { get; set; }

        [ForeignKey("contract_line_id")]
        [RelationalField]
        public virtual ContractLine contractLine { get; set; }


        public long? contract_id { get; set; }

        [ForeignKey("contract_id")]
        [RelationalField]
        public virtual Contract contract { get; set; }

        public override void Initialize()
        {
            this.type_name = this.type.ToString();
        }
    }
}
