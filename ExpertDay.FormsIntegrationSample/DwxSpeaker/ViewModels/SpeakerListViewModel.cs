using DwxSpeaker.Interfaces;
using DwxSpeaker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DwxSpeaker.ViewModels
{
    public class SpeakerListViewModel : ViewModelBase
    {
        public SpeakerListViewModel()
        {
            Speakers = new ObservableCollection<Speaker>(DataProvider.Speakers);
            SpeakerClickedCommand = new Command<Speaker>((s) => {
                DependencyService.Get<INavigationService>().Navigate(Interfaces.Page.SpeakerDetailPage);
                MessagingCenter.Send(this, "speaker", s);
            });
        }
        private ObservableCollection<Speaker> _speakers;

        public ObservableCollection<Speaker> Speakers
        {
            get { return _speakers; }
            set { SetProperty(ref _speakers, value); }
        }
        private ICommand _speakerClickedCommand;

        public ICommand SpeakerClickedCommand
        {
            get { return _speakerClickedCommand; }
            set { SetProperty(ref _speakerClickedCommand, value); }
        }

    }
}
