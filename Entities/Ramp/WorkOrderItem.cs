using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Ramp
{
    public class WorkOrderItem : EntityBase
    {
        [RelationalField]
        public virtual List<WorkOrderItemAttributes>? workOrderItemAttributes { get; set; }


        public long? product_id { get; set; }

        [RelationalField]
        [ForeignKey("product_id")]

        public Product product { get; set; }

        public long? workorder_id { get; set; }

        [RelationalField]
        [ForeignKey("workorder_id")]

        public WorkOrder workOrder { get; set; }
    }
}
