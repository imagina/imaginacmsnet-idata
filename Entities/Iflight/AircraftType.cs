using Idata.Entities.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Iflight
{
    public class AircraftType : EntityBase
    {
        public string? model { get; set; }
        [NotMapped]
        public string? full_name { get; set; }
        public string? manufacturer { get; set; }
        public string? description { get; set; }
        public string? type { get; set; }
        public long? old_id { get; set; }


        public override void Initialize()
        {
            this.full_name = $"{this.manufacturer} {this.model}";
        }
    }
}
