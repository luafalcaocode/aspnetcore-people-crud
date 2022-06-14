using luafalcao.api.Domain.Contracts.Services;
using luafalcao.api.Domain.Singletons;
using luafalcao.api.Persistence.Contracts.Repositories;
using luafalcao.api.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace luafalcao.api.Domain.Services
{
    public class CityService : ICityService
    {
        private IRepositoryManager repository;

        public CityService(IRepositoryManager repository)
        {
            this.repository = repository;
        }

        public async Task<City> CreateCity(City city)
        {
            var validations = PersonCityValidationSingleton.GetInstance().ValidateCityCreationOrUpdate(city);
           
            if (validations.Any())
            {
                throw new Exception(validations.ToString());
            }

            this.repository.City.CreateCity(city);

            await this.repository.Commit();

            return city;
        }

        public async Task DeleteCity(City city)
        {
            var validations = PersonCityValidationSingleton.GetInstance().CityExists(city);

            if (validations.Any())
            {
                throw new Exception(validations.ToString());
            }

            this.repository.City.DeleteCity(city);

            await this.repository.Commit();
        }

        public async Task UpdateCity(City city)
        {
            var validations = PersonCityValidationSingleton.GetInstance().CityExists(city);

            if (validations.Any())
            {
                throw new Exception(validations.ToString());
            }

            this.repository.City.UpdateCity(city);

            await this.repository.Commit();
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await this.repository.City.GetAllCities();
        }

        public async Task<City> GetCity(int cityId)
        {
            return await this.repository.City.GetCity(cityId);
        }
    }
}
