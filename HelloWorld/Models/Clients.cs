using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Models
{
    public class Clients
    {
        public List<Client> GetListClients()
        {
            return new List<Client>
            {
                new Client {Age = 33, Nom = "Nicola"},
                new Client {Age = 15, Nom = "Maxime"},
                new Client {Age = 65, Nom = "Albert"}
            };
        }
    }
}