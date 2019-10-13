using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoTests
{
    public class MathHelper
    {
        public static long Factorielle(int n)
        {
            if (n <= 1)
                return 1;

            return n * Factorielle(n - 1);
        }
    }
}