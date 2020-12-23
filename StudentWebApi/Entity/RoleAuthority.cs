using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Entity
{
    public class RoleAuthority
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int RoleLevel { get; set; }
    }
}
