using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.Models
{
    public interface IDal : IDisposable
    {
        List<Resto> ObtientTousLesRestaurants();
        void CreerRestaurant(string nom, string telephone);
        void ModifierRestaurant(int id, string nom, string telephone);
        bool RestaurantExiste(string nom);
        Utilisateur ObtenirUtilisateur(int id);
        Utilisateur ObtenirUtilisateur(string strId);
        int AjouterUtilisateur(string prenom, string password);
        Utilisateur Authentifier(string prenom, string password);
        bool ADejaVote(int idSondage, string strIdUtilisateur);
        int CreerUnSondage();
        void AjouterVote(int idSondage, int idResto, int idUser);
        List<Resultats> ObtenirLesResultats(int idSondage);
    }
}
