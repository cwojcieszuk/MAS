using MAS.Backend.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Backend.Data.Seeds;

public static class BetEsportEfSeed
{
    public static void Seed(this EntityTypeBuilder<BetEsport> modelBuilder)
    {
        List<BetEsport> betEsports = new()
        {
            new()
            {
                IdBetEsport = 1,
                GameName = "CS:GO",
                Team1 = "FaZe Clan",
                Team2 = "Virtus Pro"
            },
            new()
            {
                IdBetEsport = 2,
                GameName = "CS:GO",
                Team1 = "NIP",
                Team2 = "Vitality"
            },
            new()
            {
                IdBetEsport = 3,
                GameName = "CS:GO",
                Team1 = "Cloud9",
                Team2 = "G2"
            }
        };
        modelBuilder.HasData(betEsports);
    }
}