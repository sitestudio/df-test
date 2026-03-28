using System;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static string Main()
    {
        var random = new Random();
        var studentsResponses = new List<StudentsResponse>();

        // Generate 5 sample records
        for (int i = 0; i < 5; i++)
        {
            var studentCount = random.Next(1, 11);  // Random count between 1 and 10
            var students = new List<Student>();

            for (int j = 0; j < studentCount; j++)
            {
                students.Add(new Student
                {
                    enrolmentId = random.Next(1000, 9999),
                    eqId = Guid.NewGuid().ToString(),
                    imageId = random.Next(1, 1000),
                    familyName = "Family" + j,
                    givenNames = "Given" + j,
                    birthDate = DateTime.Now.AddYears(-random.Next(5, 18)).ToString("o"), // ISO 8601 format
                    age = (DateTime.Now.Year - (DateTime.Now.Year - random.Next(5, 18))).ToString(),
                    rollClass = "Class" + random.Next(1, 5),
                    yearLevel = new YearLevel
                    {
                        code = "Year" + random.Next(1, 13),
                        description = "Year description"
                    },
                    enrolmentStatus = new EnrolmentStatus
                    {
                        code = "Active",
                        description = "Enrolled"
                    },
                    gender = new Gender
                    {
                        code = random.Next(0, 2) == 0 ? "M" : "F",
                        description = random.Next(0, 2) == 0 ? "Male" : "Female"
                    },
                    hasAbsentNote = random.Next(0, 2) == 0
                });
            }

            studentsResponses.Add(new StudentsResponse
            {
                students = students
            });
        }

        return JsonSerializer.Serialize(studentsResponses, new JsonSerializerOptions { WriteIndented = true });
    }
}

public class StudentsResponse
{
    public List<Student> students { get; set; }
}

public class Student
{
    public int enrolmentId { get; set; }
    public string eqId { get; set; }
    public int? imageId { get; set; }
    public string familyName { get; set; }
    public string givenNames { get; set; }
    public string birthDate { get; set; }
    public string age { get; set; }
    public string rollClass { get; set; }
    public YearLevel yearLevel { get; set; }
    public EnrolmentStatus enrolmentStatus { get; set; }
    public Gender gender { get; set; }
    public bool hasAbsentNote { get; set; }
}

public class YearLevel
{
    public string code { get; set; }
    public string description { get; set; }
}

public class EnrolmentStatus
{
    public string code { get; set; }
    public string description { get; set; }
}

public class Gender
{
    public string code { get; set; }
    public string description { get; set; }
}

string json = Program.Main();