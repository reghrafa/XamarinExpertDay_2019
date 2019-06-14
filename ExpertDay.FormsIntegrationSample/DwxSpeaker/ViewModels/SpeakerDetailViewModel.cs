using DwxSpeaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DwxSpeaker.ViewModels
{
    public class SpeakerDetailViewModel : ViewModelBase
    {
        public SpeakerDetailViewModel()
        {
            MessagingCenter.Subscribe<SpeakerListViewModel, Speaker>(this, "speaker", (s, arg) =>
            {
                Load(arg);
            });
        }
        private void Load(Speaker speaker)
        {
            Speaker = speaker;
        }
        private Speaker _speaker;

        public Speaker Speaker
        {
            get { return _speaker; }
            set { SetProperty(ref _speaker, value); }
        }

    }
}
