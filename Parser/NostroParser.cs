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
                settlementCurrency = nostroLine.Substring(_configuration.SettlementCurrencyStart,_configuration.SettlementCurrencyLength).Trim();
            }    
            if (nostroLine.Contains("TOTAL GROSS SETTLEMENT"))
            {
                grossSettlement = double.Parse(nostroLine.Substring(_configuration.NostroAmountStart,_configuration.NostroAmountLength).Trim());
                grossSettlementPosition = GetNostroPosition(nostroLine.Substring(_configuration.NostroPositionStart, _configuration.NostroPositionLength));
            }    
            if (nostroLine.Contains("TOTAL PASS THROUGH FEES"))
            {
                passThroughFees = double.Parse(nostroLine.Substring(_configuration.NostroAmountStart,_configuration.NostroAmountLength).Trim());
                passThroughFeesPosition = GetNostroPosition(nostroLine.Substring(_configuration.NostroPositionStart, _configuration.NostroPositionLength));
            }    
            if (nostroLine.Contains("TOTAL NETWORK FEES"))
            {
                networkFees = double.Parse(nostroLine.Substring(_configuration.NostroAmountStart,_configuration.NostroAmountLength).Trim());
                networkFeesPosition = GetNostroPosition(nostroLine.Substring(_configuration.NostroPositionStart, _configuration.NostroPositionLength));
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