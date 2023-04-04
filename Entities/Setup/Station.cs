using Idata.Data.Entities.Iflight;
using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Idata.Data.Entities.Setup
{
    public class Station : EntityBase
    {

        public Station()
        {

            searchable_fields = "id,station_name,station_code";

        }

        #region Relations
        public long? airport_id { get; set; }
        [ForeignKey("airport_id")]
        [RelationalField]
        public virtual Airport airport { get; set; }


        public long? company_id { get; set; }
        [ForeignKey("company_id")]
        [RelationalField]
        public virtual Company company { get; set; }

        [RelationalField]
        public virtual List<Building> buildings { get; set; }
        [RelationalField]
        public virtual List<Gate> gates { get; set; }
        [RelationalField]
        public virtual List<Area> areas { get; set; }

        #endregion
        [NotMapped]
        public string? full_name { get; set; }



        //[Required]
        //[Display(Name = "Station Name")]
        [MaxLength(100)]
        public string station_name { get; set; }

        //[Required]
        //[Display(Name = "Station Abrev")]
        [MaxLength(10)]
        public string station_code { get; set; }

        //public virtual List<Company> Companies { get; set; }
        


        public long? old_id { get; set; }

        public override void Initialize()
        {
            this.full_name = $"{this.station_name} ({this.station_code}) ";
        }
    }
}
