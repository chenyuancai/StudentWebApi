using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Entity
{
    /// <summary>
    /// 班级实体类
    /// </summary>
    public class Class
    {
        /// <summary>
        /// 班级id
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 老师id
        /// </summary>
        public int TeacherId { get; set; }
        /// <summary>
        /// 学生id
        /// </summary>
        public int StudentId { get; set; }
    }
}
