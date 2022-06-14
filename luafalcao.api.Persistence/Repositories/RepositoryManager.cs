using luafalcao.api.Persistence.Contexts;
using luafalcao.api.Persistence.Contracts.Repositories;
using luafalcao.api.Persistence.Enums;
using luafalcao.api.Persistence.Factories;
using System.Threading.Tasks;

namespace luafalcao.api.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private ICityRepository city { get; set; }
        private IPersonRepository person { get; set; }

        private ApplicationContext contexto { get; set; }

        public ICityRepository City
        {
            get
            {
                if (this.city == null)
                {
                    return RepositoryFactory.Create(RepositoryTypeEnum.City, contexto);
                }

                return this.city;
            }
        }

        public IPersonRepository Person
        {
            get
            {
                if (this.person == null)
                {
                    return RepositoryFactory.Create(RepositoryTypeEnum.Person, contexto);
                }

                return this.person;
            }
        }

        public RepositoryManager(ApplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task Commit()
        {
            await contexto.SaveChangesAsync();
        }
    }
}
