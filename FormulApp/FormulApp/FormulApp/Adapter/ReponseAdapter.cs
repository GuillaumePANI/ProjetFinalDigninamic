﻿using System;
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
    class ReponseAdapter : BaseAdapter<Reponse>
    {
        private readonly Activity context;
        private readonly List<Reponse> data;

        public ReponseAdapter(Activity context, List<Reponse> data)
        {
            this.data = data;
            this.context = context;
        }

        public override Reponse this[int position] => data[position];

        public override int Count => data.Count;

        public override long GetItemId(int position) => data[position].id;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //récuperer l'element à afficher
            var item = data[position];

            //créer la ligne
            var cell = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItemMultipleChoice, parent, false);

            //configurer la ligne
            var textview = cell.FindViewById<TextView>(Android.Resource.Id.Text1);

            textview.Text = $"{item.id} - {item.contenu}";

            //Retourner la ligne
            return cell;

        }
    }
}