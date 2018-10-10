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
    class FormulAdapter : BaseAdapter<Formulaire>
    {
        private readonly Activity context;
        private readonly List<Formulaire> data;

        public FormulAdapter(Activity context, List<Formulaire> data)
        {
            this.data = data;
            this.context = context;
        }

        public override Formulaire this[int position] => data[position];

        public override int Count => data.Count();

        public override long GetItemId(int position) => 0;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //récuperer l'element à afficher
            var item = data[position];

            //créer la ligne
            var cell = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, parent, false);

            //configurer la ligne
            var textview = cell.FindViewById<TextView>(Android.Resource.Id.Text1);

            textview.Text = $"{item.titre}";

            //Retourner la ligne
            return cell;

        }
    }
}