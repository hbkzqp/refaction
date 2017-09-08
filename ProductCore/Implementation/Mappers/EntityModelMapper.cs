using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCore.Abstraction.Interface.Mappers;

namespace ProductCore.Implementation.Mappers
{
    public class EntityModelMapper<TEntity, TModel> : IEntityModelMapper<TEntity, TModel>
    {
        private IModelMappper<TEntity,TModel> _entityMappper= new ModelMappper<TEntity, TModel>();
        private IModelMappper<TModel,TEntity> _modelMappper = new ModelMappper<TModel, TEntity>();

        public IEnumerable<TModel> MapFromEntityRangeToModels(IEnumerable<TEntity> entities)
        {
            return this._entityMappper.MapRange(entities);
        }

        public TModel MapFromEntityToModel(TEntity entity)
        {
            return this._entityMappper.Map(entity);
        }

        public IEnumerable<TEntity> MapFromModelRangeToEntity(IEnumerable<TModel> models )
        {
            return this._modelMappper.MapRange(models);
        }

        public TEntity MapFromModelToEntity(TModel model)
        {
            return this._modelMappper.Map(model);
        }
    }
}
