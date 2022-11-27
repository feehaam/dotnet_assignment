using BusinessLogicLayer.IRepository;
using DataAccessLayer.IRepository;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public class PersonBLL : IPersonBLL
    {

        private readonly ITaskRepo _taskRepo;
        private readonly IHelperRepo _helperRepo;
        private readonly IFilterRepo _filterRepo;
        private readonly IPersonRepo _personRepo;
        public PersonBLL(ITaskRepo tasksRepo, IHelperRepo helperRepo, IFilterRepo filterRepo, IPersonRepo personRepo)
        {
            _taskRepo = tasksRepo;
            _helperRepo = helperRepo;
            _filterRepo = filterRepo;
            _personRepo = personRepo;
        }


        // -------PERSON CRUD-------
        // Create person
        public bool CreatePerson(Person person)
        {
            return _personRepo.CreatePerson(person);
        }
        // Read person
        public Person ReadPerson(int id)
        {
            return (_personRepo.ReadPerson(id));
        }
        // Update person
        public bool UpdatePerson(Person person)
        {
            return _personRepo.UpdatePerson(person);
        }
        // Delete person
        public bool DeletePerson(string personName)
        {
            return _personRepo.DeletePerson(personName);
        }


        // -------TASK CRUD-------
        // Create a new task
        public bool CreateTask(string personName, Tasks task)
        {
            return _taskRepo.CreateTask(personName, task);
        }
        // Read task
        public Tasks ReadTask(int id)
        {
            return _taskRepo.ReadTask(id);
        }
        // Update task
        public bool UpdateTask(Tasks task)
        {
            return _taskRepo.UpdateTask(task);
        }
        // Delete task
        public bool DeleteTask(int id)
        {
            return _taskRepo.DeleteTask(id);
        }


        // OTHER REQUIRED FUNCTIONS
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


        // HELPER FUNCTIONS
        public Person GetPersonByName(string name)
        {
            return _helperRepo.GetPersonByName(name);
        }
        public bool PersonExists(string name)
        {
            return _helperRepo.PersonExists(name);
        }
    }
}
