using MP3.Multi_aspect;

namespace MP3.Abstract;

public class FrontendDeveloper : Developer
{
    public string Technology { get; set; }

    public FrontendDeveloper(string name, string[] languages, DeveloperExperience experience, string technology) : base(name, languages, experience)
    {
        Technology = technology;
    }

    public override void Code()
    {
        Console.WriteLine("<ng-container *ngIf='MP3.isDone == True'>");
        Console.WriteLine("     <span>20pkt</span>");
        Console.WriteLine("</ng-container>");
    }

    public override string ToString()
    {
        return base.ToString() + $" Technology: {Technology}";
    }
}