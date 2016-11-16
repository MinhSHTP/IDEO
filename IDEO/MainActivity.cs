using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace IDEO
{
    [Activity(Label = "IDEO", Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ListView _lvVoca;
        List<string> _ListVoca = new List<string>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            for(int i = 0; i < 10; i++)
            {
                _ListVoca.Add("" + (i + 1));
            }
            _lvVoca = FindViewById<ListView>(Resource.Id.listVoca);
            ArrayListAdapter adapter = new ArrayListAdapter(this, _ListVoca);
            // Get our button from the layout resource,
            // and attach an event to it
        }
    }
}

