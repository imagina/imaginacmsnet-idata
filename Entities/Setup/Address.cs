using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Setup
{
    public class Address : EntityBase
    {


        ////[Required]
        //[Display(Name = "Address 1")]
        [MaxLength(200)]
        public string address_1 { get; set; }

        //[Display(Name = "Address 2")]
        [MaxLength(200)]
        public string address_2 { get; set; }

        //[Display(Name = "Address 3")]
        [MaxLength(200)]
        public string address_3 { get; set; }

        //[Required]
        //[Display(Name = "City")]
        [MaxLength(100)]
        public string city { get; set; }

        public long? state_id { get; set; }
        [ForeignKey("state_id")]
        [RelationalField]
        public virtual State state { get; set; }


        //[Display(Name = "Country")]
        [MaxLength(20)]
        public string country { get; set; }

        //[Display(Name = "ZIP")]
        [MaxLength(50)]
        public string zip { get; set; }

        public virtual string strAddress
        {
            get
            {
                string myAddress;
                if (address_1 == null) return null;

                myAddress = this.address_1 + " " +
                    this.address_2 + " " +
                    this.address_3 + ", " +
                    this.city + ", " +
                    this.state.code + ", " +
                    this.zip + ", " +
                    this.country;

                return myAddress;
            }
        }

        public long? old_id { get; set; }
    }
}
