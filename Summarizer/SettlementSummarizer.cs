namespace AmexParser;
public class SettlementSummarizer
{

    public List<SettlementGroupCategory> Summarize(List<SettlementSummary> settlementSummaries)
    {
        List<SettlementGroupCategory> settlementGroupCategories = new List<SettlementGroupCategory>();
        foreach(var settlementSummary in settlementSummaries)
        {

        }
        return settlementGroupCategories;
    }

    //public 
    /*
        type = issuer /acquirer
        currency = 356/840
        channel = pos /atm
        transaction type = 1st presentment / 2nd presentment / chargeback
        key example = issuer|840|pos|1stpresentment|

    */
}


/*

Settlement Summary Issuer|356|POS|1ST PRESENTMENT|356|3|10176|0||10176||10176|
Settlement Summary Issuer|356|POS|1ST PRESENTMENT|356|1|6200|0||6200|CR|6200|CR

Settlement Summary Issuer|840|POS|1ST PRESENTMENT|036|1|24.19|0||17.04||17.04|
Settlement Summary Issuer|840|POS|1ST PRESENTMENT|124|1|40.66|0||29.68||29.68|
Settlement Summary Issuer|840|POS|1ST PRESENTMENT|458|2|890|0||224.48||224.48|
Settlement Summary Issuer|840|POS|1ST PRESENTMENT|764|1|6256|0||195.8||195.8|
Settlement Summary Issuer|840|POS|1ST PRESENTMENT|826|2|35.99|0||48.46||48.46|
Settlement Summary Issuer|840|POS|1ST PRESENTMENT|840|9|548.51|0||548.51||548.51|
--------------------------------------------------------------------------------------------
Settlement Summary Acquirer|356|POS|1ST PRESENTMENT|524|19|317000.25|198125.17|CR|0||198125.17|CR
Settlement Summary Acquirer|840|POS|1ST PRESENTMENT|524|152|2156258.48|14475.44|CR|0||14475.44|CR
Settlement Summary Acquirer|840|POS|1ST PRESENTMENT|840|20|21881.04|21881.04|CR|0||21881.04|CR
Settlement Summary Acquirer|840|ATM|CASH|524|3|42000|282.95|CR|0||282.95|CR
Settlement Summary Acquirer|840|ATM|ATM ACQUIRER FEES|840|3|3|0||3|CR|3|CR

Total Issuer POS INR
Total Issuer POS USD
Total Acquirer POS INR
Total Acquirer POS USD

*/


/*
List<SettlementCategorySummary> summaries = new List<SettlementCategorySummary>();

foreach(var row in rows)
{
    SettlementCategorySummary existingSummary = summaries.FirstOrDefault(summary => summary.EntityType == row.EntityType && summary.SettlementCurrency == row.SettlementCurrency
        && summary.ChannelType == row.ChannelType);

    if(existingSummary == null)
    {
        summaries.Add(
            new SettlementCategorySummary
            {
                EntityType = row.EntityType,

                SettlementCurrency =
                    row.SettlementCurrency,

                ChannelType =
                    row.ChannelType,

                TotalAmount =
                    row.NetAmount
            });
    }
    else
    {
        existingSummary.TotalAmount +=
            row.NetAmount;
    }
}
*/