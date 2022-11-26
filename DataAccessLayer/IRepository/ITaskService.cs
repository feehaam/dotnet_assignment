
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface ITaskService
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

        List<Person> GetTasks();
        Person GetPersonByName(string name);
        List<Tasks> GetListOfTasksByName(string Name);
        List<Tasks> GetListOfCompleTaskByName(string Name);
        bool PersonExists(string name);
        bool Save();

    }
}
