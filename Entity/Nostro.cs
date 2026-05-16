namespace AmexParser;
public class Nostro
{
    public string FileHeader {get;set;} //NOSTRO
    public string SettlementCurrency {get;set;}
    public double GrossSettlement {get;set;}
    public string GrossSettlementPosition {get;set;}
    public double PassThroughFees {get;set;}
    public string PassThroughFeesPosition {get;set;}
    public double NetworkFees {get;set;}
    public string NetworkFeesPosition {get;set;}
    public double NetworkRateAmount {get;set;}
    public string NetworkRatePosition {get;set;}
    public double NetSettlement {get;set;}
    public string NetSettlementPosition {get;set;}

}