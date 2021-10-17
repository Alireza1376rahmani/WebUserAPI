using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public abstract class Principal : Entity
    {


        [Required]
        public string Name { get; private set; }
        public List<Group> Groups => memberships.Select(x => x.Group).ToList();

        private List<Membership> memberships;

        public Principal(Guid id, string name) : base(id)
        {
            Name = name;
            memberships = new List<Membership>();
        }

        public Principal() { }

        //public Principal(Guid id, string name, List<Group> groups) : base(id)
        //{
        //    Groups = new List<Group>();
        //    Name = name;
        //    memberships = new List<Membership>();
        //    foreach (Group group in groups)
        //    {
        //        memberships.Add(new Membership(this.Id, group.Id));
        //    }
        //}

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void AddGroup(Group group)
        {
            memberships.Add(new Membership(this, group));
        }

        public void RemoveGroup(Group group)
        {
            var membership = memberships.FirstOrDefault(m => m.GroupId == group.Id);
            memberships.Remove(membership);
        }
    }
}
