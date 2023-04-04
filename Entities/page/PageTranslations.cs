using Idata.Entities.Core;
using Ihelpers.DataAnotations;

namespace Idata.Data.Entities.Page
{
    public class PageTranslations : EntityBase
    {
        public string? title { get; set; } = null!;
        public string? slug { get; set; } = null!;
        public bool? status { get; set; } = null!;
        public string? body { get; set; } = null!;
        public string? meta_title { get; set; } = null!;
        public string? meta_description { get; set; } = null!;
        public string? og_title { get; set; } = null!;
        public string? og_description { get; set; } = null!;
        public string? og_image { get; set; } = null!;
        public string? og_type { get; set; } = null!;
        public string? content { get; set; } = null!;
        public long PageId { get; set; }
        public string locale { get; set; } = null!;
        [RelationalField]
        public Page page { get; set; } = null!;

    }
}
