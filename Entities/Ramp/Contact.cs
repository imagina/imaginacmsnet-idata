using Idata.Entities.Core;

namespace Idata.Data.Entities.Ramp
{
    public class Contact : EntityBase
    {
        //public long? customer_id { get; set; }

        //[ForeignKey("customer_id")]
        //public virtual Customer customer { get; set; }
        public long? old_id { get; set; }
    }
}
