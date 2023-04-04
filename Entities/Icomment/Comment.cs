using Idata.Data.Entities;
using Idata.Data.Entities.Iprofile;
using Idata.Entities.Core;
using Ihelpers.DataAnotations;
using Ihelpers.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idata.Entities.Icomment
{

    public class Comment : EntityBase
    {

        public Comment()
        {
            searchable_fields = "comment,guest_name,guest_email,commentable_type";
        }

        #region relations
    
        [ForeignKey("user_id")]
        [RelationalField]
        public virtual User? userProfile { get; set; }
        #endregion

        [Column(TypeName = "text")]
        public string? comment { get; set; }
        public bool? approved { get; set; }
        public bool? is_internal { get; set; }
        public string? commentable_type { get; set; }
        public long? commentable_id { get; set; }
        public string? guest_name { get; set; }
        public string? guest_email { get; set; }
        public long? user_id { get; set; }

        public override void Initialize()
        {

            //Due to be a new fix, prevent previous strings to stop working
            try
            {
                this.comment = this.comment?.Base64Decode();
            }
            catch
            {

                
            }
            
        }
    }
}
