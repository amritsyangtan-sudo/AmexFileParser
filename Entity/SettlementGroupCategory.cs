namespace AmexParser;
public class SettlementGroupCategory
{
    public string EntityType {get;set;} //issuer -acquirer
    public string SettlementCurrency {get;set;} //356/840
    public string Channel {get;set;} //pos -atm
    public string TransactionType {get;set;} //1st presentment, 2nd presentment/ chargeback
    public double TotalAmount {get;set;}
    public string Position {get;set;}
}