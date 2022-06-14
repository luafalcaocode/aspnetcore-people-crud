using System;
using System.Collections.Generic;
using System.Text;

namespace luafalcao.api.Persistence.DTO
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Age { get; set; }
    }
}
