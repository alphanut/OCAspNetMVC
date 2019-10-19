using ChoixResto.Models;
using ChoixResto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoixResto.Controllers
{
    public class AccueilController : Controller
    {
        // GET: Accueil
        public ActionResult Index()
        {
            ViewData["message"] = "Bonjour depuis le contrôleur";
            ViewData["date"] = DateTime.Now;
            ViewData["resto"] = new Resto { Nom = "Choucroute party", Telephone = "1234" };

            var r = new Resto() { Nom = "La bonne fourchette", Telephone = "1234" };

            var vm = new AccueilViewModel { 
                Messsage = "Bonjour: création de la vue avec une ViewModel", 
                Date = DateTime.Now, 
                Resto = new List<Resto>
                {
                    new Resto {Nom="La bonne fourchette", Telephone="1234"},
                    new Resto {Nom="Patio", Telephone="5678"},
                    new Resto {Nom="Ballon d'Alsace", Telephone="9875"}
                },
                Login = "Nicolas"
            };

            return View(vm/*r*/);
        }

        [ChildActionOnly]
        public ActionResult AfficheListeRestaurant()
        {
            List<Resto> listeDesRestos = new List<Resto>
            {
                new Resto { Id = 1, Nom = "Resto pinambour", Telephone = "1234" },
                new Resto { Id = 2, Nom = "Resto tologie", Telephone = "1234" },
                new Resto { Id = 5, Nom = "Resto ride", Telephone = "5678" },
                new Resto { Id = 9, Nom = "Resto toro", Telephone = "555" },
            };

            return PartialView(listeDesRestos);
        }

        [ChildActionOnly]
        public ActionResult AfficherAvecHelperHtmlRaw()
        {
            var vm = new AccueilViewModel
            {
                Messsage = "Bonjour depuis le <span style=\"color:red\">contrôleur</span>"
            };

            return PartialView(vm);
        }
    }
}