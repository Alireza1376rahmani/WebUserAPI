using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WebUserAPI.Domain
{
    public abstract class Principal : Entity
    {
        public List<Group> Groups {
            get {
                var readonlyGroups = new List<Group>(Groups);
                return readonlyGroups; }
            set { } }
        public string Name { get; }


        public Principal(Guid id ,string name) : base(id)
        {
            Name = name;
        }

        

    }
}
