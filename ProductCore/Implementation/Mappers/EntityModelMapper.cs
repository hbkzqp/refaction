using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCore.Abstraction.Interface.Mappers;

namespace ProductCore.Implementation.Mappers
{
    class EntityModelMapper<TEntity, TModel> : IEntityModelMapper<TEntity, TModel>
    {
        private IModelMappper<TEntity,TModel> _entityMappper= new ModelMappper<TEntity, TModel>();
        private IModelMappper<TModel,TEntity> _modelMappper = new ModelMappper<TModel, TEntity>();


        public TModel MapFromEntityToModel(TEntity entity)
        {
            return this._entityMappper.Map(entity);
        }

        public TEntity MapFromModelToEntity(TModel model)
        {
            return this._modelMappper.Map(model);
        }
    }
}
