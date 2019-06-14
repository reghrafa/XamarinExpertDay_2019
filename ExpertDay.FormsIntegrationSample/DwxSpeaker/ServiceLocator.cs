using DwxSpeaker.ViewModels;

namespace DwxSpeaker.Droid
{
    public static class ServiceLocator
    {
        private static SpeakerListViewModel _speakerListViewModel;
        private static SpeakerDetailViewModel _speakerDetailViewModel;

        public static SpeakerDetailViewModel SpeakerDetailViewModel
        {
            get
            {
                return _speakerDetailViewModel ?? (_speakerDetailViewModel = new SpeakerDetailViewModel());
            }
        }

        public static SpeakerListViewModel SpeakerListViewModel
        {
            get
            {
                return _speakerListViewModel ?? (_speakerListViewModel = new SpeakerListViewModel());
            }
        }
    }
}
