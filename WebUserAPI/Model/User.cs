using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserAPI.Model
{
    public class CreateUserCommand :ICreate
    {
        public string Name { get; set; }
    }
    public class UpdateUserCommand : IUpdate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class ReadUserCommand :IRead
    {
        public Guid Id { get; set; }
    }
    public class DeleteUserCommand : IDelete
    {
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
