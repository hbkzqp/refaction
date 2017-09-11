using System.Collections.Generic;
using ProductCore.Abstraction.Interface.Mappers;

namespace ProductCore.Implementation.Mappers
{
    public class EntityModelMapper<TEntity, TModel> : IEntityModelMapper<TEntity, TModel>
    {
        private IModelMappper<TEntity, TModel> _entityMappper = new ModelMappper<TEntity, TModel>();
        private IModelMappper<TModel, TEntity> _modelMappper = new ModelMappper<TModel, TEntity>();

        public IEnumerable<TModel> MapFromEntityRangeToModels(IEnumerable<TEntity> entities)
        {
            return _entityMappper.MapRange(entities);
        }

        public TModel MapFromEntityToModel(TEntity entity)
        {
            return _entityMappper.Map(entity);
        }

        public IEnumerable<TEntity> MapFromModelRangeToEntity(IEnumerable<TModel> models)
        {
            return _modelMappper.MapRange(models);
        }

        public TEntity MapFromModelToEntity(TModel model)
        {
            return _modelMappper.Map(model);
        }

        public void MapFromModelToExistEntity(TModel model, TEntity entity)
        {
            _modelMappper.MapToExistedTarget(model, entity);
        }
    }
}
