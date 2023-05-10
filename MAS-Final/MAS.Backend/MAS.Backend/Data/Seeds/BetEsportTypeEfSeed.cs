using MAS.Backend.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Backend.Data.Seeds;

public static class BetEsportTypeEfSeed
{
    public static void Seed(this EntityTypeBuilder<BetEsportType> modelBuilder)
    {
        List<BetEsportType> betEsportTypes = new()
        {
            new()
            {
                IdBetEsportType = 1,
                Name = "Wygra 1 drużyna"
            },
            new()
            {
                IdBetEsportType = 2,
                Name = "Wygra 2 drużyna"
            },
            new()
            {
                IdBetEsportType = 3,
                Name = "Remis"
            }
        };
        modelBuilder.HasData(betEsportTypes);
    }
}