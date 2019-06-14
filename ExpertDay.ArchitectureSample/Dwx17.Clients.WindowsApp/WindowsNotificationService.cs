using Dwx17.Infrastructure.RequiredInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Dwx17.Clients.WindowsApp
{
    public class WindowsNotificationService : INotificationService
    {
        public void Notify(string text)
        {
            var t = new MessageDialog(text).ShowAsync();
        }
    }
}
