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

        public List<Tasks> GetListOfTasksByName(string Name)
        {
            return _taskRepo.GetListOfTasksByName(Name);
        }

        public List<Tasks> GetListOfCompleTaskByName(string Name)
        {
            return _taskRepo.GetListOfCompleTaskByName(Name);
        }

        public Person GetPersonByName(string name)
        {
            return _taskRepo.GetPersonByName(name);
        }

        public List<Person> GetTasks()
        {
            return _taskRepo.GetTasks();
        }

        public bool PersonExists(string name)
        {
            return _taskRepo.PersonExists(name);
        }


        public Tasks GetTaskByID(int id)
        {
            return _taskRepo.GetTaskByID(id);
        }
        public bool CreateTask(string personName, Tasks task)
        {
            return _taskRepo.CreateTask(personName, task);
        }
        public bool DeleteTask(int id)
        {
            return _taskRepo.DeleteTask(id);
        }

    }
}
