namespace AmexParser;
public class SettlementSummary
{
    public string FileHeader {get;set;} // Issuer/Acquirer
    public string SettlementCurrency {get;set;} // 356/840
    public string ChannelType {get;set;} // ATM/POS
    public string TransactionType {get;set;} // 1st presentment, 2nd presentment, charegeback
    public string PresentmentCurrency {get;set;}
    public int TransactionCount {get;set;}
    public double PresentmentAmount {get;set;}
    public string PresentmentPosition {get;set;}
    public double OutclearAmount {get;set;}
    public string OutclearPosition {get;set;}
    public double InclearAmount {get;set;}
    public string InclearPosition {get;set;}
    public double NetAmount {get;set;}
    public string NetPosition {get;set;}
}

/*
|FileHeader|SettlementCurrency|ChannelType|TranasctionType|PresentmentCurrency|TransactionCount|PresentmentAmount|PresentmentPosition|OutclearAmount|OutclearPosition|InclearAmount|InclearPosition|NetAmount|NetPosition|
*/