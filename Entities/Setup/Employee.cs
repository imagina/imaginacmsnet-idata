using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Idata.Data.Entities.Setup
{
    public class Employee : EntityBase
    {
        //[Display(Name = "Location")]
        public long? building_id { get; set; }

        [ForeignKey("building_id")]
        [RelationalField]
        public virtual Building building { get; set; }

        public long? employee_title_id { get; set; }

        [ForeignKey("employee_title_id")]
        [RelationalField]
        public EmployeeTitle employeeTitle { get; set; }

        public bool is_disabled { get; set; }
    }
}
