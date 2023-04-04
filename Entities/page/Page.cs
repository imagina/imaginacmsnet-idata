using Idata.Entities.Core;
using Ihelpers.DataAnotations;

namespace Idata.Data.Entities.Page
{
    public class Page : EntityBase
    {

        public string title { get; set; } = null!;

        public string? template { get; set; }
        public string? record_type { get; set; }
        public string? type { get; set; }
        public string? system_name { get; set; }
        public bool? is_internal { get; set; }
        public bool? is_home { get; set; }
        public long? created_by { get; set; }
        public long? updated_by { get; set; }
        public long? deleted_by { get; set; }
        public long? organization_id { get; set; }
        [RelationalField]
        public List<PageTranslations> translations { get; set; }
    }
}
