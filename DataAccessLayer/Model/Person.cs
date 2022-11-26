using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Tasks> Orders { get; set; }
    }
}
