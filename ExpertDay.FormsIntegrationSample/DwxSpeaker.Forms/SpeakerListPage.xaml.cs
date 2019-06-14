using DwxSpeaker.Models;
using DwxSpeaker.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DwxSpeaker.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpeakerListPage : ContentPage
    {
        public SpeakerListViewModel ViewModel { get; set; }
        public SpeakerListPage(SpeakerListViewModel bindingContext)
        {
            InitializeComponent();
            
            BindingContext = ViewModel = bindingContext;
        }
        public void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var speaker = e.Item as Speaker;
            if(ViewModel.SpeakerClickedCommand.CanExecute(speaker))
            {
                ViewModel.SpeakerClickedCommand.Execute(speaker);
            }
        }
    }

}