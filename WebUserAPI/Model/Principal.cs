using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserAPI.Model
{

    public interface ICreate
    {
        public string Name { get; set; }
    }
    public interface IUpdate : ICreate
    {
        public Guid Id { get; set; }
    }
    public interface IRead
    {
        public Guid Id { get; set; }
    }
    public interface IDelete
    {
        public Guid Id { get; set; }
    }

    public class PrincipalJoinsGroupCommand
    {
        public Guid PrincipalId { get; set; }
        public Guid GroupId { get; set; }
    }

    public class PrincipalLeavesGroupCommand : PrincipalJoinsGroupCommand { }
}
