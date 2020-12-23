using StudentWebApi.Dao;
using StudentWebApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Service.ServiceImpl
{
    public class StudentServiceImpl : IStudentService
    {
        private StudentDao studentDao = new StudentDao();
        public List<Student> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
