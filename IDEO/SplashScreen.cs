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
using System.Threading.Tasks;
using Java.Lang;

namespace IDEO
{
    [Activity(MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.SensorPortrait)]
    public class SplashScreen : Activity
    {
        int TIME_OUT = 2;
        ImageView mSplashScreen;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SplashScreen_layout);
            ActionBar.Hide();
            mSplashScreen = FindViewById<ImageView>(Resource.Id.imgSplashScreen);
            mSplashScreen.SetImageResource(Resource.Drawable.splashscreen);
            Task.Run(() => {
                Thread.Sleep(TIME_OUT * 1000);
                RunOnUiThread(() => {
                    mSplashScreen.SetImageResource(Resource.Drawable.logo);
                });

                Thread.Sleep(TIME_OUT * 1000);
                RunOnUiThread(() =>
                {
                    StartActivity(new Intent(this, typeof(MainActivity)));
                    Finish();
                });
            });
            // Create your application here
        }

        public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Back)
            {
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }
    }
}