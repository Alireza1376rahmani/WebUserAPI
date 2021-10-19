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
        public List<Membership> Memberships { get; private set; }
        public Party Party { get; set; }
        public Guid PartyId { get; set; }

        public Principal(Guid id, string name) : base(id)
        {
            Name = name;
            Memberships = new List<Membership>();
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void AddGroup(Group group)
        {
            Memberships.Add(new Membership(group.Id, DateTime.Now));
        }

        public void RemoveGroup(Group group)
        {
            var membership = Memberships.FirstOrDefault(m => m.GroupId == group.Id);
            Memberships.Remove(membership);
        }

    }
}
