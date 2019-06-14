using Foundation;
using System;
using UIKit;
using Dwx17.Clients.Shared;
using Dwx17.Infrastructure;

namespace Dwx17.Clients.IosApp
{
    public partial class RepoViewController : UITableViewController
    {
        RepositoryListViewModel ViewModel = ServiceLocator.Current.RepositoryListViewModel;

        public RepoViewController (IntPtr handle) : base (handle)
        {
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell), "cell");
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            var t = ViewModel.RefreshAsync();
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
        }

        void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RepositoryListViewModel.Repositories))
            {
                TableView.ReloadData();
            }
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        => ViewModel.Repositories.Count;

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = TableView.DequeueReusableCell("cell", indexPath) ?? new UITableViewCell(UITableViewCellStyle.Value1, "cell");
            cell.TextLabel.Text = ViewModel.Repositories[indexPath.Row].Name;
            return cell;
        }
    }
}