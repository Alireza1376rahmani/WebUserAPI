using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Group : Principal
    {
        public List<Principal> Members { get; set; }
       
        public Group(Guid id, string name) : base(id, name) { }
        //public Group(Guid id, string name, List<Principal> Members) : base(id, name)
        //{
        //    this.Members = Members;
        //}
    }
}
