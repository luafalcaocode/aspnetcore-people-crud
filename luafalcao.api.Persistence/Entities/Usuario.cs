using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace luafalcao.api.Persistence.Entities
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
        
        [NotMapped]
        public string Senha {get;set;}

        [NotMapped]        
        public ICollection<string> Perfis { get; set; }
    }
}
