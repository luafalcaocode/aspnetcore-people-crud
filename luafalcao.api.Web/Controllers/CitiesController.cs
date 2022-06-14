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
    [Route("api/cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private ICityFacade facade;

        public CitiesController(ICityFacade facade)
        {
            this.facade = facade;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var message = await this.facade.GetAllCities();
            return StatusCode(message.StatusCode, message);
        }

        [HttpGet("{id}", Name = "GetCityById")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var message = await this.facade.GetCity(id);
            return StatusCode(message.StatusCode, message);
        }

        [HttpPost]
        public async Task<IActionResult> PostCity(CityCreationDto city)
        {
            var message = await this.facade.CreateCity(city);

            return CreatedAtRoute("GetCityById", new { Id = message.Data.CityId }, message.Data);            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCity(CityDto city)
        {
            var message = await this.facade.UpdateCity(city);
            return StatusCode(message.StatusCode, message);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCity(CityDto city)
        {
            var message = await this.facade.DeleteCity(city);
            return StatusCode(message.StatusCode, message);
        }
    }
}
