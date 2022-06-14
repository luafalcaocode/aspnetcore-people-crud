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
    [Route("api/cities/{cityId}/person")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonFacade facade;

        public PersonsController(IPersonFacade facade)
        {
            this.facade = facade;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPeople(int cityId)
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
            return StatusCode(message.StatusCode, message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson(int cityId, PersonDto person)
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
