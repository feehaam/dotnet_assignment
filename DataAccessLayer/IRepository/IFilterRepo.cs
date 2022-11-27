using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IFilterRepo
    {
        // Other required search and filter functions
        List<Person> GetAllOrders();
        List<Tasks> GetAllOrdersBy(string name);
        List<Tasks> GetListOfTasksByName(string Name);
        List<Tasks> GetListOfCompleTaskByName(string Name);
        List<Tasks> SearchByWord(string word);
    }
}
