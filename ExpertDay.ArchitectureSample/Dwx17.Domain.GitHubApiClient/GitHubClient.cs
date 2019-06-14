using Dwx17.Domain.RequiredInterfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dwx17.Domain.GitHubApiClient
{
    public class GitHubClient : IGitHubClient
    {
        public async Task<List<GitHubRepository>> GetRepositoriesAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Awesome 1.0");

            var json = await client.GetStringAsync("http://api.github.com/orgs/octokit/repos");
            var items = JsonConvert.DeserializeObject<List<RepositoryDto>>(json);

            return items.Select(i => new GitHubRepository()
            {
                Name = i.full_name,
                Url = i.html_url,
                Forks = i.forks_count
            }).ToList();
        }
    }
}
