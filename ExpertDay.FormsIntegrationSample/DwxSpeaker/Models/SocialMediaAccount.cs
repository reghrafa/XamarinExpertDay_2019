using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwxSpeaker.Models
{
    public class SocialMediaAccount
    {
        public SocialNetwork Network { get; set; }
        public string Url { get; set; }
    }
    public enum SocialNetwork
    {
        Website,
        Facebook,
        Twitter,
        LinkedIn,
        GooglePlus,
        GitHub,
        Xing
    }
}
