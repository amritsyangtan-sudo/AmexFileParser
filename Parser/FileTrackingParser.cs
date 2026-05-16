namespace AmexParser;
public class FileTrackingParser
{
    private Configuration _configuration; 
    public FileTrackingParser(Configuration configuration)
    {
        _configuration = configuration;
    }
    public FileTracking FileTrackingParse(List<string> reports)
    {
        string currentFileType = "";

        foreach(var currentLine in reports)
        {
            if(IsFileTypeHeader(currentLine))
            {
                currentFileType = currentLine.Substring(_configuration.FileTypeStart, _configuration.FileTypeLength).Trim();
                continue;   
            }

            if(string.IsNullOrWhiteSpace(currentLine.Substring(1,5)))
            {
                continue;
            }

            
        }
   



            //     currentFileType = reports[initial].Substring(_configuration.FileTypeStart, _configuration.FileTypeLength);

 
            //     return new FileTracking()
            //     {
            //       FileHeader = "File Tracking",
            //       FileType = currentFileType,
            //       ProcessorId = reports[initial].Substring(_configuration.ProcessIdStart, _configuration.ProcessIdLength),
            //       SequenceNumber = reports[initial].Substring(_configuration.SequenceStart, _configuration.SequenceLength),
            //       ClaimDate = reports[initial].Substring(_configuration.ClaimDateStart, _configuration.ClaimDateLength),
            //       Status = reports[initial].Substring(_configuration.StatusStart, _configuration.StatusLength),
            //       TransactionCount = int.Parse(reports[initial].Substring(_configuration.FileTypeStart, _configuration.FileTypeLength))
            //     };
            // }


    }

    public bool IsFileTypeHeader(string line)
    {
        return line.Contains("OUTCLEAR FILES") || line.Contains("INCLEAR FILES");
    }
}