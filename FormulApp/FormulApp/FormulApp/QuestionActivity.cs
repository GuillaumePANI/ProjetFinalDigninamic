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
    [Activity(Label = "FormulActivity")]
    public class QuestionActivity : Activity
    {
        public ListView listQuestions;
        public Api waza = new Api();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Formulaire);

            listQuestions = FindViewById<ListView>(Resource.Id.List_Formulaire);
            var ButtonValider = FindViewById<Button>(Resource.Id.Formulaire_Valider);

            var formulaireId = this.Intent.GetIntExtra("Id", -1);
            if (formulaireId == -1)
            {                
                formulaireId = this.Intent.GetIntExtra("IdFormulaire", -1);
            }
            var monFormulaire = waza.GetFormulaireById(formulaireId);
            var mesQuestions = monFormulaire.Composant.Select(a => a.question).ToList();

            listQuestions.Adapter = new QuestionAdapter(this, mesQuestions);

            listQuestions.ItemClick += (sender, e) =>
            {
                var item = ((QuestionAdapter)listQuestions.Adapter)[e.Position];
                var intent = new Intent(this, typeof(ReponseActivity));

                intent.PutExtra("IdQuestion", item.id);
                intent.PutExtra("IdFormulaire", formulaireId);
                StartActivity(intent);
            };

            ButtonValider.Click += (sender, e) =>
            {
                var intent1 = new Intent(this, typeof(RecapActivity));
                StartActivity(intent1);
            };
        }
    }
}