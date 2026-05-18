namespace AmexParser;
public class ReportSectionIdentifier
{
    public static bool IsStartOfHeader(string line, string reportHeader)
    {
        return line.Contains(reportHeader);
    }

    public static bool IsPageHeadLine(string line)
    {
        return line.Contains("REPORT ID") || line.Contains("PROGRAM ID") || line.Contains("BUSINESS DATE");
    }

    public List<string> ExtractReportSection(string reportHeader, List<string> allReports)
    {
        bool isInReportSection = false;
        List<string> extractedReports = new List<string>();
        string initialSectionId = "";
        foreach(var line in allReports)
        {       

            
            if(IsStartOfHeader(line, reportHeader))
            {
                isInReportSection = true;
            }
            if(isInReportSection && line.Contains("SECTION ID"))
            {
                try
                {
                    string currentSectionId = StringExtractor.SafeExtract(line, 15, 3, "SectionId");
                    if(string.IsNullOrWhiteSpace(initialSectionId))
                    {
                        initialSectionId = currentSectionId;
                    }
                    else if(currentSectionId != initialSectionId)
                    {
                        break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Warning: {ex.Message}");
                    continue;
                }
            }

            if (isInReportSection && (string.IsNullOrWhiteSpace(line) == false) && IsPageHeadLine(line) == false)
            {
                extractedReports.Add(line);
            }

        }
        return extractedReports;
        
    }
}

