

namespace AmexParser;

class Program
{
    static void Main(string[] args)
    {
        Configuration configuration = new Configuration();
        FileReader fileReader = new FileReader();
        List<string> reports = fileReader.GetAllReport();

        ReportSectionIdentifier reportSectionIdentifier = new ReportSectionIdentifier();
        List<string> fileTrackingReports = reportSectionIdentifier.ExtractReportSection(configuration.FileTrackingHeader,reports);
        foreach(var a in fileTrackingReports)
        {
            Console.WriteLine(a);
        }
    }
}
