namespace WireMockPOC.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WireMockPOC.Models;

    public interface IHackerNewsService
    {
        Task<IEnumerable<HackerNewsItem>> GetTopTenStoriesAsync();
    }
}
