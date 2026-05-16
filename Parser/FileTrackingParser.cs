namespace AmexParser;

public class FileTrackingParser
{
    private Configuration _configuration;
    public FileTrackingParser(Configuration configuration)
    {
        _configuration = configuration;
    }
    public List<FileTracking> FileTrackingParse(List<string> reports)
    {
        string currentFileType = "";
        List<FileTracking> fileTrackingRecords = new List<FileTracking>();

        foreach (var currentLine in reports)
        {
            if (IsFileTypeHeader(currentLine))
            {
                currentFileType = currentLine.Substring(_configuration.FileTypeStart, _configuration.FileTypeLength).Trim();
                continue;
            }

            if (string.IsNullOrWhiteSpace(currentLine))
            {
                continue;
            }
            if (IsDataRow(currentLine))
            {
                //fileTrackingRecords
                fileTrackingRecords.Add(new FileTracking
                {
                    FileHeader = "File Tracking",
                    FileType = currentFileType.Trim(),
                    ProcessorId = currentLine.Substring(_configuration.ProcessIdStart, _configuration.ProcessIdLength).Trim(),
                    SequenceNumber = currentLine.Substring(_configuration.SequenceStart, _configuration.SequenceLength).Trim(),
                    ClaimDate = currentLine.Substring(_configuration.ClaimDateStart, _configuration.ClaimDateLength).Trim(),
                    Status = currentLine.Substring(_configuration.StatusStart, _configuration.StatusLength).Trim(),
                    TransactionCount = int.Parse(currentLine.Substring(_configuration.TransactionCountStart, _configuration.TransactionCountLength).Trim())
                });
            }

        }
        return fileTrackingRecords;
    }

    public bool IsFileTypeHeader(string line)
    {
        return line.Contains("OUTCLEAR FILES") || line.Contains("INCLEAR FILES");
    }

    public bool IsDataRow(string line)
    {
        return char.IsDigit(line.Trim()[0]);
    }
}