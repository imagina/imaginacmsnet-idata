using Idata.Entities.Core;

namespace Idata.Data.Entities
{
    public partial class Menu : EntityBase
    {
        public string name { get; set; } = null!;
        public bool? primary { get; set; } = false;
        public long? created_by { get; set; }
        public long? updated_by { get; set; }
        public long? deleted_by { get; set; }
        public long? organization_id { get; set; }



    }
}
