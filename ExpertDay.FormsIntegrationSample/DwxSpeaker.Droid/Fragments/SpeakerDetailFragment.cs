using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using DwxSpeaker.ViewModels;
using DwxSpeaker.Droid.Services;
using Xamarin.Forms;
using System.Threading.Tasks;
using DwxSpeaker.Droid.Adapter;

namespace DwxSpeaker.Droid.Fragments
{
    public class SpeakerDetailFragment : Fragment
    {
        public SpeakerDetailViewModel ViewModel { get; private set; }
        private TextView _name, _description;
        private ImageView _photo;
        private Android.Widget.ListView _sessions;

        public SpeakerDetailFragment()
        {
            ViewModel = ServiceLocator.SpeakerDetailViewModel;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.SpeakerDetailPage, container, false);
            _name = view.FindViewById<TextView>(Resource.Id.speakerdetail_name);
            _description = view.FindViewById<TextView>(Resource.Id.speakerdetail_description);
            _photo = view.FindViewById<ImageView>(Resource.Id.speakerdetail_photo);
            _sessions = view.FindViewById<Android.Widget.ListView>(Resource.Id.speakerdetail_sessions);

            return view;
        }
        public async override void OnResume()
        {
            base.OnResume();
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            await DisplaySpeaker();
        }

        private async void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.PropertyName) || e.PropertyName == nameof(ViewModel.Speaker))
            {
                await DisplaySpeaker();
            }
        }
        private async Task DisplaySpeaker()
        {
            _name.Text = ViewModel.Speaker.Name;
            _description.Text = ViewModel.Speaker.Description;
            _sessions.Adapter = new SessionListAdapter(Activity, ViewModel.Speaker.Sessions);
            _photo.SetImageBitmap(await ImageService.GetImageBitmapFromUrlAsync(ViewModel.Speaker.ImageUrl));
        }


        public override void OnPause()
        {
            base.OnPause();
            ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
        }
    }
}