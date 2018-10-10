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
using Newtonsoft.Json;

namespace FormulApp
{
    [Activity(Label = "RecapActivity")]
    public class RecapActivity : Activity
    {
        private ListView ListeRecap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Recap);

            ListeRecap = FindViewById<ListView>(Resource.Id.Liste_recap);
            var ButtonRetour = FindViewById<Button>(Resource.Id.RetourMenu);


            ButtonRetour.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }; 
        }
    }
}