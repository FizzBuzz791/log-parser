using System.Globalization;

namespace log_parser;

public class LogEntry
{
    public string IPAddress { get; }
    public bool IsAdmin { get; }
    public DateTime Date { get; }
    public string Request { get; }
    public string Url { get; }
    public string Protocol { get; }
    public int Response { get; }
    public string UserAgent { get; }

    public LogEntry(string ipAddress, string isAdmin, string date, string request, string url, string protocol, string response, string userAgent)
    {
        IPAddress = ipAddress;
        IsAdmin = isAdmin == "admin";
        Date = DateTime.ParseExact($"{date[..11]}T{date[12..]}", "dd/MMM/yyyyTHH:mm:ss zzz", CultureInfo.CurrentCulture);
        Request = request.Trim('\"');
        Url = url;
        Protocol = protocol.Trim('\"');
        Response = int.Parse(response, CultureInfo.CurrentCulture);
        UserAgent = userAgent.Trim('\"');
    }
}
