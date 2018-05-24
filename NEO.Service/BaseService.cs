using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEO.Repository;

namespace NEO.Service
{
    public class BaseService<T>
    {
        private UnitOfWork _unitOfWork;

        public UnitOfWork UnitOfWork
        {
            get
            {
                if (_unitOfWork == null)
                    _unitOfWork = new UnitOfWork();
                return _unitOfWork;
            }
        }
    }
}
