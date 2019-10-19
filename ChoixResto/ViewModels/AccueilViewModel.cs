using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoixResto.ViewModels
{
    public class AccueilViewModel
    {
        public string Messsage { get; set; }
        public DateTime Date { get; set; }
        public List<Models.Resto> Resto { get; set; }
    }
}