using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoixResto.Models
{
    public class Dal : IDal
    {
        private BddContext _bdd;

        public Dal()
        {
            _bdd = new BddContext();
        }

        public void CreerRestaurant(string nom, string telephone)
        {
            _bdd.Restos.Add(new Resto { Nom = nom, Telephone = telephone });
            _bdd.SaveChanges();
        }

        public void Dispose()
        {
            _bdd.Dispose();
        }

        public void ModifierRestaurant(int id, string nom, string telephone)
        {
            var restoTrouve = _bdd.Restos.FirstOrDefault(r => r.Id == id);
            if (restoTrouve != null)
            {
                restoTrouve.Nom = nom;
                restoTrouve.Telephone = telephone;
                _bdd.SaveChanges();
            }
        }

        public List<Resto> ObtientTousLesRestaurants()
        {
            return _bdd.Restos.ToList();
        }
    }
}