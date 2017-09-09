using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCore.Abstraction.Interface.Mappers
{
    public interface IModelMappper< TOrigin,  TTArget>
    {
        TTArget Map(TOrigin orignalObject);
        IEnumerable<TTArget> MapRange(IEnumerable<TOrigin> orignalObjects);

        void MapToExistedTarget(TOrigin orignalObject, TTArget targetObject);
    }
    
}
