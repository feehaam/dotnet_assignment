using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IHelperRepo
    {
        // Helper functions
        Person GetPersonByName(string name);
        Person GetPerson(string name);
        bool PersonExists(string name);
        bool Save();
    }
}
