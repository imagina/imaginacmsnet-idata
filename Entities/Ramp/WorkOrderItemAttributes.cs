using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Ramp
{
    public class WorkOrderItemAttributes : EntityBase
    {
        public long? attribute_id { get; set; }
        [RelationalField]
        [ForeignKey("attribute_id")]
        public Attributes attribute { get; set; }

        public long? workorder_item_id { get; set; }
        [RelationalField]
        [ForeignKey("workorder_item_id")]
        public WorkOrderItem workOrderItem { get; set; }


        public string? name { get; set; }

        public string? value { get; set; }
    }
}
