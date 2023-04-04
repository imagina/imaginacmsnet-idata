using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Isite
{
    public class Setting : EntityBase
    {
        public string name { get; set; } = null!;
        [Column(TypeName = "TEXT")]
        [ObjectToString]
        public string plain_value { get; set; } = null!;
        public bool? is_translatable { get; set; } = null!;

        public long? created_by { get; set; }

        public long? updated_by { get; set; }

        public long? deleted_by { get; set; }
        [RelationalField]
        public List<SettingTranslation> translations { get; set; }
    }
}
