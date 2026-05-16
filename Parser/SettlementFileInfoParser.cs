namespace AmexParser;

public class SettlementFileInfoParser
{
    private Configuration _configuration;
    public SettlementFileInfoParser(Configuration configuration)
    {
        _configuration = configuration;
    }
    
    public SettlementFileInfo FileInfoParse(string line)
    {
        return new SettlementFileInfo()
        {
            BusinessDate = line.Substring(_configuration.BusinessDateStart,_configuration.BusinessDateLength).Trim(),
            ProcessingDate = line.Substring(_configuration.ProcessingDateStart,_configuration.ProcessingDateLength).Trim(),
            JulianDate = "Julian Date"
        };
    }
}