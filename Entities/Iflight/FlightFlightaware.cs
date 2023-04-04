using Idata.Data.Entities.Iflight;
using Ihelpers.DataAnotations;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace Idata.Data.Entities.FlightFlightaware
{

    public class OriginDestinationFlightaware
    {

        public string? code { get; set; }
        public string? code_icao { get; set; }
        public string? code_iata { get; set; }
        public string? code_lid { get; set; }
        public string? airport_info_url { get; set; }


        public List<PropertyInfo> getProperties()
        {
            return this.GetType().GetProperties().ToList();
        }

        public string getClasssName()
        {
            return this.GetType().Name;
        }

    }


    public class FlightFlightaware
    {

        public string? ident { get; set; }
        public string? ident_icao { get; set; }
        public string? ident_iata { get; set; }
        public string? fa_flight_id { get; set; }
        public string? operator_icao { get; set; }
        public string? operator_iata { get; set; }
        public string? flight_number { get; set; }
        public string? registration { get; set; }
        public string? atc_ident { get; set; }
        public string? inbound_fa_flight_id { get; set; }
        public object[]? codeshares { get; set; }
        public object[]? codeshares_iata { get; set; }

        public bool? blocked { get; set; }
        public bool? diverted { get; set; }
        public bool? cancelled { get; set; }
        public bool? position_only { get; set; }
        [RelationalField]
        public OriginDestinationFlightaware? origin { get; set; }
        [RelationalField]
        public OriginDestinationFlightaware? destination { get; set; }
        [RelationalField]
        public Airport? originAirport { get; set; }
        [RelationalField]
        public Airport? destinationAirport { get; set; }

        [RelationalField]
        public FlightStatus? flightStatus { get; set; }
        public long? departure_delay { get; set; }
        public long? arrival_delay { get; set; }
        public long? filed_ete { get; set; }

        public DateTime? scheduled_out { get; set; }
        public DateTime? estimated_out { get; set; }
        public DateTime? actual_out { get; set; }
        public DateTime? scheduled_off { get; set; }

        [NoUserTimezone]
        public DateTime? estimated_off { get; set; }
        public DateTime? actual_off { get; set; }
        public DateTime? scheduled_on { get; set; }
        [NoUserTimezone]
        public DateTime? estimated_on { get; set; }
        [NoUserTimezone]
        public DateTime? estimated_off_utc { get; set; }
        [NoUserTimezone]
        public DateTime? estimated_on_utc { get; set; }
        public DateTime? actual_on { get; set; }
        public DateTime? scheduled_in { get; set; }
        public DateTime? estimated_in { get; set; }
        public DateTime? actual_in { get; set; }
        public long? progress_percent { get; set; }
        public string? status { get; set; }
        public string? aircraft_type { get; set; }
        public long? route_distance { get; set; }
        public long? filed_airspeed { get; set; }
        public long? filed_altitude { get; set; }
        public string? route { get; set; }
        public string? baggage_claim { get; set; }
        public long? seats_cabin_business { get; set; }
        public long? seats_cabin_coach { get; set; }
        public long? seats_cabin_first { get; set; }
        public string? gate_origin { get; set; }
        public string? gate_destination { get; set; }
        public string? terminal_origin { get; set; }
        public string? terminal_destination { get; set; }
        public Decimal? distance_percentage_covered { get; set; }
        public Decimal? time_percentage_covered { get; set; }
        public Decimal? distance_covered { get; set; }
        public double? time_total_estimated { get; set; }
        public JArray? waypoints { get; set; }
        public string? type { get; set; }


        public List<PropertyInfo> getProperties()
        {
            return this.GetType().GetProperties().ToList();
        }

        public string getClasssName()
        {
            return this.GetType().Name;
        }

    }


}
