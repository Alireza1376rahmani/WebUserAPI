using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using WebUserAPI.Model.mappings;

namespace WebUserAPI.Model
{
    public  class Principal
    {
        public string Type  { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Membership> Groups { get; set; }
        public Guid? PartyId { get; set; }
        public DateTime? JoinDate { get; set; }
    }

    public class Membership
    {
        public Guid GroupId { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
