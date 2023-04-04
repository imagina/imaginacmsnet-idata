using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Setup
{
    public class CostCenter : EntityBase
    {
        //[ScaffoldColumn(false)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int CostCenterId { get; set; }

        //[Required]
        //[Display(Name = "Cost Center Name")]
        //[MaxLength(100)]
        public string name { get; set; }

        //[Display(Name = "WorkDay Id")]
        //[MaxLength(100)]
        public string work_day_id { get; set; }

        //[Display(Name = "WorkDay WID")]
        //[MaxLength(100)]
        public string work_day_wid { get; set; }

        [ForeignKey("building_id")]
        [RelationalField]
        public virtual Building building { get; set; }

        //[Required]
        public long? building_id { get; set; }

        public long? business_unit_type_id { get; set; }

        [ForeignKey("business_unit_type_id")]
        [RelationalField]
        public BusinessUnitType businessUnitType { get; set; }

        public long? manager_id { get; set; }

        [ForeignKey("manager_id")]
        [RelationalField]
        public virtual Employee manager { get; set; }

        [ForeignKey("company_id")]
        [RelationalField]
        public virtual Company company { get; set; }

        //[Required]
        public long? company_id { get; set; }
        public long? old_id { get; set; }
    }
}
