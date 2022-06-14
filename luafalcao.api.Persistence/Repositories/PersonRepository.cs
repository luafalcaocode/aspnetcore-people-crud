using luafalcao.api.Persistence.Contexts;
using luafalcao.api.Persistence.Contracts.Repositories;
using luafalcao.api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace luafalcao.api.Persistence.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(BaseContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Person>> GetPeople(int cityId)
        {
            return await FindByCondition(filter => filter.CityId.Equals(cityId))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Person> GetPerson(int cityId, int personId)
        {
            return await FindByCondition(filter => filter.CityId.Equals(cityId) && filter.PersonId.Equals(personId))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public void CreatePersonForCity(int cityId, Person person)
        {
            person.CityId = cityId;
            Create(person);
        }

        public void UpdatePersonForCity(int cityId, Person person)
        {
            person.CityId = cityId;
            Update(person);
        }

        public void DeletePersonForCity(int cityId, Person person)
        {
            person.CityId = person.CityId;
            Delete(person);
        }         
    }
}
