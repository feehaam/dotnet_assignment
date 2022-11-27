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
    public class PersonController : ControllerBase
    {
        private readonly IPersonBLL personBLL;

        public PersonController(IPersonBLL personBLL)
        {
            this.personBLL = personBLL;
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
        [HttpPut("/updatePerson/")]
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
        [HttpDelete("/deletePerson/")]
        public IActionResult DeletePerson(string personName)
        {
            try
            {
                if (!personBLL.DeletePerson(personName))
                {
                    return BadRequest("Could not delete entity. Person with this name may not exist.");
                }
                return Ok("Person Deleted!");
            }
            catch (Exception e)
            {
                return BadRequest("Error while deliting the entity! --> " + e.Message);
            }
        }
    }
}
