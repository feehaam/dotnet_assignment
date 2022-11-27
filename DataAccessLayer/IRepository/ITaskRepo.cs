
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface ITaskRepo
    {
        // Tasks CRUD
        bool CreateTask(string personName, Tasks task);
        Tasks ReadTask(int id);
        bool UpdateTask(Tasks task);
        bool DeleteTask(int id);
    }
}
