using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Ireport
{
    public class ReportType : EntityBase
    {

        public ReportType()
        {
			searchable_fields = "name,entity,procedure_name";
		}
        public string name { get; set; } = null!;

        public string entity { get; set; } = null!;

        [Column(TypeName = "TEXT")]
        [ObjectToString]
        public string columns { get; set; } = null!;
        [ObjectToString]

        [Column(TypeName = "TEXT")]
        public string filters { get; set; } = null!;
        [ObjectToString]

        [Column(TypeName = "TEXT")]
        public string sort { get; set; } = null!;

        public string? procedure_name { get; set; } = null!;
        //Ignore inside transformer
        [NotMapped]
        [Ignore]
        public JArray? jsonColumns { get; set; }
        [NotMapped]
        [Ignore]
        public JObject? jsonFilters { get; set; }
        [NotMapped]
        [Ignore]
        public JArray? jsonSort { get; set; }
        public override void Initialize()
        {
            jsonColumns = !string.IsNullOrEmpty(columns) ? JArray.Parse(this.columns) : new JArray();
            jsonFilters = !string.IsNullOrEmpty(filters) ? JObject.Parse(this.filters) : new JObject();
            jsonSort = !string.IsNullOrEmpty(sort) ? JArray.Parse(this.sort) : new JArray();

        }
    }
}
