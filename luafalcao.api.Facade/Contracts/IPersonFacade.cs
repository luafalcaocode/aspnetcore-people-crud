using luafalcao.api.Persistence.DTO;
using luafalcao.api.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace luafalcao.api.Facade.Contracts
{
    public interface IPersonFacade
    {
        Task<Message<IEnumerable<PersonDto>>> GetAllPeople(int cityId);
        Task<Message<PersonDto>> GetPersonById(int cityId, int personId);
        Task<Message> CreatePerson(int cityId, PersonCreationDto person);
        Task<Message> UpdatePerson(int cityId, PersonDto person);
        Task<Message> DeletePersonForCity(int cityId, PersonDto person);
    }
}
