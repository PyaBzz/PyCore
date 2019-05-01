using PyaFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ToReorganise
{
    public class Thing : IClonable
    {
        public Guid Id { get; set; }
    }
}
