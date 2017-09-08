using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCore.Abstraction.Interface.Mappers
{
    public interface IEntityModelMapper<TEntity,TModel>
    {
        TModel MapFromEntityToModel(TEntity entity);
        IEnumerable<TModel> MapFromEntityRangeToModels(IEnumerable<TEntity> entities);
        TEntity MapFromModelToEntity(TModel model);
        IEnumerable<TEntity> MapFromModelRangeToEntity(IEnumerable<TModel> models);
    }
}
