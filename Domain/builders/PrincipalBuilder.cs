using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.builders
{
    public abstract class PrincipalBuilder<TPrincipal,TSelf> : EntityBuilder<TPrincipal,TSelf>
        where TPrincipal: Principal
        where TSelf: PrincipalBuilder<TPrincipal, TSelf>
    {

        protected string name = "";

        public PrincipalBuilder<TPrincipal,TSelf> WithName(string name)
        {
            this.name = name;
            return this as TSelf;
        }

    }
}
