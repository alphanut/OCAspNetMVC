using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index(string id)
        {
            return @"<html>
                    <head>
                        <title>Hello World MVC !</title>
                    </head>
                    <body>
                        <p>Hello <span style=""color:red"">" + id + @"</span></p>
                    </body>
                    </html>";
        }

        public ActionResult Index2(string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("Error");

            ViewData["Name"] = id;
            ViewBag.Nom = "Seguin"; // on ne peut pas utiliser Name car déjà utilisé par ViewData
            return View();
        }

        public ActionResult ListeClients()
        {
            var clients = new Clients();
            ViewBag.Clients = clients.GetListClients();
            return View();
        }

        public ActionResult ChercheClient(string id)
        {
            ViewBag.Nom = id;
            var clients = new Clients();
            var client = clients.GetListClients().FirstOrDefault(c => c.Nom == id);
            if (client != null)
            {
                ViewBag.Age = client.Age;
                return View("Trouve");
            }

            return View("NonTrouve");
        }
    }
}