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

        private readonly ITaskService _taskRepo;
        public PersonBLL(ITaskService tasksRepo)
        {
            _taskRepo = tasksRepo;
        }


        // -------PERSON CRUD-------
        // Create person
        public bool CreatePerson(Person person)
        {
            return _taskRepo.CreatePerson(person);
        }
        // Read person
        public Person ReadPerson(int id)
        {
            return (_taskRepo.ReadPerson(id));
        }
        // Update person
        public bool UpdatePerson(Person person)
        {
            return _taskRepo.UpdatePerson(person);
        }
        // Delete person
        public bool DeletePerson(string personName)
        {
            return _taskRepo.DeletePerson(personName);
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
            return _taskRepo.GetAllOrders();
        }
        // List of orders placed by a specific person (ie: Feehaam/Shuvo/Susmita)
        public List<Tasks> GetAllOrdersBy(string name)
        {
            return _taskRepo.GetAllOrdersBy(name);
        }
        // List of orders for a specific delivery man (ie: Sumon/Shohag)
        public List<Tasks> GetListOfTasksByName(string Name)
        {
            return _taskRepo.GetListOfTasksByName(Name);
        }
        // List of orders completed by a specific delivery man (ie: Sumon/Shohag)
        public List<Tasks> GetListOfCompleTaskByName(string Name)
        {
            return _taskRepo.GetListOfCompleTaskByName(Name);
        }
        // Search by word
        public List<Tasks> SearchByWord(string word)
        {
            return _taskRepo.SearchByWord(word);
        }


        // HELPER FUNCTIONS
        public Person GetPersonByName(string name)
        {
            return _taskRepo.GetPersonByName(name);
        }
        public bool PersonExists(string name)
        {
            return _taskRepo.PersonExists(name);
        }
    }
}
