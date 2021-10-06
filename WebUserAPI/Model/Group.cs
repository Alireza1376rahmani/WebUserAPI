using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserAPI.Model
{
    public class CreateGroupCommand : ICreate
    {
        public string Name { get; set; }
    }
    public class UpdateGroupCommand : IUpdate
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
    public class ReadGroupCommand : IRead
    {
        public Guid Id { get; set; }
    }
    public class DeleteGroupCommand : IDelete
    {
        public Guid Id { get; set; }
    }
}
