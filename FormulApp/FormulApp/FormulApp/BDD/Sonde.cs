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
    public class Sonde
    {
        public int id { get; set; }
        public Nullable<int> age { get; set; }
        public Nullable<bool> sexe { get; set; }
        public string localisation { get; set; }
        //public virtual ICollection<Sondage> Sondage { get; set; }
    }
}