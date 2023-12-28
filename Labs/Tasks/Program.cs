using Tasks;



WebScanner scanner = new WebScanner();
scanner.Keywords = new List<string> { "async", "await", "Task", "copyright", "Training", 
    "ASP.Net", "C#", ".Net", "Developer", "Cheese", "Web" };

scanner.Urls = new List<string> { "https://www.microsoft.com", "https://www.google.com",
    "https://www.cnn.com", "https://www.foxnews.com", "https://www.bbc.com",
    "https://www.cheese.com", "https://www.cheese.com/recipes",
    "https://www.McCulloughAssociates.com"
};

var start = DateTime.Now;
var results = scanner.Go();
var end = DateTime.Now;
Console.WriteLine($"Elapsed time: {(end - start).TotalMilliseconds} ms");

foreach (var result in results)
    Console.WriteLine($"{result.Url} - {result.Keyword} - {result.Count}");