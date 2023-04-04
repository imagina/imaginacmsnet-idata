using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Setup
{
    public class Area : EntityBase
    {

        [MaxLength(200)]
        public string? name { get; set; }

        #region relations
        public long? station_id { get; set; }
        [ForeignKey("station_id")]
        [RelationalField]
        public virtual Station? station { get; set; }

        public long? company_id { get; set; }
        [ForeignKey("company_id")]
        [RelationalField]
        public virtual Company? company { get; set; }
        public virtual List<Gate>? gates { get; set; } 
        #endregion

    }
}
