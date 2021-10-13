using Domain;
using System;
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

        public void CreateGroup(CreatePrincipalCommand command)
        {
            var group = new Group(Guid.NewGuid(), command.Name);
            repo.Create(group);
            repo.Save();
        }

        public void UpdateGroup(UpdatePrincipalCommand command)
        {
            var group = repo.GetById<Group>(command.Id);
            group.UpdateName(command.Name);
            repo.Update(group);
            repo.Save();
        }
    }
}