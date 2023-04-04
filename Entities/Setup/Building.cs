using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Setup
{
    public class Building : EntityBase
    {

        public Building()
        {

            searchable_fields = "id,building_name,workday_wid";

        }
        //[Required]
        //[Display(Name = "Building Name")]
        [MaxLength(100)]
        public string? building_name { get; set; }

        [ForeignKey("station_id")]
        [RelationalField]
        public virtual Station station { get; set; }

        //[Required]
        public long? station_id { get; set; }

        [ForeignKey("address_id")]
        [RelationalField]
        public virtual Address address { get; set; }

        public long? address_id { get; set; }

        [ForeignKey("company_id")]
        [RelationalField]
        public virtual Company company { get; set; }

        public long? company_id { get; set; }

        public string? workday_location_id { get; set; }

        public string? workday_wid { get; set; }
        public long? old_id { get; set; }
    }
}
