using AutoMapper;
using luafalcao.api.Domain.Contracts.Services;
using luafalcao.api.Facade.Contracts;
using luafalcao.api.Persistence.DTO;
using luafalcao.api.Persistence.Entities;
using luafalcao.api.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luafalcao.api.Facade.Facades
{
    public class PersonFacade : IPersonFacade
    {
        private IPersonService personService;
        private IMapper mapper;

        PersonFacade(IPersonService personService, IMapper mapper)
        {
            this.personService = personService;
            this.mapper = mapper;
        }

        public async Task<Message> CreatePerson(int cityId, PersonCreationDto person)
        {
            var message = new Message();

            try
            {
                await this.personService.CreatePerson(cityId, this.mapper.Map<Person>(person));
            }
            catch(Exception exception)
            {
                message.Error(exception);
            }

            return message;
        }

        public async Task<Message> DeletePersonForCity(int cityId, PersonDto person)
        {
            var message = new Message();

            try
            {
                await this.personService.DeletePerson(cityId, this.mapper.Map<Person>(person));
            }
            catch (Exception exception)
            {
                message.Error(exception);
            }

            return message;
        }

        public async Task<Message> UpdatePerson(int cityId, PersonDto person)
        {
            var message = new Message();

            try
            {
                await this.personService.UpdatePerson(cityId, this.mapper.Map<Person>(person));
            }
            catch (Exception exception)
            {
                message.Error(exception);
            }

            return message;
        }

        public async Task<Message<IEnumerable<PersonDto>>> GetAllPeople(int cityId)
        {
            var message = new Message<IEnumerable<PersonDto>>();

            try
            {
                var people = this.mapper.Map<IEnumerable<PersonDto>>(await this.personService.GetAllPeople(cityId));
                if (!people.Any())
                {
                    message.NotFound();
                }

                message.Ok(people);
            }
            catch (Exception exception)
            {
                message.Error(exception);
            }

            return message;
        }

        public async Task<Message<PersonDto>> GetPersonById(int cityId, int personId)
        {
            var message = new Message<PersonDto>();

            try
            {
                var people = this.mapper.Map<PersonDto>(await this.personService.GetPersonById(cityId, personId));
                if (people == null)
                {
                    message.NotFound();
                }

                message.Ok(people);
            }
            catch (Exception exception)
            {
                message.Error(exception);
            }

            return message;
        }
    }
}
