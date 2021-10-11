using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserAPI
{
    public static class Guard
    {
        public static void Requires(Func<bool> predicate, string message)
        {
            if (predicate()) return;
              throw new ArgumentException(message);
        }

        [Conditional("DEBUG")]
        public static void Ensures(Func<bool> predicate, string message)
        {
            Requires(predicate,"felan chiz length field"+ message);
        }
    }
}
