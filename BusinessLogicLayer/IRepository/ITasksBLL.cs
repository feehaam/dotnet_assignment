using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IRepository
{
    public interface ITasksBLL
    {
        // Tasks CRUD
        bool CreateTask(string personName, Tasks task);
        Tasks ReadTask(int id);
        bool UpdateTask(Tasks task);
        bool DeleteTask(int id);
    }
}
