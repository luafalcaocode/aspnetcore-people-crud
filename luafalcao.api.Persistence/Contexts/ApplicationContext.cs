using luafalcao.api.Persistence.Configurations;
using luafalcao.api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace luafalcao.api.Persistence.Contexts
{
    public class ApplicationContext : BaseContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<Person>(new PersonConfiguration());
            builder.ApplyConfiguration<City>(new CityConfiguration());

            base.OnModelCreating(builder);
        }
     

        public DbSet<City> City { get; set; }
        public DbSet<Person> Person {get;set;}
    }
}
