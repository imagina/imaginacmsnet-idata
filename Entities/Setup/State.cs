using Idata.Entities.Core;
using System.ComponentModel.DataAnnotations;

namespace Idata.Data.Entities.Setup
{
    public class State : EntityBase
    {


        //[Required]
        //[Display(Name = "State Name")]
        [MaxLength(200)]
        public string name { get; set; }

        //[Required]
        //[Display(Name = "State Code")]
        [MaxLength(5)]
        public string code { get; set; }
        public long? old_id { get; set; }

    }
}
