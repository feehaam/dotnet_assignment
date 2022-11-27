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
    public class TasksBLL : ITasksBLL
    {

        private readonly ITaskRepo _taskRepo;

        public TasksBLL(ITaskRepo tasksRepo)
        {
            _taskRepo = tasksRepo;
        }

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
    }
}
