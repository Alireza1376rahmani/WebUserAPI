using System;

namespace Domain
{
    public abstract class Party : Entity
    {
        public string Name { get; private set; }


        protected Party(Guid id, string name) : base(id)
        {
            Name = name;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}