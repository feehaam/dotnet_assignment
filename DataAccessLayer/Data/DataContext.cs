using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace asingment.Model
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

       public DbSet<Person> Persons { get; set; }
       //public DbSet<ServiceMan> ServiceMen { get; set; }
       public DbSet<Tasks> Tasks { get; set; }


    }
}
