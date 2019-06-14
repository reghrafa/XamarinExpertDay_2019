using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwxSpeaker.Interfaces
{
    public interface INavigationService
    {
        void Navigate(Page page);
        void NavigateBack();
    }
    public enum Page
    {
        SpeakerListPage,
        SpeakerDetailPage
    }
}
