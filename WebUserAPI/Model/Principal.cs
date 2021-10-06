using System;

namespace WebUserAPI.Model
{
    public class CreatePrincipalCommand
    {
        public string Name { get; set; }
        public string Type { get; set; }
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
    public class PrincipalJoinsGroupCommand
    {
        public Guid PrincipalId { get; set; }
        public Guid GroupId { get; set; }
    }
    public class PrincipalLeavesGroupCommand : PrincipalJoinsGroupCommand { }
}
