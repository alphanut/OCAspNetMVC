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
                } 
            };

            return View(vm/*r*/);
        }
    }
}