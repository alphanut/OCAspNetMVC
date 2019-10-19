using ChoixResto.Models;
using ChoixResto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoixResto.Controllers
{
    public class HelperController : Controller
    {
        // GET: Helper
        public ActionResult Index()
        {
            var vm = new HelperViewModel
            {
                Messsage = "Bienvenue dans le Helper Html",
                Date = DateTime.Now,
                Resto = new Resto { Nom = "La bonne cuillère", Telephone = "0251944595" }
            };

            List<Resto> listeDesRestos = new List<Resto>
            {
                new Resto { Id = 1, Nom = "Resto pinambour", Telephone = "1234" },
                new Resto { Id = 2, Nom = "Resto tologie", Telephone = "1234" },
                new Resto { Id = 5, Nom = "Resto ride", Telephone = "5678" },
                new Resto { Id = 9, Nom = "Resto toro", Telephone = "555" },
            };

            ViewBag.ListeDesRestos = new SelectList(listeDesRestos, "Id", "Nom", 5);

            return View(vm);
        }
    }
}