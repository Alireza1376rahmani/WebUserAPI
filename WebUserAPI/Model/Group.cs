using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserAPI.Model
{
    public class CreateGroupCommand :CreateUserCommand { }
    public class UpdateGroupCommand : UpdateUserCommand { }
    public class ReadGroupCommand : ReadUserCommand { }
    public class DeleteGroupCommand : DeleteUserCommand { }
}
