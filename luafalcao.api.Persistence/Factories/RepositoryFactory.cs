using luafalcao.api.Persistence.Contexts;
using luafalcao.api.Persistence.Enums;
using luafalcao.api.Persistence.Repositories;

namespace luafalcao.api.Persistence.Factories
{
    public class RepositoryFactory
    {
        public static dynamic Create (RepositoryTypeEnum tipo, BaseContext context)
        {
            switch(tipo)
            {
                case RepositoryTypeEnum.City:
                    return new CityRepository(context);
                case RepositoryTypeEnum.Person:
                    return new PersonRepository(context);
            }

            return null;
        }
    }
}
