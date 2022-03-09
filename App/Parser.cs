namespace log_parser;

public class Parser
{
    public static LogEntry ParseLogLine(string rawLogLine)
    {
        string[]? parts = rawLogLine.Split(' ');
        string ipAddressField = parts[0];
        string isAdminField = parts[2];
        string dateField = $"{parts[3].Trim('[')} {parts[4].Trim(']')}";
        string requestField = parts[5];
        string urlField = parts[6];
        string protocolField = parts[7];
        string responseField = parts[8];

        // TODO: Known issue - extra data may get included in the UserAgent field
        // Should only be taking up until the first "
        string userAgentField = string.Join(" ", parts.Skip(11));

        return new LogEntry(ipAddressField, isAdminField, dateField, requestField, urlField, protocolField, responseField, userAgentField);
    }
}
