namespace AmexParser;

public class SettlementSummarizer
{
    public List<SettlementGroupCategory> SummarizeSettlement(List<SettlementSummary> settlementSummaries)
    {
        List<SettlementGroupCategory> settlementGroupCategories = new List<SettlementGroupCategory>();

        foreach (var settlementSummary in settlementSummaries)
        {
            SettlementGroupCategory existingGroup = null;

            foreach (var settlementGroupCategory in settlementGroupCategories)
            {
                bool sameEntity = settlementSummary.FileHeader == settlementGroupCategory.EntityType;
                bool sameCurrency = settlementSummary.SettlementCurrency == settlementGroupCategory.SettlementCurrency;
                bool sameChannel = settlementSummary.ChannelType == settlementGroupCategory.Channel;
                bool sameTransactionType = settlementSummary.TransactionType == settlementGroupCategory.TransactionType;
                if (sameEntity && sameCurrency && sameChannel && sameTransactionType)
                {
                    existingGroup = settlementGroupCategory;
                    break;
                }
            }

            if (existingGroup == null)
            {
                settlementGroupCategories.Add(new SettlementGroupCategory
                {
                    EntityType = settlementSummary.FileHeader,
                    SettlementCurrency = settlementSummary.SettlementCurrency,
                    Channel = settlementSummary.ChannelType,
                    TransactionType = settlementSummary.TransactionType,
                    TotalAmount = settlementSummary.OutclearAmount,
                    Position = settlementSummary.OutclearPosition
                });
            }
            else
            {
                existingGroup.TotalAmount += settlementSummary.OutclearAmount;
            }
        }

        return settlementGroupCategories;
    }
}
