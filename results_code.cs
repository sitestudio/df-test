using System;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static string Main()
    {
        var random = new Random();
        var records = new List<StudentsResponse>();

        for (int i = 0; i < 5; i++)
        {
            var studentCount = random.Next(1, 11); // Create between 1 and 10 students
            var students = new List<Student>();

            for (int j = 0; j < studentCount; j++)
            {
                students.Add(new Student
                {
                    enrolmentId = random.Next(1000, 9999),
                    eqId = Guid.NewGuid().ToString(),
                    imageId = random.Next(1, 100),
                    familyName = $"Family{j}",
                    givenNames = $"GivenName{j}",
                    birthDate = DateTime.Now.AddYears(-random.Next(5, 18)).ToString("o"),
                    age = random.Next(5, 18).ToString(),
                    rollClass = $"Class{j}",
                    yearLevel = new YearLevel
                    {
                        code = $"YL{random.Next(1, 13)}",
                        description = $"Year Level {random.Next(1, 13)}"
                    },
                    enrolmentStatus = new EnrolmentStatus
                    {
                        code = "active",
                        description = "Active"
                    },
                    gender = new Gender
                    {
                        code = random.Next(0, 2) == 0 ? "M" : "F",
                        description = random.Next(0, 2) == 0 ? "Male" : "Female"
                    },
                    hasAbsentNote = random.Next(0, 2) == 0,
                    absences = new List<Absence>()
                });
            }

            records.Add(new StudentsResponse { students = students });
        }

        return JsonSerializer.Serialize(records, new JsonSerializerOptions { WriteIndented = true });
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
    public List<Absence> absences { get; set; }
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

public class Absence
{
    public int studentAbsenceId { get; set; }
    public int enrolmentId { get; set; }
    public string absenceDate { get; set; }
    public AbsenceReason absenceReason { get; set; }
    public PartOfDayAbsence partOfDayAbsence { get; set; }
    public string lateEarlyTime { get; set; }
    public string note { get; set; }
    public string modifiedDate { get; set; }
    public string modifiedBy { get; set; }
}

public class AbsenceReason
{
    public string code { get; set; }
    public string description { get; set; }
}

public class PartOfDayAbsence
{
    public string code { get; set; }
    public string description { get; set; }
}

// Example usage
string json = Program.Main();