using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using PanCardView.Droid;
using Xamarin.Forms.Platform.Android;

namespace Xamarin.Forms.Parallax.Droid
{
    [Activity(Label = "Xamarin.Forms.Parallax",
        Icon = "@mipmap/icon", 
        Theme = "@style/MainTheme", 
        MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Essentials.Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);
            Window.SetStatusBarColor(Color.FromHex("#3f37c9").ToAndroid());
            CardsViewRenderer.Preserve();
            LoadApplication(new App());
        }
        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}