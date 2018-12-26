using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using NEO.Common;
using NEO.Common.Extension;
using NEO.Core;
using NEO.Repository;

namespace NEO.Service
{
    public class RoleService:BaseService<Role>
    {
		public BaseResponse Create(string code,string name, bool isPublish, bool enabled)
		{
			BaseResponse response = new BaseResponse();

		    if (UnitOfWork.RoleRepository.Exists(t => t.Code == code))
		    {
		        response.Code = -1;
		        response.Message = "角色编号已经存在.";
		        return response;
		    }

		    var entity = Role.CreateInstance(code, name, isPublish, enabled, UserContext.UserProfile.Name);

		    UnitOfWork.RoleRepository.Insert(entity);

			return response;
		}

		public BaseResponse Modify(int id,string name, bool isPublish, bool enabled)
		{
			BaseResponse response = new BaseResponse();
		    var role = UnitOfWork.RoleRepository.Get(t => t.Id == id);
		    if (role == null)
		    {
		        response.Code = -1;
		        response.Message = "找不到角色信息.";
		        return response;
		    }
            role.Edit(name,isPublish,enabled,UserContext.UserProfile.Name);

            UnitOfWork.SaveChanges();

		    return response;
		}

        public BaseResponse Delete(int id)
        {
            BaseResponse response = new BaseResponse();
            var role = UnitOfWork.RoleRepository.Get(t => t.Id == id);
            if (role == null)
            {
                response.Code = -1;
                response.Message = "找不到角色信息.";
                return response;
            }
            UnitOfWork.RoleRepository.Delete(role);
            UnitOfWork.SaveChanges();

            return response;
        }

        public Pager<Role> GetPageList(int pageIndex,int pageSize,string code,string name)
		{
		    Expression<Func<Role, bool>> expression = t => !t.Deleted;

            if (!code.IsNullOrEmpty())
            {
                expression.And(t => t.Code.Contains(code));
            }

            if (!name.IsNullOrEmpty())
		    {
		        expression.And(t => t.Name.Contains(name));
		    }

		    Pager<Role> pager = UnitOfWork.RoleRepository.GetPageList(expression, pageIndex, pageSize, t => t.CreatedBy, false);

            return pager;
        }
    }
}
