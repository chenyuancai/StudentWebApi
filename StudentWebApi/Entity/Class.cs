using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Entity
{
    public class Class
    {
        public int Id { set; get; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
    }
}
