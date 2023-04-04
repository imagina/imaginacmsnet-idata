using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Setup
{
    public class Gate : EntityBase
    {

        public Gate()
        {

            searchable_fields = "id,name";

        }


        #region relations
        public long? station_id { get; set; }
        [ForeignKey("station_id")]
        [RelationalField]
        public virtual Station station { get; set; }

        public long? area_id { get; set; }
        [ForeignKey("area_id")]
        [RelationalField]
        public virtual Area area { get; set; }
        #endregion


        [MaxLength(200)]
        public string name { get; set; }

    }
}
