using System.Collections.Generic;
using Domain;
using System;

namespace WebUserAPI.Model
{
    public enum PrincipalPatchType
    {
        JoinToGroup,LeaveGroup
    }

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
    public class PrincipalJoinsToGroupCommand
    {
        public Guid PrincipalId { get; set; }
        public Guid GroupId { get; set; }
    }
    public class PrincipalLeavesGroupCommand : PrincipalJoinsToGroupCommand { }
    public class CreatePrincipalWithGroupsCommand : CreatePrincipalCommand
    {
        public List<Guid> groups { get; set; }
    }
    public class PatchCommand
    {
        public PrincipalPatchType Type { get; set; }
        public List<Guid> Groups { get; set; }
    }
}

