using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IRepository
{
    public interface IHelperBLL
    {
        // Helper functions
        Person GetPersonByName(string name);
        bool PersonExists(string name);
    }
}
