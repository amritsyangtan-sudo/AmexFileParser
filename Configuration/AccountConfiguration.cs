namespace AmexParser;
public class AccountConfiguration
{
    public string USDNostroAccount {get;} = "USD Nostro Account";
    public string INRNostroAccount {get;} = "INR Nostro Account";
    public string IntermediateNPRSettlementAccount {get;} = "Intermediate NPR Settlement Account";
    public string IntermediateUSDSettlementAccount {get;} = "Intermediate USD Settlement Account";
    public string INRPayableAccount {get;} = "INR Payable Account";
    public string USDPayableAccount {get;} = "USD Payable Account";
    public string NPRChargebackAccount {get;} = "NPR Chargeback Account";
    public string USDChargebackAccount {get;} = "USD Chargeback Account";
    public string ReimburseDebitAccount {get;} = "Reimburse Debit Account";
    public string ReimburseCreditAccount {get;} = "Reimburse Credit Account";
    public string ReceivableAccount {get;} = "Receivable Account";
    public string ExchangeGainLossAccount {get;} = "Exchange Gain Loss Account";
    public string BillingAccount {get;} = "Billing Account";

    /*
        nostro account
        payable account
        bin account
        fee dr/cr account
        intermediate settlement account

    */
}