using MP3.Abstract;
using MP3.Multi_aspect;

namespace MP3.Multi;

public class FullStackDeveloper : BackendDeveloper, IFrontendDeveloper
{
    private FrontendDeveloper _frontendDev;

    public FullStackDeveloper(string name, string[] languages, string database, DeveloperExperience experience, string technology) : base(name, languages, experience, database)
    {
        _frontendDev = new FrontendDeveloper(null, null, null, technology);
    }

    public override void Code()
    {
        _frontendDev.Code();
        base.Code();
    }

    public override string ToString()
    {
        return base.ToString() + $" Technology: {_frontendDev.Technology}";
    }
}