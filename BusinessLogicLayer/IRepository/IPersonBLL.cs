using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IRepository
{
    public interface IPersonBLL
    {
        // Person CRUD
        bool CreatePerson(Person person);
        Person ReadPerson(int id);
        bool UpdatePerson(Person person);
        bool DeletePerson(string personName);

        // Tasks CRUD
        bool CreateTask(string personName, Tasks task);
        Tasks ReadTask(int id);
        bool UpdateTask(Tasks task);
        bool DeleteTask(int id);

        // Other required functions
        List<Person> GetAllOrders();
        List<Tasks> GetAllOrdersBy(string name);
        List<Tasks> GetListOfTasksByName(string Name);
        List<Tasks> GetListOfCompleTaskByName(string Name);
        List<Tasks> SearchByWord(string word);

        // Helper functions
        Person GetPersonByName(string name);
        bool PersonExists(string name);
    }
}
