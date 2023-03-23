namespace MP4.Unique;

public class Student
{
    public string FirstName { get; set; }
    public int IndexNumber { get; set; }
    private School _school { get; set; }
    public School School { get => _school; set => AddSchool(value); }

    public Student(string firstName, int indexNumber)
    {
        FirstName = firstName;
        IndexNumber = indexNumber;
    }

    private void AddSchool(School school)
    {
        if(school != null)
        {
            School = school;
            school.AddStudent(this);
        }
    }

    public override string ToString()
    {
        return base.ToString() + $" First name: {FirstName} Index: {IndexNumber}";
    }
}