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
    public class Formulaire
    {
        public int id { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> dateCreation { get; set; }
        public Nullable<System.DateTime> dateValidation { get; set; }
        public Nullable<System.DateTime> dateCloturation { get; set; }
        public ICollection<Composant> Composant { get; set; }
        public ICollection<Sondage> Sondage { get; set; }
    }
}