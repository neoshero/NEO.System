using System;
using System.Collections.Generic;
using System.Text;
using NEO.Core;

namespace NEO.Repository
{
    public class MemberRepository: BaseRepository<Member>
    {
		public MemberRepository(NeoContext context) : base (context)
		{	
		} 
    }
}
