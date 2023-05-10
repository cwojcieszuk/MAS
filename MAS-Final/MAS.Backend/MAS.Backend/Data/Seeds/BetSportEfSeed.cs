using MAS.Backend.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Backend.Data.Seeds;

public static class BetSportEfSeed
{
    public static void Seed(this EntityTypeBuilder<BetSport> modelBuilder)
    {
        List<BetSport> betSports = new()
        {
            new()
            {
                IdBetSport = 1,
                SportName = "Piłka nożna",
                Team1 = "Manchester United",
                Team2 = "Manchester City"
            },
            new ()
            {
                IdBetSport = 2,
                SportName = "Piłka nożna",
                Team1 = "Arsenal",
                Team2 = "Liverpool"
            },
            new()
            {
                IdBetSport = 3,
                SportName = "Piłka nożna",
                Team1 = "Fc Barcelona",
                Team2 = "Real Madryt"
            },
            new()
            {
                IdBetSport = 4,
                SportName = "Piłka nożna",
                Team1 = "PSG",
                Team2 = "Bayern Monachium"
            }
        };
        modelBuilder.HasData(betSports);
    }
}