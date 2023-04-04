using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Iflight
{

    public enum Flightstatus
    {
        Scheduled,
        Scheduled_Delayed,
        Active,
        Unknown,
        Redirected,
        Landed,
        Landed_Taxiing,
        Arrived,
        Arrived_GateArrival,
        Arrived_Delayed,
        Taxiing_LeftGate,
        EnRoute_OnTime,
        EnRoute_Delayed,
        Diverted,
        Cancelled,
        NotOperational,
        result_unknown,
        Delayed
    }


    public class Flight : EntityBase
    {

        public long? champ_flight_id { get; set; }

        [NotMapped]
        public string? full_name { get; set; }


        public long? flight_schedule_leg_id { get; set; }

        [ForeignKey("flight_schedule_leg_id")]
        [RelationalField]
        public virtual FlightScheduleLeg flightScheduleLeg { get; set; }

        public string? tail_number { get; set; }
        public int flight_status { get; set; }
        public string? fa_flight_id { get; set; }
        public string? inbound_fa_flight_id { get; set; }

        // Estimated  Departure - Arrival
        public DateTime? estimated_departure_time { get; set; }
        public int estimated_departure_time_epoch { get; set; }
        public int estimated_departure_time_local { get; set; }
        public DateTime? estimated_arrival_time { get; set; }
        public int estimated_arrival_time_epoch { get; set; }
        public int estimated_arrival_time_local { get; set; }

        // Actual Departure - Arrival
        public DateTime? actual_departure_time { get; set; }
        public int actual_departure_time_epoch { get; set; }
        public int actual_departure_time_local { get; set; }
        public DateTime? actual_arrival_time { get; set; }
        public int actual_arrival_time_epoch { get; set; }
        public int actual_arrival_time_local { get; set; }

        // Estimated  BlockIn - BlockOut
        public DateTime? estimated_block_in_time { get; set; }
        public int estimated_block_in_time_epoch { get; set; }
        public int estimated_block_in_time_local { get; set; }
        public DateTime? estimated_block_out_time { get; set; }
        public int estimated_block_out_time_epoch { get; set; }
        public int estimated_block_out_time_local { get; set; }

        // Actual BlockIn - BlockOut
        public DateTime? actual_block_in_time { get; set; }
        public int actual_block_in_time_epoch { get; set; }
        public int actual_block_in_time_local { get; set; }
        public DateTime? actual_block_out_time { get; set; }
        public int actual_block_out_time_epoch { get; set; }
        public int actual_block_out_time_local { get; set; }

        // Airports



        public long? airport_origin_id { get; set; }

        [ForeignKey("airport_origin_id")]
        [RelationalField]
        public virtual Airport? airportOrigin { get; set; }





        public long? airport_destination_id { get; set; }

        [ForeignKey("airport_destination_id")]
        [RelationalField]
        public virtual Airport? airportDestination { get; set; }




        // Gates
        public string? gate_origin { get; set; }
        public string? gate_destination { get; set; }

        //Terminal
        public string? terminal_origin { get; set; }
        public string? terminal_destination { get; set; }


        public long? aircraft_type_id { get; set; }

        [ForeignKey("aircraft_type_id")]
        [RelationalField]
        public AircraftType aircraftType { get; set; }




        public string GetFlightstatus
        {
            get
            {
                string result = "Unknown";

                switch (Enum.Parse(typeof(Flightstatus), this.flight_status.ToString()))
                {
                    case Flightstatus.Scheduled:
                        result = "Scheduled";
                        break;
                    case Flightstatus.Scheduled_Delayed:
                        result = "Scheduled / Delayed";
                        break;
                    case Flightstatus.Active:
                        result = "Active";
                        break;
                    case Flightstatus.Unknown:
                        result = "Unknown";
                        break;
                    case Flightstatus.Redirected:
                        result = "Redirected";
                        break;
                    case Flightstatus.Landed:
                        result = "Landed";
                        break;
                    case Flightstatus.Landed_Taxiing:
                        result = "Landed / Taxiing";
                        break;
                    case Flightstatus.Arrived:
                        result = "Arrived";
                        break;
                    case Flightstatus.Arrived_GateArrival:
                        result = "Arrived / Gate Arrival";
                        break;
                    case Flightstatus.Arrived_Delayed:
                        result = "Arrived / Delayed";
                        break;
                    case Flightstatus.Taxiing_LeftGate:
                        result = "Taxiing / Left Gate";
                        break;
                    case Flightstatus.EnRoute_OnTime:
                        result = "En Route / On time";
                        break;
                    case Flightstatus.EnRoute_Delayed:
                        result = "En Route / Delayed";
                        break;
                    case Flightstatus.Diverted:
                        result = "Diverted";
                        break;
                    case Flightstatus.Cancelled:
                        result = "Cancelled";
                        break;
                    case Flightstatus.NotOperational:
                        result = "Not Operational";
                        break;
                    case Flightstatus.result_unknown:
                        result = "result unknown";
                        break;
                    case Flightstatus.Delayed:
                        result = "Delayed";
                        break;
                    default:
                        break;
                }
                return result;
            }
        }

        public void SetFlightstatus(string status)
        {

            if (status == null || status == "")
            {
                this.flight_status = (int)Flightstatus.Unknown;
                return;
            }

            switch (status)
            {
                case "Scheduled":
                    this.flight_status = (int)Flightstatus.Scheduled;
                    break;
                case "Scheduled / Delayed":
                    this.flight_status = (int)Flightstatus.Scheduled_Delayed;
                    break;
                case "En Route / On Time":
                    this.flight_status = (int)Flightstatus.EnRoute_OnTime;
                    break;
                case "En Route / Delayed":
                    this.flight_status = (int)Flightstatus.EnRoute_Delayed;
                    break;
                case "Arrived":
                    this.flight_status = (int)Flightstatus.Arrived;
                    break;
                case "Arrived / Gate Arrival":
                    this.flight_status = (int)Flightstatus.Arrived_GateArrival;
                    break;
                case "Arrived / Delayed":
                    this.flight_status = (int)Flightstatus.Arrived_Delayed;
                    break;
                case "Landed / Taxiing":
                    this.flight_status = (int)Flightstatus.Landed_Taxiing;
                    break;
                case "Taxiing / Left Gate":
                    this.flight_status = (int)Flightstatus.Taxiing_LeftGate;
                    break;
                case "result unknown":
                    this.flight_status = (int)Flightstatus.result_unknown;
                    break;
                case "Diverted":
                    this.flight_status = (int)Flightstatus.Diverted;
                    break;
                case "Delayed":
                    this.flight_status = (int)Flightstatus.Delayed;
                    break;
                default:
                    this.flight_status = (int)Flightstatus.Unknown;

                    break;
            }
            return;
        }

        public long? old_id { get; set; }


    }
}
