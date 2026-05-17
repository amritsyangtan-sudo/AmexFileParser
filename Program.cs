

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
        SettlementSummaryParser settlementSummaryParser = new SettlementSummaryParser(configuration);

        List<string> fileTrackingReportSections = reportSectionIdentifier.ExtractReportSection(configuration.FileTrackingHeader,reports);
        List<string> nostroReportSection = reportSectionIdentifier.ExtractReportSection(configuration.NostroHeader,reports);
        List<string> issuerSettlementSection = reportSectionIdentifier.ExtractReportSection(configuration.IssuerSettlementHeader,reports);
        List<string> acquirerSettlementSection = reportSectionIdentifier.ExtractReportSection(configuration.AcquirerSettlementHeader,reports);        

        List<FileTracking> fileTrackingRecords = filetrackingPraser.FileTrackingParse(fileTrackingReportSections);
        List<Nostro> nostroRecords = nostroParser.NostroParse(nostroReportSection);
       Console.WriteLine("--------------------------------------------------------------------------------------------");
        foreach(var a in fileTrackingRecords)
        {
            Console.WriteLine(a.FileHeader + "|" + a.FileType + "|" + a.ProcessorId + "|" + a.SequenceNumber + "|" + a.ClaimDate + "|" + a.Status + "|" + a.TransactionCount);
        }

        Console.WriteLine("--------------------------------------------------------------------------------------------");
        foreach(var a in nostroRecords)
        {
            Console.WriteLine(a.FileHeader + "|" + a.SettlementCurrency + "|" + a.GrossSettlement +"|" + a.GrossSettlementPosition + "|" + a.PassThroughFees + "|" + a.PassThroughFeesPosition  
            + "|" + a.NetworkFees + "|" + a.NetworkFeesPosition + "|" + a.NetworkRateAmount + "|" + a.NetworkRatePosition + "|" +
            a.NetSettlement + "|" + a.NetSettlementPosition);
        }
        Console.WriteLine("--------------------------------------------------------------------------------------------");

        foreach(var a in issuerSettlementSection)
        {
            Console.WriteLine(a);
        }

        List<SettlementSummary> issuerSettlementSummaries = settlementSummaryParser.SettlementSummaryParse(issuerSettlementSection);
        List<SettlementSummary> acquirerSettlemtnSummaries = settlementSummaryParser.SettlementSummaryParse(acquirerSettlementSection);
        foreach(var a in issuerSettlementSummaries)
        {
            Console.WriteLine(a.FileHeader + "|" + a.SettlementCurrency + "|" + a.ChannelType + "|" + a.TransactionType + "|" + a.PresentmentCurrency
            + "|" + a.TransactionCount + "|" + a.PresentmentAmount + "|" + a.OutclearAmount + "|" + a.OutclearPosition + "|" + a.InclearAmount
            + "|" + a.InclearPosition + "|" + a.NetAmount + "|" + a.NetPosition);
           // |FileHeader|SettlementCurrency|ChannelType|TranasctionType|PresentmentCurrency|TransactionCount|PresentmentAmount|PresentmentPosition|OutclearAmount|OutclearPosition|InclearAmount|InclearPosition|NetAmount|NetPosition|

        }
        Console.WriteLine("--------------------------------------------------------------------------------------------");

        foreach(var a in acquirerSettlemtnSummaries)
        {
            Console.WriteLine(a.FileHeader +  "|" + a.SettlementCurrency + "|" + a.ChannelType + "|" + a.TransactionType + "|" + a.PresentmentCurrency
            + "|" + a.TransactionCount + "|" + a.PresentmentAmount + "|" + a.OutclearAmount + "|" + a.OutclearPosition + "|" + a.InclearAmount
            + "|" + a.InclearPosition + "|" + a.NetAmount + "|" + a.NetPosition);
           // |FileHeader|SettlementCurrency|ChannelType|TranasctionType|PresentmentCurrency|TransactionCount|PresentmentAmount|PresentmentPosition|OutclearAmount|OutclearPosition|InclearAmount|InclearPosition|NetAmount|NetPosition|

        }

    }
}


