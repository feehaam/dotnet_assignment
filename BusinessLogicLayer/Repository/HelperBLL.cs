using BusinessLogicLayer.IRepository;
using DataAccessLayer.IRepository;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public class HelperBLL : IHelperBLL
    {
        private readonly IHelperRepo _helperRepo;

        public HelperBLL(IHelperRepo helperRepo)
        {
            _helperRepo = helperRepo;
        }

        // HELPER FUNCTIONS
        public Person GetPersonByName(string name)
        {
            return _helperRepo.GetPersonByName(name);
        }
        public bool PersonExists(string name)
        {
            return _helperRepo.PersonExists(name);
        }
    }
}
