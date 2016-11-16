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

namespace IDEO
{
    public class ArrayListAdapter : ArrayAdapter<string>
    {
        Activity _Context;
        List<string> _Title = new List<string>();

        public ArrayListAdapter(Activity context, List<string> title) : base(context, Resource.Layout.row_In_List_Voca, title)
        {
            _Context = context;
            _Title = title;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater inflater = _Context.LayoutInflater;
            View rowView = inflater.Inflate(Resource.Layout.row_In_List_Voca, null, true);
            TextView txt = rowView.FindViewById<TextView>(Resource.Id.word);
            txt.Text = _Title[position];
            return rowView;
        }
    }
}