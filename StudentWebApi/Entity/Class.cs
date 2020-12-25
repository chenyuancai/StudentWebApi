using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Entity
{
<<<<<<< HEAD
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
=======
    public class Class
    {
        public int Id { set; get; }
        public int TeacherId { get; set; }
>>>>>>> 7a42374069fa5623529170d705a428704a0f046e
        public int StudentId { get; set; }
    }
}
