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
using Android.Graphics;
using System.Net;
using System.Threading.Tasks;

namespace DwxSpeaker.Droid.Services
{
    public static class ImageService
    {
        public static async Task<Bitmap> GetImageBitmapFromUrlAsync(string url)
        {
            Bitmap imageBitmap = null;
            var webClient = new WebClient();
            var imageBytes = await webClient.DownloadDataTaskAsync(url);
            if (imageBytes != null && imageBytes.Length > 0)
            {
                imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
            }
            return imageBitmap;
        }
    }
}