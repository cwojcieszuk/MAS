﻿// See https://aka.ms/new-console-template for more information

using MP4.Atrybut;
using MP4.Bag;
using MP4.Custom;
using MP4.Ordered;
using MP4.Subset;
using MP4.Unique;
using MP4.XOR;

namespace MP4;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("");
        
        //InitAttribute();
        //InitUnique();
        //InitOrdered();
        //InitBag();
        InitXor();
        //InitSubset();
        //InitCustom();
    }

    static void InitAttribute()
    {
        Video video1 = new Video(2, "quick");
        Console.WriteLine(video1);
        video1.Length = 4;
        // video1.Length = 1.5;
        //
        // Console.WriteLine(video1);
    }

    static void InitUnique()
    {
        Student stud1 = new Student("Jan", 20138);
        Student stud2 = new Student("Marek", 21377);
        //Student stud3 = new Student("Arek", 20138);
        School school = new School() { Name = "PJATK" };

        school.AddStudent(stud1);
        school.AddStudent(stud2);
        school.ShowStudents();
        school.AddStudent(stud2);
    }

    static void InitOrdered()
    {
        Game game1 = new Game("Hogwarts Legacy", "Warner bros");
        Game game2 = new Game("Wo Long: Fallen Dynasty", "Team ninja");
        Game game3 = new Game("Assasin's creed Valhalla", "Ubisoft");

        game1.AddPlayer(new GamePlayer { Name = "zzzz" });
        game1.AddPlayer(new GamePlayer { Name = "aaaa" });

        game1.ShowPlayers();
    }

    static void InitBag()
    {
        Customer customer1 = new Customer("john", "john@gmail.com", "Warsaw");
        Product product1 = new Product("keyboard", 1);

        Order order1 = new Order(DateTime.Now, customer1, product1);
        Order order2 = new Order(DateTime.Now, customer1, product1);
        
        Console.WriteLine(order1);
        Console.WriteLine(order2);
    }

    static void InitXor()
    {
        Player player1 = new Player("johny");
        Player player2 = new Player("speed");
        Player player3 = new Player("adin");

        BallTeam ballTeam1 = new BallTeam("Milwaukee", "NBA");
        EsportTeam esportTeam1 = new EsportTeam("Fnatic", "LOL");
        
        player1.AddBallTeam(ballTeam1);
        //player1.AddEsportTeam(esportTeam1);
        player2.AddEsportTeam(esportTeam1);
        player3.AddBallTeam(ballTeam1);
        
        //player2.AddBallTeam(ballTeam1);
        
        ballTeam1.ShowPlayers();
    }

    static void InitSubset()
    {
        FootballPlayer footballPlayer1 = new FootballPlayer("sui", "ST");
        FootballPlayer footballPlayer2 = new FootballPlayer("messi", "RW");
        FootballPlayer footballPlayer3 = new FootballPlayer("bruno", "CAM");
        
        Team team1 = new Team("MANU", "Premier League");
        Team team2 = new Team("Real", "La liga");
        team1.AddPlayer(footballPlayer1);
        team1.AddPlayer(footballPlayer2);
        
        team2.AddPlayer(footballPlayer3);
        
        team1.SetTeamCaptain(footballPlayer2);
        team1.ShowPlayers();
        team1.SetTeamCaptain(footballPlayer1);
        Console.Write(team1.TeamCaptain);
    }

    static void InitCustom()
    {
        Coupon coupon1 = new Coupon("Live", DateTime.Now, CouponStatus.Win);
        Coupon coupon2 = new Coupon("Normal", DateTime.Now, CouponStatus.InProgress);
        
        Coupon.ShowCoupons();
    }
}