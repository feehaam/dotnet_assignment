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
    public class TaskRepo : ITaskRepo
    {
        private readonly DataContext _context;
        private IHelperRepo _helperRepo;

        public TaskRepo(DataContext context)
        {
            _context = context;
            _helperRepo = new HelperRepo(context);
        }

        // ------ TASKS CRUD -------
        // Create new task
        public bool CreateTask(string personName, Tasks task)
        {
            Person person = _helperRepo.GetPersonByName(personName);
            Console.WriteLine(person);
            person.Orders.Add(task);
            _context.Update(person);
            return _helperRepo.Save();
        }
        // Read a task
        public Tasks ReadTask(int id)
        {
            var task = _context.Tasks.First(x => x.Id == id);
            return task;
        }
        // Update task
        public bool UpdateTask(Tasks task)
        {
            try
            {
                _context.Update(task);
                _helperRepo.Save();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        // Delete task
        public bool DeleteTask(int id)
        {
            try
            {
                _context.Remove(ReadTask(id));
                _helperRepo.Save();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
