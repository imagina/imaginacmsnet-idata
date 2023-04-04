using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Idata.Entities.Core;
using Idata.Data.Entities.Setup;

namespace Idata.Data.Entities.Ramp
{
    public class OperationType : EntityBase
    {
        public string operation_name { get; set; }

        public long? company_id { get; set; }

        [ForeignKey("company_id")]

        [RelationalField]
        public virtual Company? company { get; set; }
    }
}
