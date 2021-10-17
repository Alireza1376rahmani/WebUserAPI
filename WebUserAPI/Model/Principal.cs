using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Domain;

namespace WebUserAPI.Model
{
    public  class Principal
    {
        public string Type  { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Principal> Groups { get; set; }
    }
}
