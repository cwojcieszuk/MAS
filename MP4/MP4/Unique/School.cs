using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP4.Unique
{
    public class School
    {
        public string Name { get; set; }
        private Dictionary<int, Student> _students = new Dictionary<int, Student>();

        public void AddStudent(Student student)
        {
            if (_students.ContainsKey(student.IndexNumber))
            {
                throw new Exception($"Student with index {student.IndexNumber} already exists");
            }

            _students.Add(student.IndexNumber, student);
            student.School = this;
        }

        public void ShowStudents()
        {
            foreach(var student in _students)
            {
                Console.WriteLine(student.Value.FirstName + " " + student.Value.IndexNumber);
            }
        }
    }
}
