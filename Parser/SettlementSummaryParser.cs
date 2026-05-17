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
        string currentSettlementCurrency = "";
        string currentChannelType = "";
        string currentTransactionType = "";
        string fileHeader = "";
        // bool startOfTransactionDataRow = false;
        List<SettlementSummary> settlementSummaries = new List<SettlementSummary>();
        foreach (var currentLine in settlementReports)
        {
            if(currentLine.Contains("JULIAN DATE"))
            {
                fileHeader = GetReportType(currentLine)
;            }

            if (IsSettlementCurrencyHeader(currentLine))
            {
                currentSettlementCurrency = GetSettlementCurrency(currentLine);
                continue;
            }
            if (IsChannelTypeHeader(currentLine))
            {
                currentChannelType = GetChannelType(currentLine);
                continue;
            }
            if (IsTransactionTypeHeader(currentLine))
            {
                currentTransactionType = GetTransactionType(currentLine);
            }
            // if (startOfTransactionDataRow && string.IsNullOrWhiteSpace(currentLine) == false )
            // {
            //     startOfTransactionDataRow = false;
            // }

            if (IsSettlementDataRow(currentLine))
            {
                settlementSummaries.Add(new SettlementSummary
                {
                    FileHeader = fileHeader,
                    SettlementCurrency = currentSettlementCurrency,
                    ChannelType = currentChannelType,
                    TransactionType = currentTransactionType,
                    PresentmentCurrency = GetPresentmentCurrency(currentLine),
                    TransactionCount = GetTransactionCount(currentLine),
                    PresentmentAmount = GetPresentmentAmount(currentLine),
                    //PresentmentPosition = 
                    OutclearAmount = GetOutClearAmount(currentLine),
                    OutclearPosition = GetOutClearPosition(currentLine),
                    InclearAmount = GetInclearAmount(currentLine),
                    InclearPosition = GetInclearPosition(currentLine),
                    NetAmount = GetNetAmount(currentLine),
                    NetPosition = GetNetPosition(currentLine)

                });
            }
        }
        return settlementSummaries;
    }

    public bool IsTransactionTypeHeader(string line) => line.Contains("1ST PRESENTMENT") || line.Contains("CHARGEBACK") || line.Contains("CASH") || line.Contains("ATM ACQUIRER FEES");
    public bool IsChannelTypeHeader(string line)
    {
        string value = line.Trim();

        return value == "POS" || value == "ATM";
    }
    public bool IsSettlementCurrencyHeader(string line) => line.Contains("SETTLEMENT CURRENCY CODE");
    public string GetSettlementCurrency(string line) => line.Substring(_configuration.SettlementCurrencyStart, _configuration.SettlementCurrencyLength).Trim();
    public string GetChannelType(string line) => line.Substring(_configuration.ChannelTypeStart, _configuration.ChannelTypeLength).Trim();
    public string GetTransactionType(string line) => line.Substring(_configuration.SettlementTranasctionTypeStart, _configuration.SettlementTranscationTypeLength).Trim();
    public string GetPresentmentCurrency(string line) => line.Substring(_configuration.PresentmentCodeStart, _configuration.PresentmentCodeLength).Trim();
    public int GetTransactionCount(string line) => int.Parse(line.Substring(_configuration.SettlementTransactionCountStart, _configuration.SettlementTransactionCountLength).Trim());
    public double GetPresentmentAmount(string line) => double.Parse(line.Substring(_configuration.PresentmentAmountStart, _configuration.PresentmentAmountLength).Trim());
    public double GetOutClearAmount(string line) => double.Parse(line.Substring(_configuration.OutclearAmountStart, _configuration.OutclearAmountLength).Trim());
    public string GetOutClearPosition(string line) => line.Substring(_configuration.OutClearPositionStart, _configuration.OutClearPositionLength).Trim();
    public double GetInclearAmount(string line) => double.Parse(line.Substring(_configuration.InclearAmountStart, _configuration.InclearAmountLength).Trim());
    public string GetInclearPosition(string line) => line.Substring(_configuration.InClearPositionStart, _configuration.InClearPositionLength).Trim();
    public double GetNetAmount(string line) => double.Parse(line.Substring(_configuration.NetAmountStart, _configuration.NetAmountLength).Trim());
    public string GetNetPosition(string line) => line.Substring(_configuration.NetPositionStart, _configuration.NetPositionLength).Trim();

    public bool IsSettlementDataRow(string line)
    {
        string presentmentCurrency =line.Substring(_configuration.PresentmentCodeStart,_configuration.PresentmentCodeLength).Trim();
        string transactionCount =line.Substring(_configuration.SettlementTransactionCountStart,_configuration.SettlementTransactionCountLength).Trim();
        return int.TryParse(presentmentCurrency, out _) && int.TryParse(transactionCount, out _);
    }
    
    public string GetReportType(string line) => line.Substring(_configuration.ReportTypeStart, _configuration.ReportTypeLength).Trim();

}