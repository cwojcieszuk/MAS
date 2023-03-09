using MP1;
const string _fileName = @"C:\Users\s22798\Desktop\MAS\MP1\MP1\players.json";

Player player = new Player("Marek", new DateTime(2001, 12, 01), new List<string>(), "Man");
Player player1 = new Player("Arek", new DateTime(2003, 12, 01), new List<string>{ "Man United", "Real Madrid" });
Player player2 = new Player("Jarek", new DateTime(1999, 12, 01), new List<string>{ "Man City", "Fc Barcelona" });
Player player3 = new Player("Marcin", new DateTime(2006, 12, 01), new List<string>{ "Liverpool" });

player2.AddToFavouriteTeams("Bayern Monachium");
player3.AddToFavouriteTeams(new[] { "PSG", "Real Madrid" });

Player.WriteExtent(_fileName);
Player.ReadExtent(_fileName);

Player.ShowExtent();
Player.ShowYoungestPlayer();
