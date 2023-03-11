using MP2.Kompozycja;
using MP2.Kwalifikowana;
using MP2.Z_atrybutem;
using MP2.Z_Atrybutem;


//zwykla

namespace MP2;

public static class Program
{
    public static void Main(string[] args)
    {
        
    }

    public static void InitZwykla()
    {
        var player1 = new Player("marek", 20, "20 8000 8000 8000 8000 8000");
        var bet1 = new Bet(DateTime.Now, 200);
        var bet2 = new Bet(DateTime.Now, 2);

        player1.AddBet(bet1);
        player1.AddBet(bet2);

        Console.WriteLine(player1);
    }

    public static void InitZAtrybutem()
    {
        var ballPlayer1 = new BallPlayer("Giannis", "PF");
        var ballPlayer2 = new BallPlayer("Middleton", "SF");

        var team1 = new Team("Milwaukee Bucks");

        var contract1 = new Contract(DateTime.Now, DateTime.Now.AddYears(2), ballPlayer1, team1);
        var contract2 = new Contract(DateTime.Now, DateTime.Now.AddYears(3), ballPlayer2, team1);

        ballPlayer1.ShowTeams();
        ballPlayer2.ShowTeams();

        team1.ShowPlayers();
    }

    public static void InitKwalifikowana()
    {
        var student1 = new Student("Cezary", "Wojcieszuk", "s22798");
        var student2 = new Student("Jan", "Kowalski", "s1337");

        var school1 = new School("PJATK", 1994);
        var school2 = new School("PW", 1915);

        student1.AddSchool(school1);
        student1.AddSchool(school2);
        student2.AddSchool(school2);

        Console.WriteLine(school1.FindStudentByQualif(student1.StudentIndex));
    }

    public static void InitKompozycja()
    {
        var lake1 = new Lake("Sniardwy", "Warminsko-mazurskie", 113.4);

        var fish1 = lake1.CreateFish("Karp");
        var fish2 = lake1.CreateFish("Szczupak");

        Console.WriteLine(lake1);
    }
}