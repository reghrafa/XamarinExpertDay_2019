using Android.App;
using Android.Widget;
using Android.OS;
using DwxSpeaker.Droid.Services;
using DwxSpeaker.Interfaces;
using Xamarin.Forms;

namespace DwxSpeaker.Droid
{
    [Activity(Label = "DwxSpeaker.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView (Resource.Layout.Main);
            NavigationService.CurrentActivity = this;
            NavigationService.InitForms();
            DependencyService.Get<INavigationService>().Navigate(Interfaces.Page.SpeakerListPage);
        }
    }
}

