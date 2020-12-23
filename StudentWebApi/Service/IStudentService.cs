using StudentWebApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Service
{
    public interface IStudentService
    {
        List<Student> GetAll();
    }
}
