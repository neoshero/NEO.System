using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO.Core
{
    public class BaseRoleBasePermisson
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? BaseRoleId { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? BasePermissionId { get; set; }

        public virtual Role Role { get; set; }

        public virtual BasePermission BasePermission { get; set; }
    }
}
