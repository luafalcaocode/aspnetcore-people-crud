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
            MapCity();
            MapPerson();

            CreateMap(typeof(Message<>), typeof(Message<>));
            CreateMap(typeof(Expression<>), typeof(Expression<>));
        }    

        public void MapCity()
        {
            CreateMap<CityCreationDto, City>();
            CreateMap<CityDto, City>();

            CreateMap<City, CityDto>();
        }

        public void MapPerson()
        {
            CreateMap<PersonCreationDto, Person>();
            CreateMap<PersonDto, Person>();

            CreateMap<Person, PersonDto>();
        }
    }
}
