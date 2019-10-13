using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoTests
{
    public class Generateur : IGenerateur
    {
        private Random r;
        public Generateur()
        {
            r = new Random();
        }

        public int Valeur => r.Next(0, 100);
    }
}