using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Iflight
{
    public class FlightScheduleLeg : EntityBase
    {

        ////[Display(Name = "Flight Schedule")]
        public long? flight_schedule_id { get; set; }

        public int leg_number { get; set; }

        [ForeignKey("flight_schedule_id")]
        [RelationalField]
        public virtual FlightSchedule? flightSchedule { get; set; }

        ////[Display(Name = "Origin")]



        public long? airport_origin_id { get; set; }

        [ForeignKey("airport_origin_id")]
        [RelationalField]
        public Airport? airportOrigin { get; set; }




        public long? airport_destination_id { get; set; }

        [ForeignKey("airport_destination_id")]
        [RelationalField]
        public Airport? airportDestination { get; set; }





        ////[Display(Name = "Dep")]
        public string departure_time { get; set; }

        ////[Display(Name = "Arr")]
        public string arrival_time { get; set; }

        ////[Display(Name = "Aircraft Type")]


        public long? aircraft_type_id { get; set; }

        [ForeignKey("aircraft_type_id")]
        [RelationalField]
        public AircraftType? aircraftType { get; set; }





        public virtual List<Flight>? flights { get; set; }
        public string DisplayTime(string date)
        {
            if (date == null || date == "" || date.Length != 4)
            {
                return "N/A";
            }
            else
            {
                return date.Substring(0, 2) + ":" + date.Substring(2, 2);
            }
        }
        public long? old_id { get; set; }
    }
}
