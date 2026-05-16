namespace AmexParser;
public class FileReader
{
    public List<string> GetAllReport()
    {
        return File.ReadAllLines(Configuration.FilePath).ToList();
    }

    public string? GetLine(string lookupValue, List<string> lines)
    {
        string? result = lines.FirstOrDefault(line => line.Contains(lookupValue));
        return result;
    }

}