﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUserAPI.Domain;

namespace WebUserAPITest
{
    public class TestPrincipal : Principal
    {
        public TestPrincipal(Guid id, string name) : base(id, name) { }


    }
}