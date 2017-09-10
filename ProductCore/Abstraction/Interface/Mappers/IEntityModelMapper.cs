using System.Collections.Generic;

namespace ProductCore.Abstraction.Interface.Mappers
{
    public interface IEntityModelMapper<TEntity, TModel>
    {
        TModel MapFromEntityToModel(TEntity entity);
        IEnumerable<TModel> MapFromEntityRangeToModels(IEnumerable<TEntity> entities);
        TEntity MapFromModelToEntity(TModel model);
        IEnumerable<TEntity> MapFromModelRangeToEntity(IEnumerable<TModel> models);
        void MapFromModelToExistEntity(TModel model, TEntity entity);
    }
}
