using Idata.Data.Entities.Setup;
using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Ramp
{

    public enum WorkdayTransactionStatus
    {
        unposted,
        posted,
        noposted

    }


    public class WorkdayTransaction : EntityBase
    {


        public long? work_order_id { get; set; }

        [ForeignKey("work_order_id")]

        [RelationalField]
        public virtual WorkOrder workOrder { get; set; }



        public long? contract_line_id { get; set; }

        [ForeignKey("contract_line_id")]

        [RelationalField]
        public virtual ContractLine? contractLine { get; set; }

        //workday transaction id (once posted)

        public long? product_id { get; set; }

        [ForeignKey("product_id")]

        [RelationalField]
        public virtual Product? product { get; set; }

        public string? transaction_id { get; set; }
        public float? quantity { get; set; }

        public DateTime? posted_at { get; set; }
        public DateTime? dateTransaction { get; set; }
        public decimal ammount { get; set; } = 0;
        public WorkdayTransactionStatus status { get; set; } = WorkdayTransactionStatus.unposted;
    }
}
