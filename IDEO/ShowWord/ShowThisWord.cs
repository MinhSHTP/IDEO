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
using Android.Media;

namespace IDEO
{
    [Activity(Label = "ShowThisWord", ScreenOrientation = Android.Content.PM.ScreenOrientation.SensorPortrait)]
    public class ShowThisWord : Activity
    {
        ImageView imgViewHaNoi, imgViewHcm;
        VideoView _videoView;
        MediaController _mediaController;
        bool _FlagIsHaNoi = false;//default is Hcm - FlagIsHanoi will false. 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ShowThisWord_layout);

            //imgViewHaNoi = FindViewById<ImageView>(Resource.Id.HaNoi);
            //imgViewHcm = FindViewById<ImageView>(Resource.Id.Hcm);
            Display display = WindowManager.DefaultDisplay;

            int width = ((display.Width * 40) / 100); // ((display.getWidth()*20)/100)
            int height = ((display.Height * 10) / 100);// ((display.getHeight()*30)/100)
            LinearLayout.LayoutParams parms = new LinearLayout.LayoutParams(width, height);
            parms.SetMargins(20, 20, 0, 0);

            imgViewHaNoi = FindViewById<ImageView>(Resource.Id.HaNoi);
            imgViewHaNoi.LayoutParameters = parms;

            imgViewHcm = FindViewById<ImageView>(Resource.Id.Hcm);
            imgViewHcm.LayoutParameters = parms;

            imgViewHaNoi.Click += ImgViewHaNoi_Click;
            imgViewHcm.Click += ImgViewHcm_Click;
            // Create your application here
        }

        private void ImgViewHcm_Click(object sender, EventArgs e)
        {
            if (_FlagIsHaNoi)//Hanoi is ON
            {
                _FlagIsHaNoi = false;
                imgViewHcm.SetImageResource(Resource.Drawable.On_Hcm);
                imgViewHaNoi.SetImageResource(Resource.Drawable.Off_Ha_Noi);
            }
        }

        private void ImgViewHaNoi_Click(object sender, EventArgs e)
        {
            if (!_FlagIsHaNoi)//Hanoi is OFF
            {
                _FlagIsHaNoi = true;
                imgViewHcm.SetImageResource(Resource.Drawable.Off_Hcm);
                imgViewHaNoi.SetImageResource(Resource.Drawable.On_Ha_Noi);
            }
        }
    }
}