using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamAPI.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(string userName, string role);
    }
}