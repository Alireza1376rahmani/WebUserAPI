using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserAPI.Domain;

namespace WebUserAPI.Controllers
{
    public class UserRepository : PrincipalRepository<User>
    {    }
}
