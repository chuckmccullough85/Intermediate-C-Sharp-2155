namespace Tasks;

public class WebScanner
{
    public record KeywordResults(string Url, string Keyword, int Count);
    public IEnumerable<string> Keywords { get; set; } = new List<string>();
    public IEnumerable<string> Urls { get; set; } = new List<string>();
    private KeywordResults GetKeywordCount(string url, string keyword)
    {
        HttpClient client = new HttpClient();
        var response = client.GetAsync(url).Result;
        var text = response.Content.ReadAsStringAsync().Result;
        int count = 0; int idx = 0;
        while ((idx = text.IndexOf(keyword, idx + 1)) > -1)
            count++;
        return new KeywordResults(url, keyword, count);
    }
    public IEnumerable<KeywordResults> Go()
    {
        var list = new List<KeywordResults>();
        foreach (var url in Urls)
            foreach (var key in Keywords)
                list.Add(GetKeywordCount(url, key));
        return list;
    }
}