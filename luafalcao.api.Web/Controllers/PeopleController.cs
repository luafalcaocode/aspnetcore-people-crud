using luafalcao.api.Facade.Contracts;
using luafalcao.api.Persistence.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace luafalcao.api.Web.Controllers
{
    [Route("api/cities/{cityId}/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPersonFacade facade;

        public PeopleController(IPersonFacade facade)
        {
            this.facade = facade;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int cityId)
        {
            var message = await this.facade.GetAllPeople(cityId);
            return StatusCode(message.StatusCode, message);
        }

        [HttpGet("{id}", Name = "GetPersonById")]
        public async Task<IActionResult> GetPerson(int cityId, int id)
        {
            var message = await this.facade.GetPersonById(cityId, id);
            return StatusCode(message.StatusCode, message);
        }

        [HttpPost]
        public async Task<IActionResult> PostPerson(int cityId, PersonCreationDto person)
        {
            var message = await this.facade.CreatePerson(cityId, person);

            return CreatedAtRoute("GetPersonById", new { CityId = cityId, Id = message.Data.PersonId }, message.Data);
        }

        [HttpPut]
        public async Task<IActionResult> PutPerson(int cityId, PersonDto person)
        {
            var message = await this.facade.UpdatePerson(cityId, person);
            return StatusCode(message.StatusCode, message);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePerson(int cityId, PersonDto person)
        {
            var message = await this.facade.DeletePersonForCity(cityId, person);
            return StatusCode(message.StatusCode, message);
        }
    }
}
