using MAS.Backend.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Backend.Data.Seeds;

public static class BetStatusEfSeed
{
    public static void Seed(this EntityTypeBuilder<BetStatus> modelBuilder)
    {
        List<BetStatus> betStatusList = new()
        {
            new()
            {
                IdBetStatus = 1,
                Status = "Nierozpoczęto"
            },
            new()
            {
                IdBetStatus = 2,
                Status = "W trakcie"
            },
            new()
            {
                IdBetStatus = 3,
                Status = "Wygrany"
            },
            new()
            {
                IdBetStatus = 4,
                Status = "Przegrany"
            }
        };
        modelBuilder.HasData(betStatusList);
    }
}