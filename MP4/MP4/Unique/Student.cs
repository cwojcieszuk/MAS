namespace MP4.Unique;

public class Student
{
    public string FirstName { get; set; }
    public int IndexNumber { get; set; }

    private static Dictionary<int, Student> _students = new Dictionary<int, Student>();

    public Student(string firstName, int indexNumber)
    {
        FirstName = firstName;
        IndexNumber = indexNumber;
        
        AddIndexNumber(indexNumber);
    }

    public static void ShowStudents()
    {
        foreach (var student in _students)
        {
            Console.WriteLine(student.Value);
        }
    }

    private void AddIndexNumber(int indexNumber)
    {
        if (_students.ContainsKey(IndexNumber))
        {
            throw new Exception($"Student with index {indexNumber} already exists");
        }
        
        _students.Add(indexNumber, this);
    }

    public override string ToString()
    {
        return base.ToString() + $" First name: {FirstName} Index: {IndexNumber}";
    }
}