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
        TEntity MapFromModelToEntity(TModel model);
    }
}
