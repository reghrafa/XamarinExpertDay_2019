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
using DwxSpeaker.Interfaces;
using DwxSpeaker.Forms;
using Xamarin.Forms.Platform.Android;
using DwxSpeaker.Droid.Fragments;

[assembly: Xamarin.Forms.Dependency(typeof(DwxSpeaker.Droid.Services.NavigationService))]
namespace DwxSpeaker.Droid.Services
{
    public class NavigationService : INavigationService
    {
        public static Activity CurrentActivity { get; set; }
        public void Navigate(Page page)
        {
            Fragment frag;
            switch(page)
            {
                case Page.SpeakerListPage:
                    frag = new SpeakerListPage(ServiceLocator.SpeakerListViewModel).CreateFragment(CurrentActivity);
                    break;
                case Page.SpeakerDetailPage:
                    frag = new SpeakerDetailFragment();
                    break;
                default:
                    return;
            }

            FragmentTransaction ft = CurrentActivity.FragmentManager.BeginTransaction();

            ft.AddToBackStack(null);
            ft.Replace(Resource.Id.fragment_frame_layout, frag);

            ft.Commit();
        }
        public static void InitForms()
        {
            Xamarin.Forms.Forms.Init(CurrentActivity, null);
        }
        public void NavigateBack()
        {
            if (CurrentActivity.FragmentManager.BackStackEntryCount != 0)
            {
                CurrentActivity.FragmentManager.PopBackStack();
            }
            else
            {
                CurrentActivity.OnBackPressed();
            }
        }
    }
}