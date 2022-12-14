using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IRepository
{
    public interface IPersonBLL
    {
        // Person CRUD
        bool CreatePerson(Person person);
        Person ReadPerson(int id);
        bool UpdatePerson(Person person);
        bool DeletePerson(string personName);
    }
}
