namespace WireMockPOC.Services
{
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using WireMockPOC.Models;

    public class HackerNewsService : IHackerNewsService
    {
        private readonly HttpClient httpClient;

        private IConfiguration Configuration { get; }

        private readonly string Url;

        public HackerNewsService(IConfiguration configuration)
        {
            this.httpClient = new HttpClient();
            this.Configuration = configuration;

            Url = this.Configuration.GetValue<bool>("Mocking:Enabled")
                  ? this.Configuration.GetValue<string>("Mocking:Url") 
                  : this.Configuration.GetValue<string>("HackerNewsUrl");
        }

        public async Task<IEnumerable<HackerNewsItem>> GetTopTenStoriesAsync()
        {

            var top = await GetTopIdsAsync();
            var stories = new List<HackerNewsItem>();

            for (int i = 0; i < 10; i++)
            {
                var response = await httpClient.GetAsync($"{Url}/v0/item/{top[i]}.json");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var story = JsonConvert.DeserializeObject<HackerNewsItem>(content);
                story.Number = i + 1;
                stories.Add(story);
            }

            return stories;
        }

        private async Task<List<int>> GetTopIdsAsync()
        {
            var response = await httpClient.GetAsync($"{Url}/v0/topstories.json");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var top = JsonConvert.DeserializeObject<List<int>>(content);
            return top;
        }
    }
}
