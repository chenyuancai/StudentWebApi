using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
