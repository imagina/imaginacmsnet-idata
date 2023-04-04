using Idata.Data.Entities.Iflight;
using Idata.Entities.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Ramp
{
    public class CustomerAirline : EntityBase
    {


        //[ForeignKey("customer_id")]
        //public virtual Customer customer { get; set; }

        //[Required]
        public long? customer_id { get; set; }

        [ForeignKey("airline_id")]
        public virtual Airline airline { get; set; }

        //[Required]
        public long? airline_id { get; set; }
        public long? old_id { get; set; }
    }
}
