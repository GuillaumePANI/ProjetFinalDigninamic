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
    [Activity(Label = "ResultActivity")]
    public class ReponseActivity : Activity
    {
        public static int currentPosition;
        public List<ChoixReponse> listeChoixRep;
        public ListView listeReponse;
        public Api waza = new Api();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Reponses);

            listeReponse = FindViewById<ListView>(Resource.Id.List_Reponses);
            var ButtonConfirmer = FindViewById<Button>(Resource.Id.ValidButton);

            var questionId = this.Intent.GetIntExtra("IdQuestion", -1);
            var formulaireId = this.Intent.GetIntExtra("IdFormulaire", -1);

            var formulaire = waza.GetFormulaireById(formulaireId);
            var mesComposants = formulaire.Composant;
            var mesQuestions = mesComposants.Select(a => a.question);
            var maQuestion = mesQuestions.SingleOrDefault(a => a.id == questionId);

            listeReponse.Adapter = new ReponseAdapter(this, maQuestion.Reponse);

            listeReponse.ItemClick += (sender, e) =>
            {
                currentPosition = e.Position;
                var item = ((ReponseAdapter)listeReponse.Adapter)[e.Position];

                //if(listeChoixRep.Contains(item.id)) listeChoixRep.Remove(item.contenu);                
                //else listeChoixRep.Add(item.contenu);
            };

            ButtonConfirmer.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(QuestionActivity));
                intent.PutExtra("IdFormulaire", formulaireId);

                StartActivity(intent);
            };

            

        }
    }
}