using System;
using System.Collections.Generic;
using System.Text;
using NEO.Core;

namespace NEO.Repository
{
    public class BasePermissionRepository: BaseRepository<BasePermission>
    {
		public BasePermissionRepository(NeoContext context) : base (context)
		{	
		} 
    }
}
