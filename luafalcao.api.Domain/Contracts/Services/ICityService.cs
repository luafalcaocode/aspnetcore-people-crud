using luafalcao.api.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace luafalcao.api.Domain.Contracts.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllCities();
        Task<City> GetCity(int cityId);
        Task<City> CreateCity(City city);
        Task UpdateCity(City city);
        Task DeleteCity(City city);
    }
}
