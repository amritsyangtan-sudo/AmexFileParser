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
    public string GetSettlementCurrency(string line) => StringExtractor.SafeExtract(line, _configuration.SettlementCurrencyStart, _configuration.SettlementCurrencyLength, "SettlementCurrency");
    public string GetChannelType(string line) => StringExtractor.SafeExtract(line, _configuration.ChannelTypeStart, _configuration.ChannelTypeLength, "ChannelType");
    public string GetTransactionType(string line) => StringExtractor.SafeExtract(line, _configuration.SettlementTranasctionTypeStart, _configuration.SettlementTranscationTypeLength, "TransactionType");
    public string GetPresentmentCurrency(string line) => StringExtractor.SafeExtract(line, _configuration.PresentmentCodeStart, _configuration.PresentmentCodeLength, "PresentmentCurrency");
    
    public int GetTransactionCount(string line)
    {
        if (StringExtractor.TryExtractInt(line, _configuration.SettlementTransactionCountStart, _configuration.SettlementTransactionCountLength, "TransactionCount", out int result))
            return result;
        throw new FormatException("Failed to parse TransactionCount");
    }
    
    public double GetPresentmentAmount(string line)
    {
        if (StringExtractor.TryExtractDouble(line, _configuration.PresentmentAmountStart, _configuration.PresentmentAmountLength, "PresentmentAmount", out double result))
            return result;
        throw new FormatException("Failed to parse PresentmentAmount");
    }
    
    public double GetOutClearAmount(string line)
    {
        if (StringExtractor.TryExtractDouble(line, _configuration.OutclearAmountStart, _configuration.OutclearAmountLength, "OutclearAmount", out double result))
            return result;
        throw new FormatException("Failed to parse OutclearAmount");
    }
    
    public string GetOutClearPosition(string line) => StringExtractor.SafeExtract(line, _configuration.OutClearPositionStart, _configuration.OutClearPositionLength, "OutClearPosition");
    
    public double GetInclearAmount(string line)
    {
        if (StringExtractor.TryExtractDouble(line, _configuration.InclearAmountStart, _configuration.InclearAmountLength, "InclearAmount", out double result))
            return result;
        throw new FormatException("Failed to parse InclearAmount");
    }
    
    public string GetInclearPosition(string line) => StringExtractor.SafeExtract(line, _configuration.InClearPositionStart, _configuration.InClearPositionLength, "InclearPosition");
    
    public double GetNetAmount(string line)
    {
        if (StringExtractor.TryExtractDouble(line, _configuration.NetAmountStart, _configuration.NetAmountLength, "NetAmount", out double result))
            return result;
        throw new FormatException("Failed to parse NetAmount");
    }
    
    public string GetNetPosition(string line) => StringExtractor.SafeExtract(line, _configuration.NetPositionStart, _configuration.NetPositionLength, "NetPosition");

    public bool IsSettlementDataRow(string line)
    {
        try
        {
            string presentmentCurrency = StringExtractor.SafeExtract(line, _configuration.PresentmentCodeStart, _configuration.PresentmentCodeLength, "PresentmentCurrency");
            string transactionCount = StringExtractor.SafeExtract(line, _configuration.SettlementTransactionCountStart, _configuration.SettlementTransactionCountLength, "TransactionCount");
            return int.TryParse(presentmentCurrency, out _) && int.TryParse(transactionCount, out _);
        }
        catch (ArgumentException)
        {
            return false;
        }
    }
    
    public string GetReportType(string line) => StringExtractor.SafeExtract(line, _configuration.ReportTypeStart, _configuration.ReportTypeLength, "ReportType");

}