using System;

namespace Domain
{
    public abstract class Party : Entity
    {
        public string Name { get; set; }

        protected Party() { }
        protected Party(Guid id, string name) : base(id)
        {
            Name = name;
        }


    }
}