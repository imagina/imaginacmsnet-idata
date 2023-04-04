using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Ramp
{
    public class Attributes : EntityBase
    {

        public string name { get; set; }

        public string type { get; set; }

        public bool required { get; set; }

        [NotMapped]
        public override string? default_include { get; set; } = "values";

        [RelationalField]
        public virtual List<Product> products { get; set; }

        [RelationalField]
        public virtual List<Values> values { get; set; }

    }
}
