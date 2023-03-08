namespace MP1
{
    public class Player
    {
        private string _name; 
        private DateTime _dateOfBirth; 
        private string? _gender; 
        private static int _minimalAge = 18;
        private int _age => DateTime.Now.Year - _dateOfBirth.Year;
        private List<string> _favoriteTeams; 
        
        private static List<Player> extent = new List<Player>();
        
        public Player(string name, DateTime dateOfBirth,List<string> favoriteTeams, string gender = null)
        {
            _name = name;
            _dateOfBirth = dateOfBirth;
            _favoriteTeams = favoriteTeams;
            _gender = gender;

            AddPlayer(this);
        }

        public void AddToFavouriteTeams(string team)
        {
            _favoriteTeams.Add(team);
        }

        public void AddToFavouriteTeams(string[] teams)
        {
            _favoriteTeams.AddRange(teams);
        }

        public override string ToString()
        {
            string gender = _gender == null ? "" : $"gender: {_gender}";
            string favoriteTeams = _favoriteTeams.Count <= 0 ? "" : $"favourite teams: {string.Join(", ", _favoriteTeams)}";
            return base.ToString() + $": {_name} age: {_age} {gender}{favoriteTeams}";
        }

        public static void ShowExtent()
        {
            Console.WriteLine($"Extent of the class: {nameof(Player)} \n");

            foreach(Player player in extent)
            {
                Console.WriteLine(player);
            } 
            Console.WriteLine("");
        }

        public static void ShowYoungestPlayer()
        {
            Player youngestPlayer = extent.Find(player => player._dateOfBirth == extent.Max(player => player._dateOfBirth));

            if (youngestPlayer == null) return;
            
            Console.WriteLine("Youngest player is:");
            Console.WriteLine(youngestPlayer);
        }
        
        private static void AddPlayer(Player player)
        {
            extent.Add(player);
        }

        private static void RemovePlayer(Player player)
        {
            extent.Remove(player);
        }
    }
}
