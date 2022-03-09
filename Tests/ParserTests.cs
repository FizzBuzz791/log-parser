using System;
using log_parser;
using NUnit.Framework;

namespace Tests;

public class ParserTests
{
    // TODO: Add more test cases.
    [Test]
    public void GivenARawLogLineWhenParsedThenAValidLogEntryIsReturned()
    {
        // Arrange
        string rawLogLine = "177.71.128.21 - - [10/Jul/2018:22:21:28 +0200] \"GET /intranet-analytics/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (X11; U; Linux x86_64; fr-FR) AppleWebKit/534.7 (KHTML, like Gecko) Epiphany/2.30.6 Safari/534.7\"";

        // Act
        LogEntry? logEntry = Parser.ParseLogLine(rawLogLine);
        Console.WriteLine(logEntry.UserAgent);

        // Assert
        Assert.AreEqual(logEntry.IPAddress, "177.71.128.21");
        Assert.AreEqual(logEntry.IsAdmin, false);
        //Assert.AreEqual(logEntry.Date, new DateTimeOffset(2018, 7, 10, 22, 21, 28, new TimeSpan(2, 0, 0)));
        Assert.AreEqual(logEntry.Request, "GET");
        Assert.AreEqual(logEntry.Url, "/intranet-analytics/");
        Assert.AreEqual(logEntry.Protocol, "HTTP/1.1");
        Assert.AreEqual(logEntry.Response, 200);
        Assert.AreEqual(logEntry.UserAgent, "Mozilla/5.0 (X11; U; Linux x86_64; fr-FR) AppleWebKit/534.7 (KHTML, like Gecko) Epiphany/2.30.6 Safari/534.7");
    }
}