using System;
using System.Collections.Generic;

namespace NEO.Core
{

    public class Role
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsPublish { get; set; }
        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyBy { get; set; }

        public virtual ICollection<BasePermission> BasePermissions { get; set; }

        public virtual ICollection<Member> Members { get; set; }

        public static Role CreateInstance(string code, string name, bool isPublish, bool enabled, string operation)
        {
            return new Role()
            {
                Code = code,
                Name = name,
                IsPublish = isPublish,
                Enabled = enabled,
                CreatedBy = operation,
                CreatedDate = DateTime.UtcNow,
                ModifyBy = operation,
                ModifyDate = DateTime.UtcNow
            };
        }

        public void Edit(string name, bool isPublish, bool enabled,string operation)
        {
            Name = name;
            IsPublish = isPublish;
            Enabled = enabled;
            ModifyBy = operation;
            ModifyDate = DateTime.UtcNow;
        }
    }
}
