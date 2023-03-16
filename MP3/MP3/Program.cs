using MP3.Abstract;
using MP3.Multi;
using MP3.Multi_aspect;
using MP3.Overlapping;

public class Program
{
    public static void Main()
    {
        Console.WriteLine();
        //InitAbstract();
        //InitMultiInheritance();
        //InitDynamic();
        //InitOverlapping();

        //add dynamic
    }

    static void InitAbstract()
    {
        Developer dev1 = new FrontendDeveloper("Czarek", new []{ "TS", "JS" }, new JuniorDeveloper() ,"Angular");
        Developer dev2 = new BackendDeveloper("Marek", new []{ "C#", "SQL" }, new MidDeveloper(),"MSSQL");
        
        dev1.Code();
        dev2.Code();
    }

    static void InitMultiInheritance()
    {
        Developer dev1 = new FullStackDeveloper("Czarek", new[] { "TS", "C#" },  "MSSQL", new SeniorDeveloper() ,"Angular");
        
        dev1.Code();
        Console.WriteLine(dev1);
    }

    static void InitDynamic()
    {
        Developer dev1 = new FrontendDeveloper("Jan", new[] { "TS" }, new JuniorDeveloper(), "Angular");
        Console.WriteLine(dev1);
        dev1.Experience = new MidDeveloper();
        
        Console.WriteLine(dev1);
    }

    static void InitOverlapping()
    {
        Employee emp1 = new Employee("Jan", "Kowalski");
        emp1.MakeDeveloper(new []{"C#"});
        
        Console.WriteLine(emp1);
        emp1.MakeTester("Selenium");
        Console.WriteLine(emp1);
    }
}
