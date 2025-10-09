using System;
using System.Collections.Generic;
using System.Text.Json;

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

public class Absence
{
    public int studentAbsenceId { get; set; }
    public int enrolmentId { get; set; }
    public string absenceDate { get; set; } // DateTime to string
    public AbsenceReason absenceReason { get; set; }
    public PartOfDayAbsence partOfDayAbsence { get; set; }
    public string lateEarlyTime { get; set; }
    public string note { get; set; }
    public string modifiedDate { get; set; } // DateTime to string
    public string modifiedBy { get; set; }
}

public class Student
{
    public int enrolmentId { get; set; }
    public string eqId { get; set; }
    public int? imageId { get; set; }
    public string familyName { get; set; }
    public string givenNames { get; set; }
    public string birthDate { get; set; } // DateTime to string
    public string age { get; set; }
    public string rollClass { get; set; }
    public YearLevel yearLevel { get; set; }
    public EnrolmentStatus enrolmentStatus { get; set; }
    public Gender gender { get; set; }
    public bool hasAbsentNote { get; set; }
    public List<Absence> absences { get; set; }
}

public class StudentSchedulesResponse
{
    public List<Student> students { get; set; }
}

public class Program
{
    public static void Main()
    {
        var response = new StudentSchedulesResponse
        {
            students = new List<Student>()
        };

        for (int i = 0; i < 100; i++)
        {
            response.students.Add(new Student
            {
                enrolmentId = i + 1,
                eqId = "EQ" + (i + 1),
                imageId = i % 10 == 0 ? (int?)null : i + 100,
                familyName = "Family" + (i + 1),
                givenNames = "Given" + (i + 1),
                birthDate = DateTime.Now.AddYears(-i).ToString("o"),
                age = (i + 10).ToString(),
                rollClass = "Class" + (i % 5 + 1),
                yearLevel = new YearLevel
                {
                    code = "Y" + (i % 12 + 1),
                    description = "Year " + (i % 12 + 1)
                },
                enrolmentStatus = new EnrolmentStatus
                {
                    code = "Active",
                    description = "Currently enrolled"
                },
                gender = new Gender
                {
                    code = i % 2 == 0 ? "M" : "F",
                    description = i % 2 == 0 ? "Male" : "Female"
                },
                hasAbsentNote = i % 3 == 0,
                absences = new List<Absence>()
            });
        }

        string json = JsonSerializer.Serialize(response);
        Console.WriteLine(json);
    }
}

json = Main()