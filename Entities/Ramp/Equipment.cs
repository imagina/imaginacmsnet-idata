using Idata.Data.Entities.Setup;
using Idata.Entities.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Ramp
{
    public class Equipment : EntityBase
    {

        public string assetNumber { get; set; }

        [ForeignKey("station_id")]
        public virtual Station station { get; set; }

        public long? station_id { get; set; }

        [ForeignKey("equiment_type_id")]
        public virtual EquipmentType equipmentType { get; set; }

        public long? equiment_type_id { get; set; }

        public long? old_id { get; set; }
    }
}
