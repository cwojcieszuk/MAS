namespace MP2.Kwalifikowana;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StudentIndex { get; set; }

    private List<School> _schools = new List<School>();

    public Student(string firstName, string lastName, string studentIndex)
    {
        FirstName = firstName;
        LastName = lastName;
        StudentIndex = studentIndex;
    }

    public override string ToString()
    {
        return base.ToString() + $" First name: {FirstName} Last name: {LastName} Index: {StudentIndex}";
    }

    public void AddSchool(School school)
    {
        if (!_schools.Contains(school))
        {
            _schools.Add(school);
            
            school.AddStudentsQualif(this);
        }
    }
}