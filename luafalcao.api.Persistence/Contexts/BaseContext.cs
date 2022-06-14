using luafalcao.api.Persistence.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace luafalcao.api.Persistence.Contexts
{
    public class BaseContext : IdentityDbContext<Usuario>
    {
        public BaseContext(DbContextOptions options) : base(options)
        {

        }      
    }
}
