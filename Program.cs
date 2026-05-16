

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
        NostroParser nostroParser = new NostroParser(configuration);

        List<string> fileTrackingReportSections = reportSectionIdentifier.ExtractReportSection(configuration.FileTrackingHeader,reports);
        List<string> nostroReportSection = reportSectionIdentifier.ExtractReportSection(configuration.NostroHeader,reports);
        List<string> issuerSettlementSection = reportSectionIdentifier.ExtractReportSection(configuration.IssuerSettlementHeader,reports);

        List<FileTracking> fileTrackingRecords = filetrackingPraser.FileTrackingParse(fileTrackingReportSections);
        List<Nostro> nostroRecords = nostroParser.NostroParse(nostroReportSection);
       
        foreach(var a in fileTrackingRecords)
        {
            Console.WriteLine(a.FileHeader + "|" + a.FileType + "|" + a.ProcessorId + "|" + a.SequenceNumber + "|" + a.ClaimDate + "|" + a.Status + "|" + a.TransactionCount);
        }

        foreach(var a in nostroRecords)
        {
            Console.WriteLine(a.FileHeader + "|" + a.SettlementCurrency + "|" + a.GrossSettlement +"|" + a.GrossSettlementPosition + "|" + a.PassThroughFees + "|" + a.PassThroughFeesPosition  
            + "|" + a.NetworkFees + "|" + a.NetworkFeesPosition + "|" + a.NetworkRateAmount + "|" + a.NetworkRatePosition + "|" +
            a.NetSettlement + "|" + a.NetSettlementPosition);
        }
    }
}


