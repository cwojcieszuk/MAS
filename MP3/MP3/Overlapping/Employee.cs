using MP3.Dynamic;

namespace MP3.Overlapping;

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EmployeeExperience EmployeeExperience { get; set; }
    private string[] _languages;
    private string _testingPlatform;

    public string[] Languages
    {
        get => _languages;
        set
        {
            if (!_employeeTypes.Contains(EmployeeType.Developer))
            {
                throw new Exception("You cant set languages to employee that is not a developer");
            }

            _languages = value;
        }
    }

    public string TestingPlatform
    {
        get => _testingPlatform;
        set
        {
            if (!_employeeTypes.Contains(EmployeeType.Tester))
            {
                throw new Exception("You cant set testing platform to employee that is not a tester");
            }

            _testingPlatform = value;
        }
    }

    private HashSet<EmployeeType> _employeeTypes = new HashSet<EmployeeType>();

    public Employee(string firstName, string lastName, EmployeeExperience employeeExperience)
    {
        FirstName = firstName;
        LastName = lastName;
        EmployeeExperience = employeeExperience;
        
        _employeeTypes.Add(EmployeeType.Employee);
    }

    public void MakeDeveloper(string[] languages)
    {
        _employeeTypes.Add(EmployeeType.Developer);
        Languages = languages;
    }

    public void MakeTester(string testingPlatform)
    {
        _employeeTypes.Add(EmployeeType.Tester);
        TestingPlatform = testingPlatform;
    }

    public override string ToString()
    {
        string testingPlatform = TestingPlatform == null ? "" : $" Testing platform: {_testingPlatform}";
        string languages = Languages == null ? "" : $" Languages: {string.Join(", ", _languages)}";
        return base.ToString() + $" First name: {FirstName} Last name: {LastName}{testingPlatform}{languages} {EmployeeExperience}";
    }
}