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
using Android.Content.Res;

namespace IDEO
{
    public class AccessJSON
    {
        public static string ReadAssetJSONFile(Context context)
        {
            AssetManager manager = context.Assets;
            var result = "";
            string RootPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            RootPath = System.IO.Path.Combine(RootPath, "data.shtpjson");
            if (System.IO.File.Exists(RootPath))
            {
                var sr = new System.IO.StreamReader(System.IO.File.OpenRead(RootPath));
                result = sr.ReadToEnd();
                sr.Close();
            }
            else
            {
                var sr = new System.IO.StreamReader(manager.Open("data.shtpjson"));
                result = sr.ReadToEnd();
                //Android.Widget.Toast.MakeText(context, "", Android.Widget.ToastLength.Short);
                sr.Close();
            }
            return result;
        }
    }
}