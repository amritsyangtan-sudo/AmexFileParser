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
                SettlementGroupCategory newGroup = new SettlementGroupCategory();

                newGroup.EntityType = settlementSummary.FileHeader;
                newGroup.SettlementCurrency = settlementSummary.SettlementCurrency;
                newGroup.Channel = settlementSummary.ChannelType;
                newGroup.TransactionType = settlementSummary.TransactionType;
                newGroup.TotalAmount = settlementSummary.InclearAmount;
                newGroup.Position = settlementSummary.InclearPosition;
                settlementGroupCategories.Add(newGroup);
            }
            else
            {
                existingGroup.TotalAmount += settlementSummary.InclearAmount;
            }
        }

        return settlementGroupCategories;
    }
}
