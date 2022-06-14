using AutoMapper;
using luafalcao.api.Persistence.DTO;
using luafalcao.api.Persistence.Entities;
using luafalcao.api.Shared.Utils;
using System.Linq.Expressions;

namespace luafalcao.api.Web.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap(typeof(Message<>), typeof(Message<>));
            CreateMap(typeof(Expression<>), typeof(Expression<>));
        }    
    }
}
