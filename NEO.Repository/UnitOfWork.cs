using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEO.Common.Log;

namespace NEO.Repository
{
    public class UnitOfWork
    {
        private NeoContext _context;

        private NeoContext Context
        {
            get
            {
                if (_context == null)
                    _context = new NeoContext();
                return _context;
            }
        }

        public ScoreRepository ScoreRepository
        {
            get { return new ScoreRepository(Context); }
        }

        public void SaveChanges()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex.ToString());
            }
        }
    }
}
