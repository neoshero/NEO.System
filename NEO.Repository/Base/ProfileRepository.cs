using System;
using System.Collections.Generic;
using System.Text;
using NEO.Core;

namespace NEO.Repository
{
    public class ProfileRepository: BaseRepository<Profile>
    {
		public ProfileRepository(NeoContext context) : base (context)
		{	
		} 
    }
}
