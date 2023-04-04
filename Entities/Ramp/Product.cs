using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Ramp
{
    public class Product : EntityBase
    {
        public string name { get; set; }
        [NotMapped]
        public string full_name { get; set; }

        public string? label { get; set; }
        public long? category_id { get; set; }

        public bool status { get; set; } = true;
        public long? type { get; set; }

        public long? measure_unit_id { get; set; }

        [RelationalField]
        [ForeignKey("measure_unit_id")]
        public virtual MeasureUnits? measureUnit { get; set; }


        [RelationalField]
        public virtual List<WorkdayTransaction>? workdayTransactions { get; set; }

        [RelationalField]
        
        public virtual List<Category?> categories { get; set; }

        [RelationalField]
        public virtual List<Attributes>? attributes { get; set; }

        public override void Initialize()
        {
            this.full_name = $"{this.name} - {this.external_id}";
        }

    }
}
