using Foundation;
using System;
using UIKit;
using System.Net.Http;

namespace DwxSpeaker.Ios
{
    public partial class DetailViewController : UIViewController
    {
        public DetailViewController(IntPtr handle) : base(handle)
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            var random = new Random();

            var imageSource = $"http://www.myboyfriendwearsflannel.com/wp-content/uploads/2013/01/rainbow-hello-kitty.jpg";

            var sw = System.Diagnostics.Stopwatch.StartNew();

            var client = new HttpClient(new HttpClientHandler());
            var data = await client.GetByteArrayAsync($"{imageSource}?{ random.Next(int.MaxValue)}");
            var managed = sw.ElapsedMilliseconds;
            lblManaged.Text = "Elapsed Managed: " + managed;

            System.Diagnostics.Debug.WriteLine("Elapsed Managed: " + sw.ElapsedMilliseconds);
            sw = System.Diagnostics.Stopwatch.StartNew();

            client = new HttpClient(new NSUrlSessionHandler());
            data = await client.GetByteArrayAsync($"{imageSource}?{ random.Next(int.MaxValue)}");
            lblNSUrl.Text = $"Elapsed NSUrl: {sw.ElapsedMilliseconds} -- {100 - (int)((float)sw.ElapsedMilliseconds / (float)managed * 100)}% faster";

            System.Diagnostics.Debug.WriteLine("Elapsed NSUrl: " + sw.ElapsedMilliseconds);
            sw = System.Diagnostics.Stopwatch.StartNew();

            client = new HttpClient(new CFNetworkHandler());
            data = await client.GetByteArrayAsync($"{imageSource}?{ random.Next(int.MaxValue)}");
            lblCFNetwork.Text = $"Elapsed CFNetwork: {sw.ElapsedMilliseconds} -- {100 - (int)((float)sw.ElapsedMilliseconds / (float)managed * 100)}% faster";

            System.Diagnostics.Debug.WriteLine("Elapsed CFNetwork: " + sw.ElapsedMilliseconds);

            sw.Stop();
        }
    }
}