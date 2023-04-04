using Idata.Data.Entities.Setup;
using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Ramp
{
    public class Category : EntityBase
    {
        public long? company_id { get; set; }

        [ForeignKey("company_id")]

        [RelationalField]
        public virtual Company? company { get; set; }


        public string name { get; set; }

        public long? parent_id { get; set; }


        [RelationalField]
        public virtual List<Product>? products { get; set; }
    }
}
