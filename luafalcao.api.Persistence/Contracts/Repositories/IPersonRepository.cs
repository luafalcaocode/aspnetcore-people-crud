using luafalcao.api.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace luafalcao.api.Persistence.Contracts.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPeople(int cityId);
        Task<Person> GetPerson(int cityId, int personId);
        void CreatePersonForCity(int cityId, Person person);
        void UpdatePersonForCity(int cityId, Person person);
        void DeletePersonForCity(int cityId, Person person);

    }
}
