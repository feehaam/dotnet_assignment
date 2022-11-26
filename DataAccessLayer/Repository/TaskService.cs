using asingment.Model;
using DataAccessLayer.IRepository;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer.Repository
{
    public class TaskService : ITaskService
    {
        private readonly DataContext _context;

        public TaskService(DataContext context)
        {
            _context = context;
        }

        // ------ Person CRUD -------
        // Create new person
        public bool CreatePerson(Person person)
        {
            if (person == null || PersonExists(person.Name))
                return false;
            _context.Add(person);
            return Save();
        }
        // Read person
        public Person ReadPerson(int id)
        {
            var person = _context.Persons.First(x => x.Id == id);
            return person;
        }
        // Update person
        public bool UpdatePerson(Person person)
        {
            try
            {
                Person _person = GetPersonByName(person.Name);
                foreach (var task in _person.Orders)
                {
                    DeleteTask(task.Id);
                }
                _context.Update(person);
                return Save();
            }
            catch (Exception e)
            {
                return false;
            }
        }
        // Delete person
        public bool DeletePerson(string personName)
        {
            try
            {
                Person person = GetPersonByName(personName);
                foreach (var task in person.Orders)
                {
                    DeleteTask(task.Id);
                }
                _context.Remove(GetPerson(personName));
                Save();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public List<Tasks> GetListOfTasksByName(string Name)
        {
            return _context.Tasks.Where(i => i.OrderFor == Name).ToList();
        }


        public List<Tasks> GetListOfCompleTaskByName(string Name)
        {
            var x = _context.Tasks.Where(i => i.IsComplete == true).ToList();
            return x.Where(i => i.OrderFor == Name).ToList();
        }

        public Person GetPersonByName(string name)
        {
            return _context.Persons.Where(i => i.Name == name).Include(i => i.Orders).FirstOrDefault();
        }

        public List<Person> GetTasks()
        {
            return _context.Persons.OrderBy(j => j.Id).Include(i => i.Orders).ToList();
            
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

        private Person GetPerson(string name)
        {
            var person = _context.Persons.FirstOrDefault(x => x.Name == name);
            return person;
        }

        public Tasks GetTaskByID(int id)
        {
            var task = _context.Tasks.First(x => x.Id == id);
            return task;
        }

        public bool CreateTask(string personName, Tasks task)
        {
            Person person = GetPersonByName(personName);
            Console.WriteLine(person);
            person.Orders.Add(task);
            _context.Update(person);
            return Save();
        }
        public bool DeleteTask(int id)
        {
            try
            {
                _context.Remove(GetTaskByID(id));
                Save();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
