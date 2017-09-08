using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCore.Abstraction.Interface.Mappers
{
    interface IModelMappper< TOrigin,  TTArget>
    {
        TTArget Map(TOrigin orignalObject);
        IEnumerable<TTArget> MapRange(IEnumerable<TOrigin> orignalObjects);
    }
    
}
