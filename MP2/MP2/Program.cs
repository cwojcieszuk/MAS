using MP2.Kompozycja;
using MP2.Kwalifikowana;
using MP2.Z_atrybutem;
using MP2.Z_Atrybutem;
using static MP2.Kompozycja.Lake;

namespace MP2;

public static class Program
{
    public static void Main(string[] args)
    { 
        //InitZwykla();
        //InitZAtrybutem();
        //InitKwalifikowana();
        InitKompozycja();
    }

    static void InitZwykla()
    {
        var player1 = new Player("marek", 20, "20 8000 8000 8000 8000 8000");
        var bet1 = new Bet(DateTime.Now, 200);
        var bet2 = new Bet(DateTime.Now, 2);

        bet1.AddPlayer(player1);

        player1.AddBet(bet1);
        player1.AddBet(bet2);

        Console.WriteLine(player1);
    }

    static void InitZAtrybutem()
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

    static void InitKwalifikowana()
    {
        var student1 = new Student("Cezary", "Wojcieszuk", "s22798");
        var student2 = new Student("Jan", "Kowalski", "s1337");

        var school1 = new School("PJATK", 1994);
        var school2 = new School("PW", 1915);

        student1.AddSchool(school1);
        student1.AddSchool(school2);
        student2.AddSchool(school2);

        Console.WriteLine(school1.FindStudentByQualif("s227982"));
    }

    static void InitKompozycja()
    {
        var lake1 = new Lake("Sniardwy", "Warminsko-mazurskie", 113.4);

        var fish1 = Fish.CreateFish("karp", lake1);
        var fish2 = Fish.CreateFish("karp2", lake1);
        var fish3 = Fish.CreateFish("karp4", lake1);

        Console.WriteLine(lake1);
    }
}