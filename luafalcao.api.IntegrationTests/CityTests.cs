using luafalcao.api.Facade.Contracts;
using luafalcao.api.IntegrationTests.Enums;
using luafalcao.api.IntegrationTests.Factories;
using luafalcao.api.Persistence.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace luafalcao.api.IntegrationTests
{
    [TestFixture]
    public class CityTests
    {
        private ICityFacade cityFacade;

        [SetUp]
        public void Setup()
        {
            cityFacade = FacadeFactory.Create(FacadeTypeEnum.City);
        }

        [Test]
        public async Task CreateCity_WhenCalled_ShouldReturnMessageWithStatusCode201()
        {
            CityCreationDto cityDto = new CityCreationDto
            {
                Name = "Belém",
                Uf = "PA"
            };

            var message = await cityFacade.CreateCity(cityDto);

            Assert.IsNotNull(message);
            Assert.AreEqual(201, message.StatusCode);
            Assert.IsInstanceOf<CityDto>(message.Data);
        }

        [Test]
        public async Task UpdateCity_WhenCalled_ShouldReturnMessageWithStatusCode200()
        {
            CityDto cityDto = new CityDto
            {
                CityId = 1,
                Name = "RIO DE JANEIRO",
                Uf = "RJ"
            };

            var message = await cityFacade.UpdateCity(cityDto);

            Assert.IsNotNull(message);
            Assert.AreEqual(200, message.StatusCode);
        }

        [Test]
        public async Task GetAllCities_WhenCalled_ShouldReturnListOfCitiesWithStatusCode200()
        {
            var message = await cityFacade.GetAllCities();

            Assert.IsNotNull(message);
            Assert.IsInstanceOf<IEnumerable<CityDto>>(message.Data);
            Assert.AreEqual(200, message.StatusCode);
        }

        [Test]
        public async Task GetCity_WhenCalled_ShouldReturnOneCityWithStatusCode200()
        {
            var message = await cityFacade.GetCity(1);

            Assert.IsNotNull(message);
            Assert.IsInstanceOf<CityDto>(message.Data);
            Assert.AreEqual(message.Data.CityId, 1);
            Assert.AreEqual(200, message.StatusCode);
        }

        [Test]
        public async Task DeleteCity_WhenCalled_ShouldReturnMessageWithStatusCode200()
        {
            CityDto cityDto = new CityDto
            {
                CityId = 3,
                Name = "São Paulo",
                Uf = "SP"
            };

            var message = await cityFacade.DeleteCity(cityDto);

            Assert.IsNotNull(message);
            Assert.AreEqual(200, message.StatusCode);
        }
    }
}
