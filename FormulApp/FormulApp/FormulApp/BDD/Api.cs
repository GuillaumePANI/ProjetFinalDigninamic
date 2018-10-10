using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FormulApp
{
    public class Api
    {
        public List<Formulaire> GetFormulaire()
        {           
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var contenu = client.GetAsync("http://satisfactionsurveyapi.azurewebsites.net/api/FormulaireApi").Result;

            //if (contenu.IsSuccessStatusCode)
            //{
                var abc = contenu.Content.ReadAsStringAsync().Result;
                var bcd = JsonConvert.DeserializeObject<List<Formulaire>>(abc);
            //}
            
            return bcd;
        }

        public Formulaire GetFormulaireById(int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var contenu = client.GetAsync("http://satisfactionsurveyapi.azurewebsites.net/api/FormulaireApi/" + id).Result;

            //if (contenu.IsSuccessStatusCode)
            //{
            var abc = contenu.Content.ReadAsStringAsync().Result;
            var bcd = JsonConvert.DeserializeObject<Formulaire>(abc);
            //}

            return bcd;
        }

    }
}