using System;
using System.Collections.Generic;

namespace WebUserAPI.Model
{
    public class CreatePrincipalCommand
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Guid> Groups { get; set; } = new List<Guid>();
    }
    public class UpdatePrincipalCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class ReadPrincipalCommand
    {
        public Guid Id { get; set; }
    }
    public class DeletePrincipalCommand
    {
        public Guid Id { get; set; }
    }
    public class PrincipalJoinsToGroupCommand
    {
        public Guid PrincipalId { get; set; }
        public Guid GroupId { get; set; }
    }
    public class PrincipalLeavesGroupCommand : PrincipalJoinsToGroupCommand { }
}
