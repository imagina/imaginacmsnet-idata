using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Ramp
{
    public class Values : EntityBase
    {
        public string name { get; set; }

        public string value { get; set; }

        public long? attribute_id { get; set; }

        [RelationalField]
        [ForeignKey("attribute_id")]
        public virtual Attributes attribute { get; set; }
    }
}
