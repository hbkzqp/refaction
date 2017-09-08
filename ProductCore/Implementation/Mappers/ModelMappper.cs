using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ProductCore.Abstraction.Interface.Mappers;

namespace ProductCore.Implementation.Mappers
{
    public class ModelMappper<TOrigin, TTArget>: IModelMappper<TOrigin, TTArget>
    {
        protected IMapper _mapper = new MapperConfiguration(cfg => cfg.CreateMap<TOrigin, TTArget>()).CreateMapper();
        public TTArget Map(TOrigin orignalObject)
        {
            return this._mapper.Map<TTArget>(orignalObject); ;
        }

        public IEnumerable<TTArget> MapRange(IEnumerable<TOrigin> orignalObjects)
        {
            return orignalObjects.Select(o => this._mapper.Map<TTArget>(o));
        }
    }
}
