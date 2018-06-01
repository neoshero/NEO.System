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

        public BaseModuleRepository BaseModuleRepository { get { return new BaseModuleRepository(Context); } }
        public BasePermissionRepository BasePermissionRepository { get { return new BasePermissionRepository(Context); } }
        public BaseRoleRepository BaseRoleRepository { get { return new BaseRoleRepository(Context); } }
        public MemberRepository MemberRepository { get { return new MemberRepository(Context); } }
        public OrganizationRepository OrganizationRepository { get { return new OrganizationRepository(Context); } }
        public ProfileRepository ProfileRepository { get { return new ProfileRepository(Context); } }


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
