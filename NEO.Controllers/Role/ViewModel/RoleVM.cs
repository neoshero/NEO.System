using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO.Controllers.Role
{
    public class RoleVM
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool IsPublish { get; set; }

        public bool Enabled { get; set; }

        public string Remark { get; set; }
    }
}
