using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FormulApp
{
    public class Reponse
    {
        public int id { get; set; }
        public string contenu { get; set; }
        public string commentaire { get; set; }
        public int idQuestion { get; set; }
    }
}