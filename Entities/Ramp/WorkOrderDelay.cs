using Idata.Entities.Core;

namespace Idata.Data.Entities.Ramp
{
    public class WorkOrderDelay : EntityBase
    {
        public string name { get; set; }

        public bool status { get; set; } = true;
    }
}
