using System;
using NEO.Common;

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
        public RoleRepository RoleRepository { get { return new RoleRepository(Context); } }
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
