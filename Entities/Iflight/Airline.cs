using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Iflight
{
    public class Airline : EntityBase
    {

        public Airline()
        {

            searchable_fields = "id,airline_name,airline_iata_code,airline_icao_code";

        }

        [MaxLength(100)]
        public string? airline_name { get; set; }


        [MaxLength(25)]
        public string? color { get; set; }


        [MaxLength(8)]
        public string? airline_iata_code { get; set; }

        [MaxLength(8)]
        public string? airline_icao_code { get; set; }

        [MaxLength(100)]
        public string? airline_short_name { get; set; }

        public string? airline_code
        {
            get
            {
                if (this.airline_iata_code != null || this.airline_iata_code != "")
                {
                    return this.airline_iata_code;
                }
                else
                {
                    return this.airline_icao_code;
                }
            }
        }

        public long? old_id { get; set; }

        public long? aircraft_type_id { get; set; }

        [ForeignKey("aircraft_type_id")]
        [RelationalField]
        public AircraftType aircraftType { get; set; }
        //public virtual List<CustomerAirline> CustomerAirlines { get; set; }
    }
}
