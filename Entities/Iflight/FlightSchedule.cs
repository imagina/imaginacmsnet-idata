using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Iflight
{
    public enum FlightType
    {
        Unknown,
        Passenger,
        Freighter,
        Truck
    }
    public class FlightSchedule : EntityBase
    {

        [MaxLength(100)]
        public string flight_number { get; set; }
        public string flight_number_iata { get; set; }
        public string flight_number_icao { get; set; }


        public long? aircraft_type_id { get; set; }
        [RelationalField]
        [ForeignKey("aircraft_type_id")]
        public virtual AircraftType? aircraftType { get; set; }




        //[Display(Name = "Airline")]
        public long? airline_id { get; set; }
        [RelationalField]
        [ForeignKey("airline_id")]
        public virtual Airline? airline { get; set; }





        //[Display(Name = "Active Flight")]
        public bool is_active { get; set; }

        public string schedule { get; set; }
        //public int? CustomerAirlineId { get; set; }

        public FlightType flight_type { get; set; }

        ////[ForeignKey("CustomerAirlineId")]
        //public virtual CustomerAirline CustomerAirline { get; set; }

        public virtual List<FlightScheduleLeg>? flightScheduleLegs { get; set; }

        public long? old_id { get; set; }
    }
}
