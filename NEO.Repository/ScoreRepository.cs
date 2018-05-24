using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEO.Core;

namespace NEO.Repository
{
    public class ScoreRepository:BaseRepository<Score>
    {
        public ScoreRepository(NeoContext context) : base(context)
        {
        }
    }
}
