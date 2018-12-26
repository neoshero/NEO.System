using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO.Controllers.Role
{
    public class RoleListVM:RoleVM
    {
        //        public int Id { get; set; }
        //
        //        public string Code { get; set; }
        //
        //        public string Name { get; set; }
        //
        //        public bool IsPublic { get; set; }
        //
        //        public bool Enabled { get; set; }
        //
        //        public bool Remark { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ModifyBy { get; set; }

        public DateTime ModifyDate { get; set; }

        public static List<RoleListVM> ConvertToList(List<Core.Role> roles)
        {
            var list = new List<RoleListVM>();
            if (roles != null && roles.Count > 0)
            {
                list.AddRange(roles.Select(t=>new RoleListVM()
                {
                    Id = t.Id,
                    Code = t.Code,
                    Name = t.Name,
                    IsPublish = t.IsPublish,
                    Enabled = t.Enabled,
                    Remark = t.Remark,
                    CreatedBy = t.CreatedBy,
                    CreatedDate = t.CreatedDate,
                    ModifyBy = t.ModifyBy,
                    ModifyDate = t.ModifyDate
                }));
            }
            return list;
        }
    }
}
