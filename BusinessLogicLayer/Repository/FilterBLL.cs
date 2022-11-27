using BusinessLogicLayer.IRepository;
using DataAccessLayer.IRepository;
using DataAccessLayer.Model;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public class FilterBLL : IFilterBLL
    {

        private readonly IFilterRepo _filterRepo;

        public FilterBLL(IFilterRepo filterRepo)
        {
            _filterRepo = filterRepo;
        }

        // List of all orders
        public List<Person> GetAllOrders()
        {
            return _filterRepo.GetAllOrders();
        }
        // List of orders placed by a specific person (ie: Feehaam/Shuvo/Susmita)
        public List<Tasks> GetAllOrdersBy(string name)
        {
            return _filterRepo.GetAllOrdersBy(name);
        }
        // List of orders for a specific delivery man (ie: Sumon/Shohag)
        public List<Tasks> GetListOfTasksByName(string Name)
        {
            return _filterRepo.GetListOfTasksByName(Name);
        }
        // List of orders completed by a specific delivery man (ie: Sumon/Shohag)
        public List<Tasks> GetListOfCompleTaskByName(string Name)
        {
            return _filterRepo.GetListOfCompleTaskByName(Name);
        }
        // Search by word
        public List<Tasks> SearchByWord(string word)
        {
            return _filterRepo.SearchByWord(word);
        }
    }
}
