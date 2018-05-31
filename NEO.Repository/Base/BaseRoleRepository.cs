using System;
using System.Collections.Generic;
using System.Text;
using NEO.Core;

namespace NEO.Repository
{
    public class BaseRoleRepository: BaseRepository<BaseRole>
    {
		public BaseRoleRepository(NeoContext context) : base (context)
		{	
		} 
    }
}
