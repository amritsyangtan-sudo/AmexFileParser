namespace AmexParser;
public class NostroParser
{
    private readonly Configuration _configuration;
    public NostroParser(Configuration configuration)
    {
        _configuration = configuration;
    }

    public List<Nostro> NostroParse(List<string> nostroReport)
    {
        string settlementCurrency = "";
        double grossSettlement = 0;
        string grossSettlementPosition = "";
        double passThroughFees = 0;
        string passThroughFeesPosition = "";
        double networkFees = 0;
        string networkFeesPosition = "";
        double networkRateAmount = 0;
        string networkRatePosition = "";
        double netSettlement = 0; 
        string netSettlementPosition = "";
        List<Nostro> nostroRecords = new List<Nostro>();
        foreach(var nostroLine in nostroReport)
        {
            
            if (nostroLine.Contains("SETTLEMENT CURRENCY CODE"))
            {
                settlementCurrency = StringExtractor.SafeExtract(nostroLine, _configuration.SettlementCurrencyStart,_configuration.SettlementCurrencyLength, "SettlementCurrency");
            }    
            if (nostroLine.Contains("TOTAL GROSS SETTLEMENT"))
            {
                if (StringExtractor.TryExtractDouble(nostroLine, _configuration.NostroAmountStart,_configuration.NostroAmountLength, "GrossSettlement", out double amount))
                    grossSettlement = amount;
                grossSettlementPosition = GetNostroPosition(StringExtractor.SafeExtract(nostroLine, _configuration.NostroPositionStart, _configuration.NostroPositionLength, "GrossSettlementPosition"));
            }    
            if (nostroLine.Contains("TOTAL PASS THROUGH FEES"))
            {
                if (StringExtractor.TryExtractDouble(nostroLine, _configuration.NostroAmountStart,_configuration.NostroAmountLength, "PassThroughFees", out double amount))
                    passThroughFees = amount;
                passThroughFeesPosition = GetNostroPosition(StringExtractor.SafeExtract(nostroLine, _configuration.NostroPositionStart, _configuration.NostroPositionLength, "PassThroughFeesPosition"));
            }    
            if (nostroLine.Contains("TOTAL NETWORK FEES"))
            {
                if (StringExtractor.TryExtractDouble(nostroLine, _configuration.NostroAmountStart,_configuration.NostroAmountLength, "NetworkFees", out double amount))
                    networkFees = amount;
                networkFeesPosition = GetNostroPosition(StringExtractor.SafeExtract(nostroLine, _configuration.NostroPositionStart, _configuration.NostroPositionLength, "NetworkFeesPosition"));
            }    
            if (nostroLine.Contains("TOTAL ISSUER'S/NETWORK RATE AMOUNT"))
            {
                networkRateAmount = double.Parse(nostroLine.Substring(_configuration.NostroAmountStart,_configuration.NostroAmountLength).Trim());
                networkRatePosition = GetNostroPosition(nostroLine.Substring(_configuration.NostroPositionStart, _configuration.NostroPositionLength));
            }    
            if (nostroLine.Contains("TOTAL NET SETTLEMENT "))
            {
                netSettlement = double.Parse(nostroLine.Substring(_configuration.NostroAmountStart,_configuration.NostroAmountLength).Trim());
                netSettlementPosition = GetNostroPosition(nostroLine.Substring(_configuration.NostroPositionStart, _configuration.NostroPositionLength));
                nostroRecords.Add(new Nostro
                {
                   FileHeader = "Nostro Summary",
                   SettlementCurrency =  settlementCurrency,
                   GrossSettlement = grossSettlement,
                   GrossSettlementPosition = grossSettlementPosition,
                   PassThroughFees = passThroughFees,
                   PassThroughFeesPosition = passThroughFeesPosition,
                   NetworkFees = networkFees,
                   NetworkFeesPosition = networkFeesPosition,
                   NetworkRateAmount = networkRateAmount,
                   NetworkRatePosition = networkRatePosition,
                   NetSettlement = netSettlement,
                   NetSettlementPosition = netSettlementPosition
            
                });
            }    

        }
        return nostroRecords;
    }

    public string GetNostroPosition(string line)
    {
        return string.IsNullOrWhiteSpace(line) ? "DR":"CR";
    }
}