## Overview

In this exercise, we will scan websites looking for keywords.  Our scanner provides 2 properties to hold the keywords and the urls to scan.
The code below contains synchronous execution. 

| | |
| --------- | --------------------------- |
| Exercise Folder | Tasks |
| Builds On | none |
| Time to complete | 60 minutes

Add the *Tasks* Project to your current solution and review the code.  Modify the keywords and urls to scan.  Run the application and notice the execution time.

A few things to note:
* The code is synchronous.  The code will execute one line at a time.
* The scanner is not very efficient.  It will scan each url/keyword combination completely before moving on to the next url/keyword combination. We did this intentionally to create more work for the scanner.

### Part 1 - Tasks

The key to good multitasking design is to create units of work that can execute independently of each other.  The best scenario is to have different units that are waiting on different resources.  If we have several tasks that are waiting on the same resource (like hard drive), we have not gained much.

The bottleneck in our current design is in the method *GetKeywordCount*.  This method is waiting on the network to return the html for the url.  We can improve the design by creating a task for each url/keyword combination.  This will allow the tasks to run independently of each other.  Since each task is waiting on a different resource (network), we will gain some performance.  In addition, scanning the resulting html for the keyword can be done in parallel.  This is CPU bound work and can be done in parallel with the network work.

Two of the methods we use are already task-oriented.  *GetAsync* and *ReadAsStringAsync* are both asynchronous methods that the current code is not taking advantage of.  We will need to modify the code to take advantage of these methods.

#### Option 1 - Task.Run
The simplest approach will be to make the entire method *GetKeywordCount* asynchronous.  We can do this by wrapping the entire method in a *Task.Run* call.  This will create a task that will run the entire method.  The code will look like this:

```csharp
private Task<KeywordResults> GetKeywordCount(string url, string keyword)
{
    return Task.Run(() =>
    {
        HttpClient client = new HttpClient();
        var response = client.GetAsync(url).Result;
        var text = response.Content.ReadAsStringAsync().Result;
        int count = 0; int idx = 0;
        while ((idx = text.IndexOf(keyword, idx + 1)) > -1)
            count++;
        return new KeywordResults(url, keyword, count);
    });
}
```

The *Go* method will need to be modified.  One approach is to create a list of tasks and then wait for all of them to complete.  The code will look like this:

```csharp
public IEnumerable<KeywordResults> Go()
{
    var list = new List<KeywordResults>();
    var tasks = new List<Task<KeywordResults>>();
    foreach (var url in Urls)
        foreach (var key in Keywords)
            tasks.Add(GetKeywordCount(url, key));
    Task.WaitAll(tasks.ToArray());
    foreach (var task in tasks)
        list.Add(task.Result);
    return list;
}
```
*Make these modifications and run the application.  Notice the execution time.*

In our tests, the execution time is about 1/3 of the original execution time.  This is a significant improvement.  However, we can do better.


#### Option 2 - ContinureWith
The *ContinueWith* method allows us to chain tasks together.  We can create a task that will execute the network call and then chain a task that will execute the keyword search.  The code will look like this:

```csharp
private Task<KeywordResults> GetKeywordCount(string url, string keyword)
{
    HttpClient client = new HttpClient();
    return client.GetAsync(url)
    .ContinueWith((response) =>
    {
        return response.Result.Content.ReadAsStringAsync();
    })
    .ContinueWith((task) =>
    {
        int count = 0; int idx = 0;
        while ((idx = task.Result.Result.IndexOf(keyword, idx + 1)) > -1)
            count++;
        return new KeywordResults(url, keyword, count);
    });
}
```

The *Go* method will need to be modified.  One approach is to create a list of tasks and wait for them to complete, but process them as they finish.  The code will look like this:

```csharp
public IEnumerable<KeywordResults> Go()
{
    var list = new List<KeywordResults>();
    var tasks = new List<Task<KeywordResults>>();
    foreach (var url in Urls)
        foreach (var key in Keywords)
            tasks.Add(GetKeywordCount(url, key));
    while (tasks.Count > 0)
    {
        var task = Task.WhenAny(tasks).Result;
        tasks.Remove(task);
        list.Add(task.Result);
    }
    return list;
}
```

*Make these modifications and run the application.  Notice the execution time.*  We did not notice a significant difference in execution time between the two options.  However, the *ContinueWith* option is more efficient.  The *Task.Run* option will create a new thread for each task.  The *ContinueWith* option will use the thread pool to execute the tasks.  The thread pool is more efficient than creating new threads.

### Option 3 - Async/Await

To make things a little cleaner, we divided the *GetKeywordCount* method into two methods.  The first method will execute the network call and the second method will execute the keyword search.  We made the method async and awaited each of the 3 steps.  The code will look like this:

```csharp
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
```

The *Go* method was not changed.  However, it could be made into an async method.

Make these modifications and run the application.  Notice the execution time.  We observed about a 50% improvement over the *ContinueWith* option.  This is because async/await returns control to the caller when the await is encountered.  This allows the thread to be used for other tasks.  When the awaited task completes, the thread is returned to the async method.


### Optional Challenge
Modify the PayrollService methods to be async, especially those that save changes to the database.  Update the controller methods to async as well.