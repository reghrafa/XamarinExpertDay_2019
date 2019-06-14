using DwxSpeaker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DwxSpeaker
{
    public static class DataProvider
    {
        private static List<Speaker> _speakers;
        private static string GetSpeakerResource()
        {
            var assembly = typeof(DataProvider).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("DwxSpeaker.Resources.Speakers.json");

            string text = "";
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            return text;
        }
        public static List<Speaker> Speakers
        {
            get
            {
                var json = GetSpeakerResource();
                var list = JsonConvert.DeserializeObject<List<Speaker>>(json);
                return _speakers ?? (_speakers = list);
            }
        }
    }
}
