using Android.App;
using Android.Widget;
using Android.OS;
using Dwx17.Infrastructure;
using Dwx17.Clients.Shared;
using System.Linq;

namespace Dwx17.Clients.AndroidApp
{
    [Activity(Label = "Dwx17.Clients.AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private RepositoryListViewModel _viewModel;

        private ListView _listview;
        private ProgressBar _progressbar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _viewModel = ServiceLocator.Current.RepositoryListViewModel;

            SetContentView (Resource.Layout.Main);

            _progressbar = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            _listview = FindViewById<ListView>(Resource.Id.listView1);

            FindViewById<Button>(Resource.Id.button1).Click += Button_Click;
        }

        protected override void OnPause()
        {
            base.OnPause();

            _viewModel.PropertyChanged -= _viewModel_PropertyChanged;
        }
        protected override void OnResume()
        {
            base.OnResume();


            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
            Update_All();
        }

        private void _viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(_viewModel.IsDataLoading):
                    Update_IsDataLoading();
                    break;

                case nameof(_viewModel.Repositories):
                    Update_Repositories();
                    break;

                default: break;
            }
        }

        #region Binding Handlers
        private void Update_All()
        {
            Update_IsDataLoading();
            Update_Repositories();
        }

        private void Update_Repositories()
        {
            _listview.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, _viewModel.Repositories.Select(r => r.Name).ToArray());
        }
        private void Update_IsDataLoading()
        {
            _progressbar.Visibility = _viewModel.IsDataLoading ? Android.Views.ViewStates.Visible : Android.Views.ViewStates.Gone;
        } 
        #endregion

        private async void Button_Click(object sender, System.EventArgs e)
        {
            await _viewModel.RefreshAsync();

        }
    }


}

