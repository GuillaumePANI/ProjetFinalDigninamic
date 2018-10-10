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
    public class Composant
    {
        public int idFormulaire { get; set; }
        public int idQuestion { get; set; }
        public int idTypeReponse { get; set; }
        public Question question { get; set; }
    }
}