using Dwx17.Domain.GitHubApiClient;
using Dwx17.Infrastructure;
using Dwx17.Infrastructure.RequiredInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

#if __ANDROID__
using Dwx17.Clients.AndroidApp;
#elif __IOS__
using Dwx17.Clients.IosApp;
#elif WINDOWS_UWP
using Dwx17.Clients.WindowsApp;
#endif

namespace Dwx17.Clients.Shared
{
    public class ServiceLocator
    {
        #region Singleton
        private static ServiceLocator _instance;
        public static ServiceLocator Current { get { return _instance ?? (_instance = new ServiceLocator()); } }
        #endregion

        private INotificationService _notificationService;
        private RepositoryListViewModel _repositoryListViewModel;

        public INotificationService NotificationService
        {
#if __ANDROID__
            get { return _notificationService ?? (_notificationService = new AndroidNotificationService()); }
#elif __IOS__
            get { return _notificationService ?? (_notificationService = new IosNotificationService()); }
#elif WINDOWS_UWP
            get { return _notificationService ?? (_notificationService = new WindowsNotificationService()); }
#endif
        }

        public RepositoryListViewModel RepositoryListViewModel
        {
            get { return _repositoryListViewModel ?? (new RepositoryListViewModel(new GitHubClient(), NotificationService)); }
        }

    }
}
