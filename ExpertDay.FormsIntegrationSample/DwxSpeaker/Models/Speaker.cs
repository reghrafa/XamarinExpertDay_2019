using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwxSpeaker.Models
{
    public class Speaker
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<SocialMediaAccount> SocialMediaAccounts { get; set; }
        public List<Session> Sessions { get; set; }
    }
}
