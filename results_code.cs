using System;
using System.Collections.Generic;
using System.Text.Json;

public class StudentInformationResponse
{
    public List<Student> Students { get; set; }
    public int TotalStudents { get; set; }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string EnrollmentDate { get; set; }
    public string Grade { get; set; }
}

public static class Program
{
    public static string Main()
    {
        var random = new Random();
        var studentInformationResponses = new List<StudentInformationResponse>();

        for (int i = 0; i < 5; i++)
        {
            var students = new List<Student>();
            int numberOfStudents = random.Next(1, 11); // 1 to 10 students

            for (int j = 0; j < numberOfStudents; j++)
            {
                students.Add(new Student
                {
                    Id = j + 1,
                    Name = "Student " + (j + 1),
                    EnrollmentDate = DateTime.Now.AddDays(-random.Next(1, 100)).ToString("yyyy-MM-dd"),
                    Grade = "Grade " + random.Next(1, 13)
                });
            }

            studentInformationResponses.Add(new StudentInformationResponse
            {
                Students = students,
                TotalStudents = numberOfStudents
            });
        }

        return JsonSerializer.Serialize(studentInformationResponses);
    }
}

string json = Program.Main();