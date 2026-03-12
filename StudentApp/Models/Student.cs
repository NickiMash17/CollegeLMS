namespace StudentApp.Models;

public class Student
{
    public int StudentID { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string Course { get; set; } = string.Empty;
    public double Mark { get; set; }
}