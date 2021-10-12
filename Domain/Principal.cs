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

        public Principal(Guid id, string name) : base(id)
        {
            Groups = new List<Group>();
            Name = name;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void AddGroup(Group group)
        {
            Groups.Add(group);
        }

        public void RemoveGroup(Group group)
        {
            Groups.Remove(group);
        }
    }
}
