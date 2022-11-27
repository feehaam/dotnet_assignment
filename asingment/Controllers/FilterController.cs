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
    public class FilterController : ControllerBase
    {
        private readonly IFilterBLL filterBLL;
        private readonly IHelperBLL helperBLL;

        public FilterController(IFilterBLL filterBLL, IHelperBLL helperBLL)
        {
            this.filterBLL = filterBLL;
            this.helperBLL = helperBLL;
        }

        // ------ Filter and searching controllers ------
        // List of all orders
        [HttpGet("/allOrders")]
        public IActionResult GetAllOrder()
        {
            try
            {
                var all = filterBLL.GetAllOrders();
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
                var personExist = helperBLL.PersonExists(name);
                if (!personExist)
                {
                    return NotFound("Person/Entity not found!");
                }
                var res = helperBLL.GetPersonByName(name);
                var list = res.Orders;
                return Ok(list);
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
                var tasks = filterBLL.GetListOfTasksByName(name);
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
                var tasks = filterBLL.GetListOfCompleTaskByName(name);
                return Ok(tasks);
            }
            catch (Exception e)
            {
                return BadRequest("Error parsing completed tasks! --> " + e.Message);
            }
        }
        // Search by words
        [HttpGet("/seachByWord/{word}")]
        public IActionResult SeachByWords(string word)
        {
            try
            {
                var tasks = filterBLL.SearchByWord(word);
                return Ok(tasks);
            }
            catch (Exception e)
            {
                return BadRequest("Error while searching! --> " + e.Message);
            }
        }
    }
}
