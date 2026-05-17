namespace AmexParser;
public class SettlementSummaryParser
{
    private readonly Configuration _configuration;
    public SettlementSummaryParser(Configuration configuration)
    {
        _configuration = configuration;
    }

    public List<SettlementSummary> SettlementSummaryParse(List<string> settlementReports)
    {
        List<SettlementSummary> settlementSummaries =  new List<SettlementSummary>();
        foreach(var report in settlementReports)
        {
            
        }
        return settlementSummaries;
    }

    public bool IsTransactionTypeHeader(string line) => line.Contains("PRESENTMENT") || line.Contains("CHARGEBACK");
    public bool IsChannelTypeHeader(string line) => line.Contains("POS") || line.Contains("ATM");
    public bool IsSettlementCurrencyHeader(string line) => line.Contains("SETTLEMENT CURRENCY CODE");
    public string GetSettlementCurrency(string line) => line.Substring(_configuration.SettlementCurrencyStart,_configuration.SettlementCurrencyLength).Trim();
    public string GetChannelType(string line) => line.Substring(_configuration.ChannelTypeStart,_configuration.ChannelTypeLength).Trim();
    public string GetTransactionType(string line) =>  line.Substring(_configuration.SettlementTranasctionTypeStart, _configuration.SettlementTranscationTypeLength).Trim();
    public string GetPresentmentCurrency(string line) => line.Substring(_configuration.PresentmentCodeStart, _configuration.PresentmentCodeLength).Trim();
    public int GetTransactionCount(string line) => int.Parse(line.Substring(_configuration.SettlementTransactionCountStart, _configuration.SettlementTransactionCountLength).Trim());
    public double GetPresentmentAmount(string line) => double.Parse(line.Substring(_configuration.PresentmentAmountStart,_configuration.PresentmentAmountLength).Trim());
    public double GetOutClearAmount(string line) => double.Parse(line.Substring(_configuration.OutclearAmountStart,  _configuration.OutclearAmountLength).Trim());
    public string GetOutClearPosition(string line) => line.Substring(_configuration.OutClearPositionStart, _configuration.OutClearPositionLength).Trim();
    public double GetInclearAmount(string line) => double.Parse(line.Substring(_configuration.InclearAmountStart, _configuration.InclearAmountLength).Trim());
    public string GetInclearPosition(string line) => line.Substring(_configuration.InClearPositionStart, _configuration.InClearPositionLength).Trim();
    public double GetNetAmount(string line) => double.Parse(line.Substring(_configuration.NetAmountStart, _configuration.NetAmountLength).Trim());

}