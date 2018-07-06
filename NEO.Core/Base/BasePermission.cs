using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NEO.Core
{
    public class BasePermission
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public int? ParentModuleId { get; set; } 
        public string Code { get; set; } 
        public string Name { get; set; } 
        public string Remark { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public string CreatedBy { get; set; } 
        public int? CreatedById { get; set; } 
        public DateTime ModifyDate { get; set; } 
        public string ModifyBy { get; set; } 
        public int? ModifyById { get; set; }

        public virtual ICollection<BaseRole> BaseRoles { get; set; }
    }
}
