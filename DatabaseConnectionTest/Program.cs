using System;
using Microsoft.Data.SqlClient;

namespace DatabaseConnectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                "Server=HACKER17\\SQLEXPRESS;Database=CTUCollegeDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Ask user for student details
                    Console.Write("Enter Student ID: ");
                    int studentId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter First Name: ");
                    string firstName = Console.ReadLine();

                    Console.Write("Enter Last Name: ");
                    string lastName = Console.ReadLine();

                    Console.Write("Enter Age: ");
                    int age = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Course ID: ");
                    string courseId = Console.ReadLine();

                    // Open connection
                    conn.Open();
                    Console.WriteLine("Database connection successful!");

                    // Insert query
                    string insertQuery = "INSERT INTO Student (StudentID, FirstName, LastName, Age, CourseID) " +
                                         "VALUES (@StudentID, @FirstName, @LastName, @Age, @CourseID)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", studentId);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Age", age);
                        cmd.Parameters.AddWithValue("@CourseID", courseId);

                        int rows = cmd.ExecuteNonQuery();
                        Console.WriteLine($"{rows} student record inserted successfully!");
                    }

                    // Confirm by selecting all students
                    string selectQuery = "SELECT StudentID, FirstName, LastName, Age, CourseID FROM Student";
                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("\nStudent Information\n");

                        while (reader.Read())
                        {
                            Console.WriteLine($"Student ID: {reader["StudentID"]}");
                            Console.WriteLine($"First Name: {reader["FirstName"]}");
                            Console.WriteLine($"Last Name: {reader["LastName"]}");
                            Console.WriteLine($"Age: {reader["Age"]}");
                            Console.WriteLine($"Course: {reader["CourseID"]}");
                            Console.WriteLine("====================");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            Console.ReadLine();
        }
    }
}