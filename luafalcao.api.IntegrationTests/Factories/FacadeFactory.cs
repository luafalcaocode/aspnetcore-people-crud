using AutoMapper;
using luafalcao.api.Domain.Services;
using luafalcao.api.Facade.Facades;
using luafalcao.api.IntegrationTests.Enums;
using luafalcao.api.Persistence.Contexts;
using luafalcao.api.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace luafalcao.api.IntegrationTests.Factories
{
    public class FacadeFactory
    {
        private static string[] assemblies = new string[]
        {
            "luafalcao.api.web"          
        };

        public static dynamic Create(FacadeTypeEnum type)
        {
            IMapper mapper = ConfigureAutoMapper();
            BaseContext context = ConfigureSqlContext();

            switch (type)
            {
                case FacadeTypeEnum.City:
                    return new CityFacade(new CityService(new RepositoryManager(context)), mapper);
                case FacadeTypeEnum.Person:
                    return new PersonFacade(new PersonService(new RepositoryManager(context)), mapper);
            }

            return null;

        }
        private static IMapper ConfigureAutoMapper()
        {
            var mapper = new MapperConfiguration(config =>
            {
                foreach (var assemlyName in assemblies)
                {
                    config.AddMaps(assemlyName);
                }
            });

            return mapper.CreateMapper();
        }

        private static BaseContext ConfigureSqlContext()
        {
            var builder = new DbContextOptionsBuilder<ApplicationContext>();

            builder.UseSqlServer("server=.;database=StefaniniDb;Integrated Security=true");

            ApplicationContext context = new ApplicationContext(builder.Options);

            return context;
        }
    }
}
