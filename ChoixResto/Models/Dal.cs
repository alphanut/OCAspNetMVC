using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        public int AjouterUtilisateur(string prenom, string password)
        {
            var cryptedPassword = EncodeMD5(password);
            var newUser = new Utilisateur { Prenom = prenom, Password = cryptedPassword };
            _bdd.Utilisateurs.Add(newUser);
            _bdd.SaveChanges();

            return newUser.Id;
        }

        private string EncodeMD5(string password)
        {
            var passwordSel = "ChoixResto" + password + "ASP.Net MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(passwordSel)));
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

        public Utilisateur ObtenirUtilisateur(int id)
        {
            return _bdd.Utilisateurs.FirstOrDefault(u => u.Id == id);
        }

        public Utilisateur ObtenirUtilisateur(string strId)
        {
            int id = 0;
            bool ok = int.TryParse(strId, out id);
            if (!ok)
                return null;

            return _bdd.Utilisateurs.FirstOrDefault(u => u.Id == id);
        }

        public List<Resto> ObtientTousLesRestaurants()
        {
            return _bdd.Restos.ToList();
        }

        public bool RestaurantExiste(string nom)
        {
            return (_bdd.Restos.FirstOrDefault(r => r.Nom == nom) != null);
        }

        public Utilisateur Authentifier(string prenom, string password)
        {
            var passwordCrypte = EncodeMD5(password);
            return _bdd.Utilisateurs.FirstOrDefault(u => u.Prenom == prenom && u.Password == passwordCrypte);
        }

        public bool ADejaVote(int idSondage, string strIdUtilisateur)
        {
            int idVotant = 0;
            if (!int.TryParse(strIdUtilisateur, out idVotant))
                return false;
            var sondage = _bdd.Sondages.FirstOrDefault(s => s.Id == idSondage);
            if (sondage == null)
                return false;
            if (sondage.Votes == null)
                return false;

            var vote = sondage.Votes.FirstOrDefault(v => v.Utilisateur.Id == idVotant);

            return (vote != null);
        }

        public int CreerUnSondage()
        {
            var newSondage = new Sondage() { Date = DateTime.Now };
            _bdd.Sondages.Add(newSondage);
            _bdd.SaveChanges();
            return newSondage.Id;
        }

        public void AjouterVote(int idSondage, int idResto, int idUser)
        {
            var sondage = _bdd.Sondages.FirstOrDefault(s => s.Id == idSondage);
            if (sondage == null)
                return;

            var resto = _bdd.Restos.FirstOrDefault(r => r.Id == idResto);
            if (resto == null)
                return;

            var user = _bdd.Utilisateurs.FirstOrDefault(u => u.Id == idUser);
            if (user == null)
                return;

            if (sondage.Votes == null)
                sondage.Votes = new List<Vote>();

            sondage.Votes.Add(new Vote { Resto = resto, Utilisateur = user });

            _bdd.SaveChanges();
        }

        public List<Resultats> ObtenirLesResultats(int idSondage)
        {
            var resultats = new List<Resultats>();
            var sondage = _bdd.Sondages.FirstOrDefault(s => s.Id == idSondage);
            if (sondage == null || sondage.Votes.Count() == 0)
                return resultats;

            return (from v in sondage.Votes
                    group v by v.Resto into g
                    select new Resultats { Nom = g.First().Resto.Nom, Telephone = g.First().Resto.Telephone, NombreDeVotes = g.Count() }).ToList();
        }
    }
}