using asingment.Model;
using DataAccessLayer.IRepository;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class PersonRepo : IPersonRepo
    {
        private readonly DataContext _context;
        private IHelperRepo _helperRepo;
        private ITaskRepo _taskRepo;

        public PersonRepo(DataContext context)
        {
            _context = context;
            _helperRepo = new HelperRepo(context);
            _taskRepo = new TaskRepo(context);
        }
        // ------ PERSON CRUD -------
        // Create new person
        public bool CreatePerson(Person person)
        {
            if (person == null || _helperRepo.PersonExists(person.Name))
                return false;
            _context.Add(person);
            return _helperRepo.Save();
        }
        // Read person
        public Person ReadPerson(int id)
        {
            var person = _context.Persons.First(x => x.Id == id);
            return person;
        }
        // Update person
        /*
        // For some reason this updataing is not working...
        public bool UpdatePerson(Person person)
        {
            try
            {
                Person _person = GetPersonByName(person.Name);
                foreach (var task in _person.Orders)
                {
                    DeleteTask(task.Id);
                }
                person = _person;
                _context.Update(person);
                return Save();
            }
            catch (Exception e)
            {
                return false;
            }
        }
        */
        // An alternative manual way
        public bool UpdatePerson(Person person)
        {
            try
            {
                DeletePerson(person.Name);
                CreatePerson(person);
                return true;
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
                Person person = _helperRepo.GetPersonByName(personName);
                foreach (var task in person.Orders)
                {
                    _taskRepo.DeleteTask(task.Id);
                }
                _context.Remove(_helperRepo.GetPerson(personName));
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
