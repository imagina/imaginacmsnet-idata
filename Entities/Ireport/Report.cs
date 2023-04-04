using ChoETL;
using Idata.Data.Entities.Iprofile;
using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq.Expressions;

namespace Idata.Data.Entities.Ireport
{
    public class Report : EntityBase
    {
        public Report()
        {
            searchable_fields = "description,title,entity";

		}
        public string? entity { get; set; } = null;

        public long? report_type_id { get; set; } = null;

        public long? folder_id { get; set; } = null;

        public string? title { get; set; } = null;

        public string? description { get; set; } = null;

        [Column(TypeName = "TEXT")]
        [ObjectToString]
        public string? emails { get; set; } = null!;
        public string? format { get; set; } = null;
        [Column(TypeName = "TEXT")]
        [ObjectToString]
        public string? columns { get; set; } = null;
        [Column(TypeName = "TEXT")]
        [ObjectToString]
        public string? filters { get; set; } = null;
        [Column(TypeName = "TEXT")]
        [ObjectToString]
        public string? sort { get; set; } = null;
        [Column(TypeName = "TEXT")]
        [ObjectToString]
        public string? schedule { get; set; } = null;


        [RelationalField]
        [ForeignKey("folder_id")]
        public Folder? folder { get; set; }

        [RelationalField]
        [ForeignKey("report_type_id")]
        public ReportType? reportType { get; set; }

		[RelationalField]
		public List<User>? users { get; set; }

		[RelationalField]
		public List<Role>? roles { get; set; }

		[NotMapped]
        [Ignore]
        public JArray? jsonColumns { get; set; }
        [NotMapped]
        [Ignore]
        public JObject? jsonFilters { get; set; }
        [NotMapped]
        [Ignore]
        public JObject? jsonSort { get; set; }
        public override void Initialize()
        {
            jsonColumns = !string.IsNullOrEmpty(columns) ? JArray.Parse(this.columns) : new JArray();
            jsonFilters = !string.IsNullOrEmpty(filters) ? ParseFilters() : new JObject();
            jsonSort = !string.IsNullOrEmpty(sort) ? JObject.Parse(this.sort) : new JObject();
            reportType?.Initialize();

        }


        private JObject? ParseFilters()
        {
            var currentFilters = JObject.Parse(this.filters);

            var dateFilter = currentFilters["date"];

            currentFilters.Remove("date");

            var obj = new JObject();

            foreach(var prop in currentFilters.Properties().ToList())
            {
                obj[prop.Name.ToCamelCase()] = prop.Value;
            }


            if (dateFilter != null)
            {
                obj["date"] = dateFilter;
            }

            return JObject.FromObject(obj);

        }

        
    }
}
