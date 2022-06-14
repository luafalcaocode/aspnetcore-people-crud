using luafalcao.api.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace luafalcao.api.Persistence.Contracts.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllCities();
        Task<City> GetCity(int cityId);
        void CreateCity(City city);
        void UpdateCity(City city);
        void DeleteCity(City city);
    }
}
