using EntityFramwork_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramwork_Test.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Operator> Operator { get; set; }
    }
}
