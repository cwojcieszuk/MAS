using MP3.Multi_aspect;

namespace MP3.Abstract;

public class BackendDeveloper : Developer
{
    public string Database { get; set; }

    public BackendDeveloper(string name, string[] languages, DeveloperExperience experience, string database) : base(name, languages, experience)
    {
        Database = database;
    }
    
    public override void Code()
    {
        Console.WriteLine("SELECT * FROM EMP");
    }

    public override string ToString()
    {
        return base.ToString() + $" Database: {Database}";
    }
}