using luafalcao.api.Persistence.Entities;
using System.Collections.Generic;

namespace luafalcao.api.Domain.Singletons
{
    public class PersonCityValidationSingleton
    {
        private static PersonCityValidationSingleton _instance = new PersonCityValidationSingleton();

        private PersonCityValidationSingleton()
        {

        }

        public static PersonCityValidationSingleton GetInstance()
        {
            if (_instance == null)
            {
                return new PersonCityValidationSingleton();
            }

            return _instance;
        }

        public IList<string> PersonAndCityExists(Person person, City city)
        {
            IList<string> validations = new List<string>();

            if (person == null)
            {
                validations.Add("O objeto Pessoa não pode ser enviado como nulo.");
            }           

            if (city == null)
            {
               validations.Add("A cidade com o id informado não existe no banco de dados.");
            }

            return validations;
        }

        public IList<string> CityExists(City city)
        {
            IList<string> validations = new List<string>();

            if (city == null)
            {
                validations.Add("A cidade com o id informado não existe no banco de dados.");
            }

            return validations;
        }

        public IList<string> ValidateCityCreationOrUpdate(City city)
        {
            IList<string> validations = new List<string>();

            if (string.IsNullOrEmpty(city.Name))
            {
                validations.Add("O campo nome deve ser preenchido.");
            }

            if (string.IsNullOrEmpty(city.Uf))
            {
                validations.Add("O campo UF deve ser preenchido.");
            }

            return validations;
        }
    }
}
