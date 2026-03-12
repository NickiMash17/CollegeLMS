using StudentApp.Models;

namespace StudentApp.Services;

public class StudentService
{
    private readonly List<Student> _students = new();

    public void Add(int studentID, string studentName, string course, double mark)
    {
        var student = new Student
        {
            StudentID = studentID,
            StudentName = studentName,
            Course = course,
            Mark = mark
        };
        _students.Add(student);
    }

    public List<Student> GetAll() => new(_students);
}