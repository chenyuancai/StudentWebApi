using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Entity
{
    /// <summary>
    /// 学生实体类
    /// </summary>
    public class Student
    {
        /// <summary>
        /// 学生id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 学生生日
        /// </summary>
        public DateTime Birthday { get; set; }
    }
}
