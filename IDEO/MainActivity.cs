using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Content.Res;
using Newtonsoft.Json;
using Android.Util;

namespace IDEO
{
    [Activity(Label = "Ngôn ngữ ký hiệu", Icon = "@drawable/logo", ScreenOrientation = Android.Content.PM.ScreenOrientation.SensorPortrait)]
    public class MainActivity : Activity
    {
        ListView _lvVoca;
        List<WordInVocabulary> _ListVoca = new List<WordInVocabulary>();
        SearchView _searchView;
        ArrayAdapter adapter;
        string jsonLocationRead = "";
        List<string> resultList = new List<string>();

        public void showToast(string str)
        {
            Toast.MakeText(this, str, ToastLength.Short).Show();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            jsonLocationRead = AccessJSON.ReadAssetJSONFile(this);
            resultList.Clear();

            _ListVoca = JsonConvert.DeserializeObject<List<WordInVocabulary>>(jsonLocationRead);

            resultList = GetListWord(_ListVoca);

            _lvVoca = FindViewById<ListView>(Resource.Id.listVoca);
            adapter = new ArrayAdapter<string>(this, Resource.Layout.row_In_List_Voca, Resource.Id.word, resultList);
            _lvVoca.Adapter = adapter;
            _lvVoca.ItemClick += _lvVoca_ItemClick;

            _searchView = FindViewById<SearchView>(Resource.Id.searchView1);
            _searchView.QueryTextChange += _searchView_QueryTextChange;

            // Get our button from the layout resource,
            // and attach an event to it
        }

        private void _lvVoca_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            StartActivity(typeof(ShowThisWord));
        }

        public List<string> GetListWord(List<WordInVocabulary> listVoca)
        {
            List<string> result = new List<string>();
            foreach (WordInVocabulary w in listVoca)
            {
                result.Add(w.Word);
            }
            return result;
        }

        private void _searchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            adapter.Filter.InvokeFilter(e.NewText);
        }

        public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Back)
            {

                Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
                builder.SetTitle("Thoát ứng dụng")
                       .SetMessage("Bạn muốn thoát?")
                       .SetIcon(Android.Resource.Drawable.IcDialogAlert)
                       .SetPositiveButton("Có", delegate
                       {
                           Finish();
                           Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                       })
                       .SetNegativeButton("Không", delegate
                       {
                       });
                Android.App.AlertDialog alert = builder.Create();
                alert.Show();
            }
            return base.OnKeyDown(keyCode, e);
        }
    }
}

