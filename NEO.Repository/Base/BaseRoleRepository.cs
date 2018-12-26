using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NEO.Core;

namespace NEO.Repository
{
    public class RoleRepository: BaseRepository<Role>
    {
		public RoleRepository(NeoContext context) : base (context)
		{	
		}

        public Role GetById(int id)
        {
            return DbContext.BaseRole.FirstOrDefault(t => t.Id == id);
        }
    }
}
