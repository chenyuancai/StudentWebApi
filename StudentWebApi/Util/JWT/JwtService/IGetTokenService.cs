using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.JWT.JwtService
{
    public interface IGetTokenService
    {
        string Token(string name,string role);
    }
}
