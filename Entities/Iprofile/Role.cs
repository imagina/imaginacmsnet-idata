using Idata.Data.Entities.Ireport;
using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Iprofile
{
    public partial class Role : EntityBase
    {


        public Role()
        {

        }
        [Column(TypeName = "VARCHAR(191)")]
        public string slug { get; set; } = null!;
        [Column(TypeName = "VARCHAR(191)")]
        public string name { get; set; } = null!;
        [Column(TypeName = "TEXT")]
        [ObjectToString]
        public string? permissions { get; set; } = null!;
        [NotMapped]
        [ObjectToString]
        public object? settings { get; set; } = new { };
        public long? created_by { get; set; }

        public long? updated_by { get; set; }

        public long? deleted_by { get; set; }
        public Guid? external_guid { get; set; }
        [RelationalField]
        public virtual List<User> users { get; set; } = new();

		[RelationalField]
		public virtual List<Folder>? folders { get; set; } 
		[RelationalField]
		public virtual List<Report>? reports { get; set; } 

	}
}
