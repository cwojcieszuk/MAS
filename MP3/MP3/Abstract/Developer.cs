using MP3.Multi_aspect;

namespace MP3.Abstract;

public abstract class Developer
{
    public string Name { get; set; }
    public string[] Languages { get; set; }
    public DeveloperExperience Experience { get; set; }

    protected Developer(string name, string[] languages, DeveloperExperience experience)
    {
        Name = name;
        Languages = languages;
        Experience = experience;
    }

    public abstract void Code();
    public override string ToString()
    {
        string languages = Languages.Length <= 0 ? "" : $"Languages: {string.Join(", ", Languages)}";
        return base.ToString() + $" Name: {Name} {languages} {Experience}";
    }
}