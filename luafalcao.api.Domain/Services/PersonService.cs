using luafalcao.api.Domain.Contracts.Services;
using luafalcao.api.Domain.Singletons;
using luafalcao.api.Persistence.Contracts.Repositories;
using luafalcao.api.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luafalcao.api.Domain.Services
{
    public class PersonService : IPersonService
    {
        private IRepositoryManager repository;

        public PersonService(IRepositoryManager repository)
        {
            this.repository = repository;
        }

        public async Task CreatePerson(int cityId, Person person)
        {
            var city = await this.repository.City.GetCity(cityId);

            PersonCityValidationSingleton.GetInstance().PersonAndCityExists(person, city);

            this.repository.Person.CreatePersonForCity(cityId, person);
           
            await this.repository.Commit();
        }

        public async Task DeletePerson(int cityId, Person person)
        {
            var city = await this.repository.City.GetCity(cityId);

            var validations = PersonCityValidationSingleton.GetInstance().PersonAndCityExists(person, city);

            if (validations.Any())
            {
                throw new Exception(validations.ToString());
            }

            this.repository.Person.DeletePersonForCity(cityId, person);

            await this.repository.Commit();            
        }

        public async Task UpdatePerson(int cityId, Person person)
        {
            var city = await this.repository.City.GetCity(cityId);

            var validations = PersonCityValidationSingleton.GetInstance().PersonAndCityExists(person, city);

            if (validations.Any())
            {
                throw new Exception(validations.ToString());                
            }

            this.repository.Person.UpdatePersonForCity(cityId, person);

            await this.repository.Commit();
        }

        public async Task<IEnumerable<Person>> GetAllPeople(int cityId)
        {
            var city = await this.repository.City.GetCity(cityId);

            var validations = PersonCityValidationSingleton.GetInstance().CityExists(city);

            if (validations.Any())
            {
                throw new Exception(validations.ToString());                
            }

            return await this.repository.Person.GetPeople(cityId);
        }

        public async Task<Person> GetPersonById(int cityId, int personId)
        {
            var city = await this.repository.City.GetCity(cityId);

            var validations = PersonCityValidationSingleton.GetInstance().CityExists(city);

            if (validations.Any())
            {
                throw new Exception(validations.ToString());
            }

            return await this.repository.Person.GetPerson(cityId, personId);
        }     
    }
}
