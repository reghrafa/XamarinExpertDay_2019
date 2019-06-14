using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwx17.Domain.RequiredInterfaces
{
    public interface IGitHubClient
    {
        Task<List<GitHubRepository>> GetRepositoriesAsync();
    }
}
