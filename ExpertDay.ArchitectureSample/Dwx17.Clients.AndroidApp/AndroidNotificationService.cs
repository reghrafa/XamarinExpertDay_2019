using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Dwx17.Infrastructure.RequiredInterfaces;

namespace Dwx17.Clients.AndroidApp
{
    public class AndroidNotificationService : INotificationService
    {
        public void Notify(string text)
        {
            Console.WriteLine($"NOTIFICATION: {text}");
        }
    }
}