using System.Threading.Tasks;
using System;

namespace Tasks;

public class WebScanner
{
    public record KeywordResults(string Url, string Keyword, int Count);
    public IEnumerable<string> Keywords { get; set; } = new List<string>();
    public IEnumerable<string> Urls { get; set; } = new List<string>();
    private async Task<KeywordResults> GetKeywordCount(string url, string keyword)
    {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        return await Count(url, content, keyword);
    }

    private async Task<KeywordResults> Count(string url, string html, string keyword)
    {
        return await Task.Run(() => {
        int count = 0; int idx = 0;
        while ((idx = html.IndexOf(keyword, idx + 1)) > -1)
            count++;
        return new KeywordResults(url, keyword, count);
        });
    }

    public async Task<IEnumerable<KeywordResults>> Go()
    {
        var list = new List<KeywordResults>();
        var tasks = new List<Task<KeywordResults>>();
        foreach (var url in Urls)
            foreach (var key in Keywords)
                tasks.Add(GetKeywordCount(url, key));
        while (tasks.Count > 0)
        {
            var task = await Task.WhenAny(tasks);
            tasks.Remove(task);
            list.Add(task.Result);
        }
        return list;
    }
}