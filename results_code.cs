using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

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
    public string absenceDate { get; set; }
    public AbsenceReason absenceReason { get; set; }
    public PartOfDayAbsence partOfDayAbsence { get; set; }
    public string lateEarlyTime { get; set; }
    public string note { get; set; }
    public string modifiedDate { get; set; }
    public string modifiedBy { get; set; }
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

public class StudentInformationResponse
{
    public List<Student> students { get; set; }
}

public static class Program
{
    public static string Main()
    {
        var random = new Random();
        var studentInfoResponseList = new List<StudentInformationResponse>();

        for (int i = 0; i < 5; i++)
        {
            int numberOfStudents = random.Next(1, 11); // Random number between 1 and 10
            var students = new List<Student>();

            for (int j = 0; j < numberOfStudents; j++)
            {
                students.Add(new Student
                {
                    enrolmentId = random.Next(1000, 9999),
                    eqId = Guid.NewGuid().ToString(),
                    imageId = random.Next(1, 100),
                    familyName = "FamilyName" + j,
                    givenNames = "GivenName" + j,
                    birthDate = DateTime.Now.AddYears(-random.Next(5, 18)).ToString("yyyy-MM-dd"),
                    age = (DateTime.Now.Year - (DateTime.Now.Year - random.Next(5, 18))).ToString(),
                    rollClass = "RollClass" + random.Next(1, 5),
                    yearLevel = new YearLevel
                    {
                        code = "YL" + random.Next(1, 13),
                        description = "Year Level " + random.Next(1, 13).ToString()
                    },
                    enrolmentStatus = new EnrolmentStatus
                    {
                        code = "ES" + random.Next(1, 4),
                        description = "Enrolment Status " + random.Next(1, 4).ToString()
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

            studentInfoResponseList.Add(new StudentInformationResponse { students = students });
        }

        return JsonSerializer.Serialize(studentInfoResponseList, new JsonSerializerOptions { WriteIndented = true });
    }
}

string json = Program.Main();