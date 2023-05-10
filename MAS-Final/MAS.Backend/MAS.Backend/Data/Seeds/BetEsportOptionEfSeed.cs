using MAS.Backend.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Backend.Data.Seeds;

public static class BetEsportOptionEfSeed
{
    public static void Seed(this EntityTypeBuilder<BetEsportOption> modelBuilder)
    {
        List<BetEsportOption> options = new()
        {
            new()
            {
                IdBetEsportOption = 1,
                IdBetEsportType = 1,
                IdBetEsport = 1,
                Odds = (float)1.5,
                IdBetStatus = 1
            },
            new()
            {
                IdBetEsportOption = 2,
                IdBetEsportType = 3,
                IdBetEsport = 1,
                Odds = (float)5.1,
                IdBetStatus = 1
            },
            new()
            {
                IdBetEsportOption = 3,
                IdBetEsportType = 2,
                IdBetEsport = 1,
                Odds = (float)2.9,
                IdBetStatus = 1
            },
            new()
            {
                IdBetEsportOption = 4,
                IdBetEsportType = 1,
                IdBetEsport = 2,
                Odds = (float)1.8,
                IdBetStatus = 1
            },
            new()
            {
                IdBetEsportOption = 5,
                IdBetEsportType = 3,
                IdBetEsport = 2,
                Odds = (float)2.5,
                IdBetStatus = 1
            },
            new()
            {
                IdBetEsportOption = 6,
                IdBetEsportType = 2,
                IdBetEsport = 2,
                Odds = (float)6.7,
                IdBetStatus = 1
            },
            new()
            {
                IdBetEsportOption = 7,
                IdBetEsportType = 1,
                IdBetEsport = 3,
                Odds = (float)2.5,
                IdBetStatus = 1
            },
            new()
            {
                IdBetEsportOption = 8,
                IdBetEsportType = 3,
                IdBetEsport = 3,
                Odds = (float)6,
                IdBetStatus = 1
            },
            new()
            {
                IdBetEsportOption = 9,
                IdBetEsportType = 2,
                IdBetEsport = 3,
                Odds = (float)1.15,
                IdBetStatus = 1
            }
        };
        modelBuilder.HasData(options);
    }
}