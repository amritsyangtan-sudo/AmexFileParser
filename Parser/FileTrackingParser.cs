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
                currentFileType = StringExtractor.SafeExtract(currentLine, _configuration.FileTypeStart, _configuration.FileTypeLength, "FileType");
                continue;
            }

            if (string.IsNullOrWhiteSpace(currentLine))
            {
                continue;
            }
            if (IsDataRow(currentLine))
            {
                try
                {
                    fileTrackingRecords.Add(new FileTracking
                    {
                        FileHeader = "File Tracking",
                        FileType = currentFileType.Trim(),
                        ProcessorId = StringExtractor.SafeExtract(currentLine, _configuration.ProcessIdStart, _configuration.ProcessIdLength, "ProcessorId"),
                        SequenceNumber = StringExtractor.SafeExtract(currentLine, _configuration.SequenceStart, _configuration.SequenceLength, "SequenceNumber"),
                        ClaimDate = StringExtractor.SafeExtract(currentLine, _configuration.ClaimDateStart, _configuration.ClaimDateLength, "ClaimDate"),
                        Status = StringExtractor.SafeExtract(currentLine, _configuration.StatusStart, _configuration.StatusLength, "Status"),
                        TransactionCount = StringExtractor.TryExtractInt(currentLine, _configuration.TransactionCountStart, _configuration.TransactionCountLength, "TransactionCount", out int count) ? count : 0
                    });
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Warning: Failed to parse FileTracking row: {ex.Message}");
                    continue;
                }
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