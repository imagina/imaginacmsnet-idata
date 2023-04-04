using Idata.Data.Entities.Iflight;
using Idata.Data.Entities.Iprofile;
using Idata.Data.Entities.Setup;
using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Ramp
{
    public class WorkOrder : EntityBase
    {
        public WorkOrder()
        {
            workOrderItems = new List<WorkOrderItem>();
            default_include = "customer,workOrderItems,workOrderItems.workOrderItemAttributes,gate,flightStatus";
            searchable_fields = "id,reference_id";
            is_revisionable = true;
        }

        #region Relations

       

        [RelationalField]
        public virtual List<WorkdayTransaction>? workdayTransactions { get; set; }

        public long? carrier_id { get; set; }
        [ForeignKey("carrier_id")]
        [RelationalField]
        public virtual Airline? carrier { get; set; }

        public long? station_id { get; set; }
        [ForeignKey("station_id")]
        [RelationalField]
        public virtual Station? station { get; set; }

        public long? customer_id { get; set; }
        [ForeignKey("customer_id")]
        [RelationalField]
        public virtual Customer? customer { get; set; }

        public long? ac_type_id { get; set; }
        [ForeignKey("ac_type_id")]
        [RelationalField]
        public virtual AircraftType? acType { get; set; }

        public long? operation_type_id { get; set; }
        [ForeignKey("operation_type_id")]
        [RelationalField]
        public OperationType? operationType { get; set; }


        public long? status_id { get; set; } = 5;
        [ForeignKey("status_id")]
        [RelationalField]
        public WorkOrderStatus? workOrderStatus { get; set; }

        public long? inbound_origin_airport_id { get; set; }
        [ForeignKey("inbound_origin_airport_id")]
        [RelationalField]
        public virtual Airport? inboundOriginAirport { get; set; }

        public long? outbound_destination_airport_id { get; set; }
        [ForeignKey("outbound_destination_airport_id")]
        [RelationalField]
        public virtual Airport? outboundDestinationAirport { get; set; }

        public long? contract_id { get; set; }
        [ForeignKey("contract_id")]
        [RelationalField]
        public virtual Contract? contract { get; set; }

        public long? responsible_id { get; set; }
        [ForeignKey("responsible_id")]
        [RelationalField]
        public virtual User? responsible { get; set; }


        public long? flight_status_id { get; set; }
        [ForeignKey("flight_status_id")]
        [RelationalField]
        public virtual FlightStatus? flightStatus { get; set; }

        public long? schedule_status_id { get; set; }
        [ForeignKey("schedule_status_id")]
        [RelationalField]
        public virtual ScheduleStatus? scheduleStatus { get; set; }

        [RelationalField]
        public virtual List<WorkOrderItem>? workOrderItems { get; set; }


        public long? gate_id { get; set; }

        [ForeignKey("gate_id")]
        [RelationalField]
        public virtual Gate? gate { get; set; }


        public long? company_id { get; set; }

        [ForeignKey("company_id")]
        [RelationalField]
        public virtual Company? company { get; set; }

        #endregion

        public bool? ad_hoc { get; set; }
        public bool? custom_customer { get; set; } = false;
        public bool? inbound_custom_flight_number { get; set; } = false;
        public bool? need_to_be_posted { get; set; } = false;
        public string? custom_customer_name { get; set; }
       // public string? gate { get; set; }
        public string? remark { get; set; }

        [SimpleObjectToString]
        public string? delay { get; set; }
        public string? safety_message { get; set; }
        public string? customer_signature { get; set; }
        public string? customer_name { get; set; }
        public string? customer_title { get; set; }
        public string? representative_signature { get; set; }
        public string? representative_name { get; set; }
        public string? representative_title { get; set; }
        public DateTime? date { get; set; }
        public string? reference_id { get; set; }
        //Inbound
        public string? inbound_flight_number { get; set; }

        public string? inbound_tail_number { get; set; }

        public DateTime? inbound_scheduled_arrival { get; set; }

        public DateTime? inbound_block_in { get; set; }

        [NoUserTimezone]//no convert to user timezone inside transformer
        public DateTime? estimated_on_utc { get; set; }

        public long? inbound_cargo_total_ulds_unloaded { get; set; }

        public long? inbound_cargo_bulk_unloaded { get; set; }

        //Outbound
        public string? outbound_flight_number { get; set; }

        public string? outbound_tail_number { get; set; }

        public DateTime? outbound_scheduled_departure { get; set; }

        public DateTime? outbound_block_out { get; set; }

        [NoUserTimezone] //no convert to user timezone inside transformer
        public DateTime? estimated_off_utc { get; set; }

        [NotMapped]
        public string? calendar_title { get; set; }
        public bool? outbound_custom_flight_number { get; set; }

        public long? outbound_cargo_total_ulds_loaded { get; set; }

        public long? outbound_cargo_bulk_loaded { get; set; }

        public float? cargo_total_kilos_loaded { get; set; }

        public float? cargo_total_kilos_unloaded { get; set; }

        public string? pre_flight_number { get; set; }

        public string? fa_flight_id { get; set; }

        public string? fa_flight_status { get; set; }

        public int? comments { get; set; } = 0;

        public TimeSpan? sta { get; set; }

        public TimeSpan? std { get; set; }

        //Column used in FlyawareMetrics function that stores the flight data
        [ObjectToString]

        public string? flight_position { get; set; }
        [NotMapped]
        public override bool? is_reportable { get; set; } = true;

        [Column(TypeName = "text")]
        [ObjectToString]
        public string? transactions { get; set; }

        [NotMapped]

        public string? flight_status_color
        {
            get
            {
                if (this.flight_status_id != null && this.flightStatus != null)
                {
                    return this.flightStatus.color;
                }
                else
                {
                    return null;
                }

            }
            set 
            {
                if (value != null)
                {
                    flight_status_color = value;
                }
            }
        }


        public override void Initialize()
        {

            //If workOrder doesn't have STD, get the STD time from outbound_scheduled_departure
            if(std == null) std = outbound_scheduled_departure?.TimeOfDay;


            //If workOrder doesn't have STA, get the STA time from inbound_schedule_arrival
            if (sta == null) sta = inbound_scheduled_arrival?.TimeOfDay;

            //Magic column calendar_title set
            List<string?> listColums = new List<string>();
            listColums.Add(pre_flight_number);
            listColums.Add((sta != null ? $"STA {sta.ToString().Replace(":", string.Empty).Substring(0, 6 - 2)}" : string.Empty));
            listColums.Add((std != null ? $"STD {std.ToString().Replace(":", string.Empty).Substring(0, 6 - 2)}" : string.Empty));
            listColums.Add(acType?.model);
            listColums.Add(gate?.name);
            calendar_title = string.Join(" ", listColums);

            if (string.IsNullOrWhiteSpace(calendar_title.Trim())) calendar_title = "No Data!";
        }
    }
}
