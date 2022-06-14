using luafalcao.api.Persistence.DTO;
using luafalcao.api.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace luafalcao.api.Facade.Contracts
{
    public interface ICityFacade
    {
        Task<Message<IEnumerable<CityDto>>> GetAllCities();
        Task<Message<CityDto>> GetCity(int cityId);
        Task<Message<CityDto>> CreateCity(CityCreationDto city);
        Task<Message> UpdateCity(CityDto city);
        Task<Message> DeleteCity(CityDto city);
    }
}
