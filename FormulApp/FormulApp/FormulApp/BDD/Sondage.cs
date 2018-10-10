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
    public class Sondage
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public Nullable<int> idFormulaire { get; set; }
        //public Nullable<int> idSonde { get; set; }
        public ICollection<ChoixReponse> ChoixReponse { get; set; }
        public Sonde Sonde { get; set; }
    }
}