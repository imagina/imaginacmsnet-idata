using Idata.Entities.Core;

namespace Idata.Data.Entities.Setup
{
    public class BusinessUnit : EntityBase
    {
        //[ScaffoldColumn(false)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int BusinessUnitId { get; set; }

        //[Display(Name = "WorkDay Id")]
        //[MaxLength(100)]
        public string workday_id { get; set; }

        //[Display(Name = "WorkDay WID")]
        //[MaxLength(100)]
        public string workday_wid { get; set; }

        //public long? building_id { get; set; }

        //public Building Building { get; set; }




        public long? old_id { get; set; }
    }
}
