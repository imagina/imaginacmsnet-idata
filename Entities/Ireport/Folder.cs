using Idata.Data.Entities.Iprofile;
using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Ireport
{
    public partial class Folder : EntityBase
    {

        public Folder()
        {
			searchable_fields = "name,title";
		}

        [Column(TypeName = "VARCHAR(191)")]
        public string name { get; set; } = null!;

        public int? position { get; set; } = null!;

        [Column(TypeName = "VARCHAR(191)")]
        public string title { get; set; } = null!;

        public int? total_reports { get; set; } = 0;

        public bool is_scheduled { get; set; } = false;

        [RelationalField]
        public List<Report>? reports { get; set; }

		[RelationalField]
		public List<User>? users { get; set; }

		[RelationalField]
		public List<Role>? roles { get; set; }
	}
}
