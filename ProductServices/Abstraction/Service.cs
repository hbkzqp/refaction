using ProductDAL.UnitOfWork;

namespace ProductServices.Abstraction
{
    public abstract class Service
    {
        protected IProductUnitOfWork _productUnitOfWork;
        protected string ConnectionStringOrName;

        public Service(string ConnectionStringOrName)
        {
            this.ConnectionStringOrName = ConnectionStringOrName;
        }

        public Service(IProductUnitOfWork unitOfWork)
        {
            _productUnitOfWork = unitOfWork;
        }
        protected IProductUnitOfWork GetUnitOfWork()
        {
            return _productUnitOfWork != null ? _productUnitOfWork : new ProductUnitOfWork(ConnectionStringOrName);
        }
    }
}
