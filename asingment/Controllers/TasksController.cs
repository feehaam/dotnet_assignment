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
        private readonly IPersonBLL personBLL;
        public TasksController(IPersonBLL _personBLL)
        {
            personBLL = _personBLL;
        }

        // -----PERSON CRUD-----
        // Create a new person
        [HttpPost("/createPerson/")]
        public IActionResult CreatePerson(Person person)
        {
            try
            {
                if (!personBLL.CreatePerson(person))
                {
                    return BadRequest("Duplicate or null! Could not create new entity.");
                }
                return Ok("Creation succesfull!");
            }
            catch (Exception e)
            {
                return BadRequest("Error while creating the entity! --> " + e.Message);
            }
        }
        // Get a person by id
        [HttpGet("/readPerson{personId}")]
        public IActionResult ReadPerson(int personId)
        {
            try
            {
                var person = personBLL.ReadPerson(personId);
                if (person == null) return BadRequest("Person doesn't exist");
                return Ok(person);
            }
            catch (Exception e)
            {
                return NotFound("Error while searching! --> " + e.Message);
            }
        }
        // Update person
        [HttpPost("/updatePerson/")]
        public IActionResult UpdatePerson(Person person)
        {
            try
            {
                if (!personBLL.UpdatePerson(person))
                {
                    return BadRequest("Could not update entity.");
                }
                return Ok("Person Updated!");
            }
            catch (Exception e)
            {
                return BadRequest("Error while updating the entity! --> " + e.Message);
            }
        }
        // Delete person
        [HttpPost("/deletePerson/")]
        public IActionResult DeletePerson(string personName)
        {
            try
            {
                if (!personBLL.DeletePerson(personName))
                {
                    return BadRequest("Could not delete entity.");
                }
                return Ok("Person Deleted!");
            }
            catch (Exception e)
            {
                return BadRequest("Error while deliting the entity! --> " + e.Message);
            }
        }


        // -----TASKS CRUD-----
        // Create a task
        [HttpPost("/createTask/")]
        public IActionResult CreateTask(string personName, Tasks task)
        {
            try
            {
                if (!personBLL.CreateTask(personName, task))
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
                var task = personBLL.ReadTask(id);
                return Ok(task);
            }
            catch (Exception e)
            {
                return BadRequest("Task not found!");
            }
        }
        // Update task
        [HttpPost("/updateTask/")]
        public IActionResult UpdateTask(Tasks task)
        {
            try
            {
                if (!personBLL.UpdateTask(task))
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
        [HttpPost("/deleteTask/{id}")]
        public IActionResult DeleteTask(int id)
        {
            try
            {
                if (!personBLL.DeleteTask(id))
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


        // ------ OTHER REQUIRED API's ------
        // List of all orders
        [HttpGet("/allOrders")]
        public IActionResult GetAllOrder()
        {
            try
            {
                var all = personBLL.GetAllOrders();
                return Ok(all);
            }
            catch (Exception e)
            {
                return BadRequest("Error parsing all orders! --> " + e.Message);
            }
        }
        // List of orders placed by a specific person (ie: Feehaam/Shuvo/Susmita)
        [HttpGet("/ordersPlacedBy/{name}")]
        public IActionResult GetPersonByName(string name)
        {
            try
            {
                var person = personBLL.PersonExists(name);
                if (!person)
                {
                    return NotFound("Person/Entity not found!");
                }
                var res = personBLL.GetPersonByName(name);
                return Ok(res);
            }
            catch (Exception e)
            {
                return NotFound("Error while searching! --> " + e.Message);
            }
        }
        // List of orders for a specific delivery man (ie: Sumon/Shohag)
        [HttpGet("/ordersPlacedFor/{name}")]
        public IActionResult GetListOfTasksByName(string name)
        {
            try
            {
                var tasks = personBLL.GetListOfTasksByName(name);
                return Ok(tasks);
            }
            catch (Exception e)
            {
                return BadRequest("Error parsing tasks! --> " + e.Message);
            }
        }
        // List of orders completed by a specific delivery man (ie: Sumon/Shohag)
        [HttpGet("/ordersCompletedBy/{name}")]
        public IActionResult GetListOfCompletedTasksByName(string name)
        {
            try
            {
                var tasks = personBLL.GetListOfCompleTaskByName(name);
                return Ok(tasks);
            }
            catch (Exception e)
            {
                return BadRequest("Error parsing completed tasks! --> " + e.Message);
            }
        }
    }
}
