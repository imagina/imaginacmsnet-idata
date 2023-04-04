using Idata.Data.Entities.Iflight;
using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Setup
{
    public class Customer : EntityBase
    {

        public Customer()
        {

            searchable_fields = "id,customer_name,workday_id";

        }
        //[Required]
        //[Display(Name = "Company")]
        //public int CompanyId { get; set; }

        //[ForeignKey("CompanyId")]
        //public virtual Company Company { get; set; }

        //[Required]
        //[Display(Name = "Customer Name")]
        //[MaxLength(100)]
        public string customer_name { get; set; }

        //[Index(IsUnique = true)]
        //[Display(Name = "WorkDay ID")]
        //[MaxLength(100)]
        public string workday_id { get; set; }

        //[Required]
        //[Display(Name = "Status")]
        public long? customer_status_id { get; set; }
        [ForeignKey("customer_status_id")]
        [RelationalField]
        public CustomerStatus customerStatus { get; set; }

        //[Required]
        //[Display(Name = "Customer Type")]
        public long? customer_type_id { get; set; }
        [ForeignKey("customer_type_id")]
        [RelationalField]
        public CustomerType customerType { get; set; }

        //[Display(Name = "Parent Customer")]
        public long? parent_customer_id { get; set; }

        //[Display(Name = "Airline")]
        public long? airline_id { get; set; }

        [ForeignKey("airline_id")]
        [RelationalField]
        public virtual Airline airline { get; set; }

        //[Display(Name = "Contact 1")]


        //public long? contact1_id { get; set; }

        //[ForeignKey("contact1_id")]
        //public virtual Contact contact_1 { get; set; }




        ////[Display(Name = "Contact 2")]

        //public long? contact2_id { get; set; }

        //[ForeignKey("contact2_id")]
        //public virtual Contact contact_2 { get; set; }





        ////[Display(Name = "Contact 3")]
        //public long? contact3_id { get; set; }

        //[ForeignKey("contact3_id")]
        //public virtual Contact contact_3 { get; set; }




        //[Display(Name = "adhoc_workorders)]
        public bool ad_hoc_work_orders { get; set; }

        [RelationalField]
        public virtual List<Contract> contracts { get; set; }
        //public virtual List<CustomerAirline> CustomerAirlines { get; set; }

        //public virtual List<Contact> Contacts { get; set; }


        public long? old_id { get; set; }
    }
}
