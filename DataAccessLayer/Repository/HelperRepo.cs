using asingment.Model;
using DataAccessLayer.IRepository;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class HelperRepo : IHelperRepo
    {
        private readonly DataContext _context;
        public HelperRepo(DataContext context)
        {
            _context = context;
        }
        // Helper functions
        public Person GetPersonByName(string name)
        {
            return _context.Persons.Where(i => i.Name == name).Include(i => i.Orders).FirstOrDefault();
        }
        public bool PersonExists(string name)
        {
            return _context.Persons.Any(x => x.Name == name);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public Person GetPerson(string name)
        {
            var person = _context.Persons.FirstOrDefault(x => x.Name == name);
            return person;
        }
    }
}
