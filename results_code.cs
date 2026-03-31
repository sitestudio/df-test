using System;
using System.Collections.Generic;
using System.Text.Json;

class AbsenceReason
{
    public string code { get; set; }
    public string description { get; set; }
}

class PartOfDayAbsence
{
    public string code { get; set; }
    public string description { get; set; }
}

class Absence
{
    public int studentAbsenceId { get; set; }
    public int enrolmentId { get; set; }
    public string absenceDate { get; set; }
    public AbsenceReason absenceReason { get; set; }
    public PartOfDayAbsence partOfDayAbsence { get; set; }
    public string note { get; set; }
    public string modifiedDate { get; set; }
    public string modifiedBy { get; set; }
}

class YearLevel
{
    public string code { get; set; }
    public string description { get; set; }
}

class EnrolmentStatus
{
    public string code { get; set; }
    public string description { get; set; }
}

class Gender
{
    public string code { get; set; }
    public string description { get; set; }
}

class Student
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

class StudentSchedulesResponse
{
    public List<Student> students { get; set; }
}

class Program
{
    static void Main()
    {
        var random = new Random();
        var students = new List<Student>();
        for (int i = 0; i < 100; i++)
        {
            var absences = new List<Absence>();
            for (int j = 0; j < random.Next(0, 5); j++)
            {
                absences.Add(new Absence
                {
                    studentAbsenceId = random.Next(1, 1000),
                    enrolmentId = random.Next(1, 100),
                    absenceDate = DateTime.UtcNow.AddDays(-random.Next(1, 100)).ToString("yyyy-MM-ddTHH:mm:ss"),
                    absenceReason = new AbsenceReason { code = "001", description = "Illness" },
                    partOfDayAbsence = new PartOfDayAbsence { code = "full", description = "Full Day" },
                    note = "Sick leave",
                    modifiedDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss"),
                    modifiedBy = "Admin"
                });
            }

            students.Add(new Student
            {
                enrolmentId = random.Next(1, 100),
                eqId = "EQ" + random.Next(1000, 9999),
                imageId = random.Next(1, 100),
                familyName = "Family" + random.Next(1, 100),
                givenNames = "Given" + random.Next(1, 100),
                birthDate = DateTime.UtcNow.AddYears(-random.Next(10, 20)).ToString("yyyy-MM-ddTHH:mm:ss"),
                age = random.Next(10, 20).ToString(),
                rollClass = "Class" + random.Next(1, 10),
                yearLevel = new YearLevel { code = "Y" + random.Next(1, 12), description = "Year " + random.Next(1, 12) },
                enrolmentStatus = new EnrolmentStatus { code = "active", description = "Active" },
                gender = new Gender { code = "M", description = "Male" },
                hasAbsentNote = random.Next(0, 2) == 1,
                absences = absences
            });
        }

        var response = new StudentSchedulesResponse { students = students };

        string json = JsonSerializer.Serialize(response);
        Console.WriteLine(json);
    }
}

// The json variable will later be passed into CSharpScript.RunAsync as the globals parameter
json = Program.Main();