using System;
using System.Collections.Generic;
using System.Text;
using NEO.Core;

namespace NEO.Repository
{
    public class BaseModuleRepository: BaseRepository<BaseModule>
    {
		public BaseModuleRepository(NeoContext context) : base (context)
		{	
		} 
    }
}
