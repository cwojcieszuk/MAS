using MAS.Backend.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Backend.Data.Seeds;

public static class BetSportOptionEfSeed
{
    public static void Seed(this EntityTypeBuilder<BetSportOption> modelBuilder)
    {
        List<BetSportOption> options = new()
        {
            new()
            {
                IdBetSportOption = 1,
                IdBetSport = 1,
                IdBetSportType = 1,
                IdBetStatus = 1,
                Odds = (float)1.3
            },
            new()
            {
                IdBetSportOption = 2,
                IdBetSport = 1,
                IdBetSportType = 3,
                IdBetStatus = 1,
                Odds = (float)1.6
            },
            new()
            {
                IdBetSportOption = 3,
                IdBetSport = 1,
                IdBetSportType = 2,
                IdBetStatus = 1,
                Odds = (float)2.5
            },
            new()
            {
                IdBetSportOption = 4,
                IdBetSport = 2,
                IdBetSportType = 1,
                IdBetStatus = 1,
                Odds = (float)1.4
            },
            new()
            {
                IdBetSportOption = 5,
                IdBetSport = 2,
                IdBetSportType = 3,
                IdBetStatus = 1,
                Odds = (float)2.4
            },
            new()
            {
                IdBetSportOption = 6,
                IdBetSport = 2,
                IdBetSportType = 2,
                IdBetStatus = 1,
                Odds = (float)2.5
            },
            new()
            {
                IdBetSportOption = 7,
                IdBetSport = 3,
                IdBetSportType = 1,
                IdBetStatus = 1,
                Odds = (float)1.9
            },
            new()
            {
                IdBetSportOption = 8,
                IdBetSport = 3,
                IdBetSportType = 3,
                IdBetStatus = 1,
                Odds = (float)4
            },
            new()
            {
                IdBetSportOption = 9,
                IdBetSport = 3,
                IdBetSportType = 2,
                IdBetStatus = 1,
                Odds = (float)1.19
            },
            new()
            {
                IdBetSportOption = 10,
                IdBetSport = 4,
                IdBetSportType = 1,
                IdBetStatus = 1,
                Odds = (float)19
            },
            new()
            {
                IdBetSportOption = 11,
                IdBetSport = 4,
                IdBetSportType = 3,
                IdBetStatus = 1,
                Odds = (float)3.0
            },
            new()
            {
                IdBetSportOption = 12,
                IdBetSport = 4,
                IdBetSportType = 2,
                IdBetStatus = 1,
                Odds = (float)1.7
            },
        };
        modelBuilder.HasData(options);
    }
}