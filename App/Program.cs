using log_parser;

try
{
    List<LogEntry>? logEntries = new();

    using StreamReader? sr = new("sample-data.log");
    while (!sr.EndOfStream)
    {
        string? logLine = await sr.ReadLineAsync();
        if (!string.IsNullOrWhiteSpace(logLine))
        {
            logEntries.Add(Parser.ParseLogLine(logLine));
        }
    }

    // 1. Display number of Unique IPs
    Console.WriteLine($"Unique IPs: {logEntries.DistinctBy(le => le.IPAddress).Count()}");

    // 2. Display top 3 visited URLs
    IEnumerable<IGrouping<string, LogEntry>>? top3Urls = logEntries.GroupBy(le => le.Url)
        .OrderByDescending(g => g.Count())
        .Take(3);
    Console.WriteLine("Top 3 URLs:");
    foreach (IGrouping<string, LogEntry>? urlGroup in top3Urls)
    {
        Console.WriteLine($"\t{urlGroup.Key}");
    }

    // 3. Display top 3 most active IPs
    IEnumerable<IGrouping<string, LogEntry>>? top3Ips = logEntries.GroupBy(le => le.IPAddress)
        .OrderByDescending(g => g.Count())
        .Take(3);
    Console.WriteLine("Top 3 IPs:");
    foreach (IGrouping<string, LogEntry>? ipGroup in top3Ips)
    {
        Console.WriteLine($"\t{ipGroup.Key}");
    }

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}