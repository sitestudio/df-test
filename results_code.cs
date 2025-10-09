using System;
using System.Collections.Generic;
using System.Text.Json;

public class StudentSchedulesResponse
{
    public List<Student> Students { get; set; }
}

public class Student
{
    public int EnrolmentId { get; set; }
    public string EqId { get; set; }
    public int? ImageId { get; set; }
    public string FamilyName { get; set; }
    public string GivenNames { get; set; }
    public string BirthDate { get; set; }
    public string Age { get; set; }
    public string RollClass { get; set; }
    public YearLevel YearLevel { get; set; }
    public EnrolmentStatus EnrolmentStatus { get; set; }
    public Gender Gender { get; set; }
    public bool HasAbsentNote { get; set; }
    public List<Absence> Absences { get; set; }
}

public class YearLevel
{
    public string Code { get; set; }
    public string Description { get; set; }
}

public class EnrolmentStatus
{
    public string Code { get; set; }
    public string Description { get; set; }
}

public class Gender
{
    public string Code { get; set; }
    public string Description { get; set; }
}

public class Absence
{
    public int StudentAbsenceId { get; set; }
    public int EnrolmentId { get; set; }
    public string AbsenceDate { get; set; }
    public AbsenceReason AbsenceReason { get; set; }
    public PartOfDayAbsence PartOfDayAbsence { get; set; }
    public string LateEarlyTime { get; set; }
    public string Note { get; set; }
    public string ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
}

public class AbsenceReason
{
    public string Code { get; set; }
    public string Description { get; set; }
}

public class PartOfDayAbsence
{
    public string Code { get; set; }
    public string Description { get; set; }
}

public static class DataGenerator
{
    public static StudentSchedulesResponse GenerateSampleData(int numberOfStudents)
    {
        var students = new List<Student>();
        var random = new Random();

        for (int i = 1; i <= numberOfStudents; i++)
        {
            var birthDate = DateTime.Now.AddYears(-random.Next(5, 20)).ToString("o"); // ISO 8601 format
            students.Add(new Student
            {
                EnrolmentId = i,
                EqId = $"EQ{i:D4}",
                ImageId = random.Next(1, 100),
                FamilyName = "Smith",
                GivenNames = "John",
                BirthDate = birthDate,
                Age = (DateTime.Now.Year - DateTime.Parse(birthDate).Year).ToString(),
                RollClass = "Class A",
                YearLevel = new YearLevel { Code = "Y1", Description = "Year 1" },
                EnrolmentStatus = new EnrolmentStatus { Code = "ENROLLED", Description = "Currently Enrolled" },
                Gender = new Gender { Code = "M", Description = "Male" },
                HasAbsentNote = random.Next(0, 2) == 1,
                Absences = new List<Absence>
                {
                    new Absence
                    {
                        StudentAbsenceId = random.Next(1000),
                        EnrolmentId = i,
                        AbsenceDate = DateTime.Now.AddDays(-random.Next(1, 30)).ToString("o"), // ISO 8601 format
                        AbsenceReason = new AbsenceReason { Code = "SICK", Description = "Sick Leave" },
                        PartOfDayAbsence = new PartOfDayAbsence { Code = "AM", Description = "Morning" },
                        LateEarlyTime = random.Next(0, 2) == 1 ? "Late" : null,
                        Note = "None",
                        ModifiedDate = DateTime.Now.ToString("o"),
                        ModifiedBy = "admin"
                    }
                }
            });
        }

        return new StudentSchedulesResponse { Students = students };
    }
}

// Usage
var sampleData = DataGenerator.GenerateSampleData(100);
string jsonOutput = JsonSerializer.Serialize(sampleData, new JsonSerializerOptions { WriteIndented = true });
Console.WriteLine(jsonOutput);