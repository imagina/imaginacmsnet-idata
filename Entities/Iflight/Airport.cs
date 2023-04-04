using Idata.Entities.Core;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Iflight
{
    [Index(nameof(airport_icao_code), IsUnique = true)]
    public class Airport : EntityBase
    {

        public Airport()
        {

            searchable_fields = "id,airport_name,airport_iata_code,airport_icao_code";

        }

        [NotMapped]
        public string? full_name { get; set; }


        [MaxLength(100)]
        public string airport_name { get; set; }


        [MaxLength(8)]
        public string airport_iata_code { get; set; }


        [MaxLength(8)]
        public string airport_icao_code { get; set; }

        ////[Display(Name = "timezone")]
        public string? timezone { get; set; }

        public decimal? lat { get; set; }
        public decimal? lng { get; set; }
        public string airport_code
        {
            get
            {
                if (this.airport_iata_code != null || this.airport_iata_code != "")
                {
                    return this.airport_iata_code;
                }
                else
                {
                    return this.airport_icao_code;
                }
            }
        }
        public long? old_id { get; set; }

        public override void Initialize()
        {
             this.full_name = $"{this.airport_name} ({this.airport_icao_code}) ";
        }
    }
}
