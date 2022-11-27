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
        private readonly IPersonRepo _personRepo;

        public PersonBLL(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }

        // Create person
        public bool CreatePerson(Person person)
        {
            return _personRepo.CreatePerson(person);
        }
        // Read person
        public Person ReadPerson(int id)
        {
            return (_personRepo.ReadPerson(id));
        }
        // Update person
        public bool UpdatePerson(Person person)
        {
            return _personRepo.UpdatePerson(person);
        }
        // Delete person
        public bool DeletePerson(string personName)
        {
            return _personRepo.DeletePerson(personName);
        }
    }
}
