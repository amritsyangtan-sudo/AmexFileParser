

namespace AmexParser;

class Program
{
    static void Main(string[] args)
    {
        Configuration configuration = new Configuration();
        FileReader fileReader = new FileReader();
        List<string> reports = fileReader.GetAllReport();

        ReportSectionIdentifier reportSectionIdentifier = new ReportSectionIdentifier();
        FileTrackingParser filetrackingPraser = new FileTrackingParser(configuration);

        List<string> fileTrackingReportSections = reportSectionIdentifier.ExtractReportSection(configuration.FileTrackingHeader,reports);
        List<FileTracking> fileTrackingRecords = filetrackingPraser.FileTrackingParse(fileTrackingReportSections);
       
        foreach(var a in fileTrackingRecords)
        {
            Console.WriteLine(a.FileHeader + "|" + a.FileType + "|" + a.ProcessorId + "|" + a.SequenceNumber + "|" + a.ClaimDate + "|" + a.Status + "|" + a.TransactionCount);
        }
    }
}


