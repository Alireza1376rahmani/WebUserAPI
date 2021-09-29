using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserAPI.Model
{
    public class CreateUserCommand
    {
        public string Name { get; set; }
    }

    public class UpdateUserCommand : CreateUserCommand
    {
        public Guid Id { get; set; }
    }
}
