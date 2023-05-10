using MAS.Backend.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Backend.Data.Seeds;

public static class BetEfSeed
{
    public static void Seed(this EntityTypeBuilder<Bet> modelBuilder)
    {
        List<Bet> bets = new()
        {
            new()
            {
                IdBet = 1,
                Date = new DateTime(2023, 05, 18, 21, 0, 0),
                IdBetSport = 1,
                IdBetEsport = null,
            },
            new()
            {
                IdBet = 2,
                Date = new DateTime(2023, 05, 18, 21, 0, 0),
                IdBetSport = 2,
                IdBetEsport = null,
            },
            new()
            {
                IdBet = 3,
                Date = new DateTime(2023, 05, 18, 21, 0, 0),
                IdBetSport = 3,
                IdBetEsport = null,
            },
            new()
            {
                IdBet = 4,
                Date = new DateTime(2023, 05, 18, 21, 0, 0),
                IdBetSport = 4,
                IdBetEsport = null,
            },
            new()
            {
                IdBet = 5,
                Date = new DateTime(2023, 05, 18, 21, 0, 0),
                IdBetSport = null,
                IdBetEsport = 1,
            },
            new()
            {
                IdBet = 6,
                Date = new DateTime(2023, 05, 18, 21, 0, 0),
                IdBetSport = null,
                IdBetEsport = 2,
            },
            new()
            {
                IdBet = 7,
                Date = new DateTime(2023, 05, 18, 21, 0, 0),
                IdBetSport = null,
                IdBetEsport = 3,
            }
        };
        modelBuilder.HasData(bets);
    }
}