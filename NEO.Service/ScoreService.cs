using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEO.Core;
using NEO.Repository;

namespace NEO.Service
{
    public class ScoreService:BaseService<Score>
    {
        public BaseResponse CreateInstance()
        {
            BaseResponse response = new BaseResponse();
            var entity = new Score() { Id = 99,Name = "Korean"};
            UnitOfWork.ScoreRepository.Insert(entity);
            var state = UnitOfWork.ScoreRepository.GetEntityState(entity);
            UnitOfWork.SaveChanges();

            return response;
        }
    }
}
