using MAS.Backend.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Backend.Data.Seeds;

public static class BetSportTypeEfSeed
{
    public static void Seed(this EntityTypeBuilder<BetSportType> modelBuilder)
    {
        List<BetSportType> betSportTypes = new()
        {
            new()
            {
                IdBetSportType = 1,
                Name = "Wygra 1 drużyna"
            },
            new()
            {
                IdBetSportType = 2,
                Name = "Wygra 2 drużyna"
            },
            new()
            {
                IdBetSportType = 3,
                Name = "Remis"
            }
        };
        modelBuilder.HasData(betSportTypes);
    }
}