using luafalcao.api.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace luafalcao.api.Domain.Contracts.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllPeople(int cityId);
        Task<Person> GetPersonById(int cityId, int personId);
        Task<Person> CreatePerson(int cityId, Person person);
        Task UpdatePerson(int cityId, Person person);
        Task DeletePerson(int cityId, Person person);
    }
}
