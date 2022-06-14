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
    public class CityFacade : ICityFacade
    {
        private ICityService cityService;
        private IMapper mapper;

        public CityFacade(ICityService cityService, IMapper mapper)
        {
            this.cityService = cityService;
            this.mapper = mapper;
        }

        public async Task<Message<CityDto>> CreateCity(CityCreationDto city)
        {
            var message = new Message<CityDto>();

            try
            {
                var cityEntityCreated = await this.cityService.CreateCity(this.mapper.Map<City>(city));

                message.Ok(this.mapper.Map<CityDto>(cityEntityCreated));
            }
            catch(Exception exception)
            {
                message.Error(exception);
            }

            return message;

        }

        public async Task<Message> DeleteCity(CityDto city)
        {
            var message = new Message();

            try
            {
                await this.cityService.DeleteCity(this.mapper.Map<City>(city));
                
                message.Ok();
            }
            catch (Exception exception)
            {
                message.Error(exception);
            }

            return message;
        }

        public async Task<Message> UpdateCity(CityDto city)
        {
            var message = new Message();

            try
            {
                await this.cityService.UpdateCity(this.mapper.Map<City>(city));

                message.Ok();
            }
            catch (Exception exception)
            {
                message.Error(exception);
            }

            return message;
        }

        public async Task<Message<IEnumerable<CityDto>>> GetAllCities()
        {
            var message = new Message<IEnumerable<CityDto>>();

            try
            {
                var cities = this.mapper.Map<IEnumerable<CityDto>>(await this.cityService.GetAllCities());
               
                if (!cities.Any())
                {
                    message.NotFound();
                }

                message.Ok(cities);
            }
            catch (Exception exception)
            {
                message.Error(exception);
            }

            return message;
        }

        public async Task<Message<CityDto>> GetCity(int cityId)
        {
            var message = new Message<CityDto>();

            try
            {
                var city = this.mapper.Map<CityDto>(await this.cityService.GetCity(cityId));

                if (city == null)
                {
                    message.NotFound();
                }

                message.Ok(city);
            }
            catch (Exception exception)
            {
                message.Error(exception);
            }

            return message;
        }
    }
}
