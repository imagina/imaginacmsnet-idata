using Idata.Data.Entities.Setup;
using Idata.Entities.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Ramp
{
    public class WorkOrderEmployee : EntityBase
    {
        //[ScaffoldColumn(false)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int WorkOrderEmployeeId { get; set; }
        public long? workorder_id { get; set; }

        [ForeignKey("workorder_id")]
        public virtual WorkOrder workOrder { get; set; }

        //[Required]

        public long? employee_id { get; set; }

        [ForeignKey("employee_id")]
        public virtual Employee employee { get; set; }

        //[Required]


        public double hours_worked { get; set; }
        public double hours_worked_ot { get; set; }

        //[DisplayFormat(DataFormatString = "{0:h\\:mm}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Time)]
        public TimeSpan employee_start_time { get; set; }

        //[DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Time)]
        public TimeSpan employee_end_time { get; set; }
    }
}
