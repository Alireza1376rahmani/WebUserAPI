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
        public List<Group> Groups { get; set; }

        private List<Membership> memberships;

        public Principal(Guid id, string name) : base(id)
        {
            Groups = new List<Group>();
            Name = name;
            memberships = new List<Membership>();
        }

        public Principal() { }

        public Principal(Guid id, string name, List<Group> groups) : base(id)
        {
            Groups = new List<Group>();
            Name = name;
            memberships = new List<Membership>();
            foreach (Group group in groups)
            {
                memberships.Add(new Membership(this.Id, group.Id));
            }
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void AddGroup(Group group)
        {
            Groups.Add(group);
            memberships.Add(new Membership(Id, group.Id));
        }

        public void RemoveGroup(Group group)
        {
            memberships.Remove(new Membership(Id, group.Id));
            Groups.Remove(group);
        }
    }
}
