using asingment.Dto;
using BusinessLogicLayer.IRepository;
using DataAccessLayer.IRepository;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("/tasks")]
        public IActionResult GetAllOrder()
        {
            try
            {
                var all = personBLL.GetTasks();
                return Ok(all);
            }
            catch (Exception e)
            {
                return BadRequest("Error parsing all orders! --> " + e.Message);
            }
        }

        [HttpGet("/ordersBy/{name}")]
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

        [HttpGet("/ordersFor/{name}")]
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

        [HttpGet("/completedOrdersFor/{name}")]
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

        [HttpPost("/add/")]
        public IActionResult CreatePerson(Person person)
        {
            try
            {
                if (!personBLL.CreatePerson(person))
                {
                    return BadRequest("Could not create a new entity.");
                }
                return Ok("Creation succesfull!");
            }
            catch (Exception e)
            {
                return BadRequest("Error while creating the entity! --> " + e.Message);
            }
        }
    }
}
