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
    public class FilterRepo : IFilterRepo
    {
        private readonly DataContext _context;

        public FilterRepo(DataContext context)
        {
            _context = context;
        }

        // OTHER REQUIRED FUNCTIONS
        // List of all orders
        public List<Person> GetAllOrders()
        {
            return _context.Persons.OrderBy(j => j.Id).Include(i => i.Orders).ToList();
        }
        // List of orders placed by a specific person (ie: Feehaam/Shuvo/Susmita)
        public List<Tasks> GetAllOrdersBy(string name)
        {
            return (_context.Persons.Where(i => i.Name == name).Include(i => i.Orders).FirstOrDefault()).Orders;
        }
        // List of orders for a specific delivery man (ie: Sumon/Shohag)
        public List<Tasks> GetListOfTasksByName(string Name)
        {
            return _context.Tasks.Where(i => i.OrderFor == Name).ToList();
        }
        // List of orders completed by a specific delivery man (ie: Sumon/Shohag)
        public List<Tasks> GetListOfCompleTaskByName(string Name)
        {
            var x = _context.Tasks.Where(i => i.IsComplete == true).ToList();
            return x.Where(i => i.OrderFor == Name).ToList();
        }
        // Search by word
        public List<Tasks> SearchByWord(string word)
        {
            var x = _context.Tasks.Where(i => i.TaskName.Contains(word)).ToList();
            return x;
        }
    }
}
