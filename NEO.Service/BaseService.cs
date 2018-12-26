using NEO.Repository;

namespace NEO.Service
{
    public class BaseService<T>
    {
        private UnitOfWork _unitOfWork;

        protected UnitOfWork UnitOfWork
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
