using StudentApp.Services;

var studentService = new StudentService();
bool running = true;

while (running)
{
    Console.WriteLine("\n----- Simple LMS System -----");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. View Students");
    Console.WriteLine("3. Exit");
    Console.Write("\nChoose an option: ");

    var input = Console.ReadLine()?.Trim();

    switch (input)
    {
        case "1":
            AddStudent();
            break;
        case "2":
            ViewStudents();
            break;
        case "3":
            running = false;
            Console.WriteLine("Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}

void AddStudent()
{
    Console.Write("Student ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Invalid ID.");
        return;
    }

    Console.Write("Student Name: ");
    var name = Console.ReadLine()?.Trim() ?? "";

    Console.Write("Course: ");
    var course = Console.ReadLine()?.Trim() ?? "";

    Console.Write("Mark: ");
    if (!double.TryParse(Console.ReadLine(), out double mark))
    {
        Console.WriteLine("Invalid mark.");
        return;
    }

    studentService.Add(id, name, course, mark);
    Console.WriteLine("Student added successfully!");
}

void ViewStudents()
{
    var students = studentService.GetAll();

    if (students.Count == 0)
    {
        Console.WriteLine("\nNo students found.");
        return;
    }

    Console.WriteLine("\n{0,-12} {1,-20} {2,-20} {3}", "Student ID", "Student Name", "Course", "Mark");
    Console.WriteLine(new string('-', 60));

    foreach (var s in students)
    {
        Console.WriteLine("{0,-12} {1,-20} {2,-20} {3}", s.StudentID, s.StudentName, s.Course, s.Mark);
    }
}