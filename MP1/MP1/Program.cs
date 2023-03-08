using MP1;

Player player = new Player("Marek", new DateTime(2001, 12, 01), new List<string>(), "Man");
Player player1 = new Player("Arek", new DateTime(2003, 12, 01), new List<string>{ "Man United", "Real Madrid" });
Player player2 = new Player("Jarek", new DateTime(1999, 12, 01), new List<string>{ "Man City", "Fc Barcelona" });
Player player3 = new Player("Marcin", new DateTime(2006, 12, 01), new List<string>{ "Liverpool" });

player2.AddToFavouriteTeams("Bayern Monachium");
player3.AddToFavouriteTeams(new []{"PSG", "Real Madrid"});

Player.ShowExtent();
Player.ShowYoungestPlayer();
