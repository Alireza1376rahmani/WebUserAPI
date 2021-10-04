using System;
using WebUserAPI.Controllers;
using WebUserAPI.Domain;
using WebUserAPI.Model;

namespace WebUserAPI
{
    public class GroupService
    {
        private IRepository<Group> repo;

        public GroupService(IRepository<Group> repo)
        {
            this.repo = repo;
        }

        public void CreateGroup(CreateGroupCommand command)
        {
            var group = new Group(Guid.NewGuid(), command.Name);
            repo.Create(group);
            repo.Save();
        }

        public void UpdateGroup(UpdateGroupCommand command)
        {
            var group = repo.GetById(command.Id);
            group.UpdateName(command.Name);
            repo.Update(group);
            repo.Save();
        }
    }
}