using System;
using System.Collections.Generic;
using System.Text;
using NEO.Core;

namespace NEO.Repository
{
    public class OrganizationRepository: BaseRepository<Organization>
    {
		public OrganizationRepository(NeoContext context) : base (context)
		{	
		} 
    }
}
