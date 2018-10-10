using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FormulApp
{   
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public ListView listeFormulaire;
        public Api waza = new Api();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);           

            var ButtonCo = FindViewById<Button>(Resource.Id.main_BoutonCo);
            //var ButtonSearch = FindViewById<Button>(Resource.Id.main_Search);
            listeFormulaire = FindViewById<ListView>(Resource.Id.main_Liste);

            listeFormulaire.Adapter = new FormulAdapter(this, waza.GetFormulaire());
            var abc = ReponseActivity.currentPosition;

            listeFormulaire.ItemClick += (sender, e) =>
            {
                var item = ((FormulAdapter)listeFormulaire.Adapter)[e.Position];
                var intent = new Intent(this, typeof(QuestionActivity));

                intent.PutExtra("Id", item.id);
                StartActivity(intent);
            };
        }
    }
}

