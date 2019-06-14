using Dwx17.Domain;
using Dwx17.Domain.RequiredInterfaces;
using Dwx17.Infrastructure.RequiredInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwx17.Infrastructure
{
    public class RepositoryListViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly IGitHubClient _client;
        private readonly INotificationService _notificationService;

        private List<GitHubRepository> _repositories = new List<GitHubRepository>();
        private bool _isDataLoading;

        public RepositoryListViewModel(IGitHubClient client, INotificationService notificationService)
        {
            _client = client;
            _notificationService = notificationService;
        }

        public bool IsDataLoading
        {
            get { return _isDataLoading; }
            set { SetProperty(ref _isDataLoading, value); }
        }

        public List<GitHubRepository> Repositories
        {
            get { return _repositories; }
            set { SetProperty(ref _repositories, value); }
        }

        public async Task RefreshAsync()
        {
            if (IsDataLoading) return;
            IsDataLoading = true;

            try
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                Repositories = await _client.GetRepositoriesAsync();
            }
            catch
            {
                _notificationService.Notify("oooups");
            }

            IsDataLoading = false;
        }
 
    }
}
