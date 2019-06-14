using System;
using DwxSpeaker.Interfaces;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(DwxSpeaker.Ios.Services.IosNavigationService))]
namespace DwxSpeaker.Ios.Services
{
    public class IosNavigationService : NSObject, INavigationService
    {
        private UINavigationController _rootViewController;

        public IosNavigationService()
        {
            _rootViewController = UIApplication.SharedApplication.KeyWindow.RootViewController as UINavigationController;
		}

        void INavigationService.Navigate(Interfaces.Page page)
        {
            UIViewController controller = null;
            switch (page)
            {
                case Interfaces.Page.SpeakerDetailPage:
                    controller = UIStoryboard.FromName("Main", null).InstantiateViewController(nameof(DetailViewController));
                    break;
                case Interfaces.Page.SpeakerListPage:
                    controller = new DwxSpeaker.Forms.SpeakerListPage(new ViewModels.SpeakerListViewModel()).CreateViewController();
                    break;
            }

            _rootViewController.PushViewController(controller, true);
        }

        public void NavigateBack()
        {
            _rootViewController.PopViewController(true);
        }
    }
}
