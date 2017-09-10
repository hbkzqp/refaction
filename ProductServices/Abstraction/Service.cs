using ProductDAL.UnitOfWork;

namespace ProductServices.Abstraction
{
    public abstract class Service
    {
        protected IProductUnitOfWork _ProductUnitOfWork;

        public Service(string ConnectionStringOrName)
        {
            this._ProductUnitOfWork = new ProductUnitOfWork(ConnectionStringOrName);
        }

        public Service(IProductUnitOfWork unitOfWork)
        {
            this._ProductUnitOfWork = unitOfWork;
        }
    }
}
