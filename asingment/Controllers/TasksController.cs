using asingment.Dto;
using BusinessLogicLayer.IRepository;
using DataAccessLayer.IRepository;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Xml.Linq;

namespace asingment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksBLL taskBLL;

        public TasksController(ITasksBLL tasksBLL)
        {
            this.taskBLL = tasksBLL;
        }

        // -----TASKS CRUD-----
        // Create a task
        [HttpPost("/createTask/")]
        public IActionResult CreateTask(string personName, Tasks task)
        {
            try
            {
                if (!taskBLL.CreateTask(personName, task))
                {
                    return BadRequest("Could not create a new task.");
                }
                return Ok("Creation succesfull!");
            }
            catch (Exception e)
            {
                return BadRequest("Error while creating the task! --> " + e.Message);
            }
        }
        // Get/Read a task
        [HttpGet("/readTask/{id}")]
        public IActionResult GetTaskById(int id)
        {
            try
            {
                var task = taskBLL.ReadTask(id);
                return Ok(task);
            }
            catch (Exception e)
            {
                return BadRequest("Task not found!");
            }
        }
        // Update task
        [HttpPut("/updateTask/")]
        public IActionResult UpdateTask(Tasks task)
        {
            try
            {
                if (!taskBLL.UpdateTask(task))
                {
                    return BadRequest("Could not update entity.");
                }
                return Ok("Task Updated!");
            }
            catch (Exception e)
            {
                return BadRequest("Error while updating the entity! --> " + e.Message);
            }
        }
        // Delete task
        [HttpDelete("/deleteTask/{id}")]
        public IActionResult DeleteTask(int id)
        {
            try
            {
                if (!taskBLL.DeleteTask(id))
                {
                    return BadRequest("Could not delete entity.");
                }
                return Ok("Task Deleted!");
            }
            catch (Exception e)
            {
                return BadRequest("Error while deliting the entity! --> " + e.Message);
            }
        }
    }
}
