using MAS.Backend.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Backend.Data.Seeds;

public static class TransactionTypeEfSeed
{
    public static void Seed(this EntityTypeBuilder<TransactionType> modelBuilder)
    {
        List<TransactionType> transactionTypes = new()
        {
            new()
            {
                IdTransactionType = 1,
                Type = "Wypłata",
            },
            new()
            {
                IdTransactionType = 2,
                Type = "Wpłata",
            },
        };
        modelBuilder.HasData(transactionTypes);
    }
}