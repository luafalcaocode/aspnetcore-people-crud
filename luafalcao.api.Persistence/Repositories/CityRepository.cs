using luafalcao.api.Persistence.Contexts;
using luafalcao.api.Persistence.Contracts.Repositories;
using luafalcao.api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace luafalcao.api.Persistence.Repositories
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(BaseContext context) : base(context)
        {

        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await FindAll()
                .ToListAsync();
        }

        public async Task<City> GetCity(int cityId)
        {
            return await FindByCondition(filter => filter.CityId.Equals(cityId))
                .FirstOrDefaultAsync();
        }

        public void CreateCity(City city)
        {
            Create(city);
        }

        public void UpdateCity(City city)
        {
            Update(city);
        }

        public void DeleteCity(City city)
        {
            Delete(city);
        }
    }
}
