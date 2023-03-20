namespace MP3.Dynamic;

public class InexperiencedEmployee : EmployeeExperience
{
    public override string ToString()
    {
        return base.ToString() + "Inexperienced";
    }
}