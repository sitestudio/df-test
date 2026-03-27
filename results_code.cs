using System;
using System.Collections.Generic;
using System.Text.Json;

public class StudentInformationResponse
{
    public List<Student> students { get; set; }
}

public class Student
{
    public string id { get; set; }
    public string name { get; set; }
    public string enrollmentDate { get; set; }
    public List<string> courses { get; set; }
}

public static class Program
{
    public static string Main()
    {
        var response1 = new StudentInformationResponse
        {
            students = new List<Student>
            {
                new Student { id = "001", name = "Alice Smith", enrollmentDate = "2023-08-20T00:00:00Z", courses = new List<string> { "Biology", "Chemistry" } },
                new Student { id = "002", name = "Bob Johnson", enrollmentDate = "2023-09-01T00:00:00Z", courses = new List<string> { "Mathematics" } }
            }
        };

        var response2 = new StudentInformationResponse
        {
            students = new List<Student>
            {
                new Student { id = "003", name = "Charlie Brown", enrollmentDate = "2023-07-15T00:00:00Z", courses = new List<string> { "History", "English", "Art" } },
                new Student { id = "004", name = "David Wilson", enrollmentDate = "2023-08-25T00:00:00Z", courses = new List<string> { "Physics" } },
                new Student { id = "005", name = "Eve Davis", enrollmentDate = "2023-09-01T00:00:00Z", courses = new List<string> { "Mathematics", "Philosophy" } }
            }
        };

        var response3 = new StudentInformationResponse
        {
            students = new List<Student>
            {
                new Student { id = "006", name = "Frank Miller", enrollmentDate = "2023-06-10T00:00:00Z", courses = new List<string> { "Geography", "Biology", "Computer Science" } },
                new Student { id = "007", name = "Grace Lee", enrollmentDate = "2023-09-15T00:00:00Z", courses = new List<string> { "Mathematics", "Chemistry" } },
                new Student { id = "008", name = "Henry Thomas", enrollmentDate = "2023-05-01T00:00:00Z", courses = new List<string> { "History" } }
            }
        };

        var response4 = new StudentInformationResponse
        {
            students = new List<Student>
            {
                new Student { id = "009", name = "Ivy Harris", enrollmentDate = "2023-08-01T00:00:00Z", courses = new List<string> { "Chemistry", "Mathematics" } }
            }
        };

        var response5 = new StudentInformationResponse
        {
            students = new List<Student>
            {
                new Student { id = "010", name = "Jack Wilson", enrollmentDate = "2023-07-20T00:00:00Z", courses = new List<string> { "Literature", "Art" } },
                new Student { id = "011", name = "Karen White", enrollmentDate = "2023-08-15T00:00:00Z", courses = new List<string> { "Science", "Mathematics" } },
                new Student { id = "012", name = "Larry Brown", enrollmentDate = "2023-09-10T00:00:00Z", courses = new List<string> { "Math", "Physics" } },
                new Student { id = "013", name = "Megan Green", enrollmentDate = "2023-03-01T00:00:00Z", courses = new List<string> { "Geography", "Biology" } }
            }
        };

        string jsonResponse1 = JsonSerializer.Serialize(response1);
        string jsonResponse2 = JsonSerializer.Serialize(response2);
        string jsonResponse3 = JsonSerializer.Serialize(response3);
        string jsonResponse4 = JsonSerializer.Serialize(response4);
        string jsonResponse5 = JsonSerializer.Serialize(response5);

        return jsonResponse1 + "
" + jsonResponse2 + "
" + jsonResponse3 + "
" + jsonResponse4 + "
" + jsonResponse5;
    }
}

string json = Program.Main();