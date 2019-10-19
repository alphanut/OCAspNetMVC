using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoixResto.ViewModels
{
    public class HelperViewModel
    {
        public string Messsage { get; set; }
        public DateTime Date { get; set; }
        public Models.Resto Resto { get; set; }
    }
}