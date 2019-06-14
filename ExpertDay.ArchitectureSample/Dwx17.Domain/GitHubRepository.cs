using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwx17.Domain
{
    public class GitHubRepository
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int Forks { get; set; }
    }
}
