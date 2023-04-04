using Idata.Entities.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Ramp
{
    public class EquipmentType : EntityBase
    {

        //[Display(Name = "Model")]
        public string Type { get; set; }

        //[Display(Name = "Category")]

        public long? equipment_category_id { get; set; }

        [ForeignKey("equipment_category_id")]
        public EquipmentCategory equipment_category { get; set; }

    }
}
