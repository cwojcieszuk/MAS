namespace MP2.Kwalifikowana;

public class School
{
    public string Name { get; set; }
    public int CreationYear { get; set; }
    private Dictionary<string, Student> _studentsQualif = new Dictionary<string, Student>();

    public School(string name, int creationYear)
    {
        Name = name;
        CreationYear = creationYear;
    }

    public override string ToString()
    {
        return base.ToString() + $" Name: {Name} Creation year: {CreationYear}";
    }

    public void AddStudentsQualif(Student student)
    {
        if (!_studentsQualif.ContainsKey(student.StudentIndex))
        {
            _studentsQualif.Add(student.StudentIndex, student);
            
            student.AddSchool(this);
        }
    }

    public Student FindStudentByQualif(string studentIndex)
    {
        if (!_studentsQualif.ContainsKey(studentIndex))
        {
            throw new Exception("Student not found");
        }

        return _studentsQualif[studentIndex];
    }
}