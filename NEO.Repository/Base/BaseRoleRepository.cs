using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NEO.Core;

namespace NEO.Repository
{
    public class BaseRoleRepository: BaseRepository<BaseRole>
    {
		public BaseRoleRepository(NeoContext context) : base (context)
		{	
		}

        public BaseRole GetById(int id)
        {
            return DbContext.BaseRole.FirstOrDefault(t => t.Id == id);
        }
    }
}
