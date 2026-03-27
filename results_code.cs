using System;
using System.Collections.Generic;
using System.Text.Json;

public class AttendanceStatus
{
    public string code { get; set; }
    public string description { get; set; }
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
    public AttendanceStatus attendanceStatus { get; set; }
    public bool hasAttendanceChanges { get; set; }
    public bool hasAbsentNote { get; set; }
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
    public List<Absence> absences { get; set; }
}

public class NotRollMarkableReason
{
    public string code { get; set; }
    public string description { get; set; }
}

public class StudentInformationResponse
{
    public int? attendanceId { get; set; }
    public int version { get; set; }
    public bool isRollMarkable { get; set; }
    public NotRollMarkableReason notRollMarkableReason { get; set; }
    public bool isRollMarked { get; set; }
    public string rollMarkedDate { get; set; }
    public string rollMarkedUser { get; set; }
    public List<Student> students { get; set; }
}

public static class Program
{
    public static string Main()
    {
        var response = new List<StudentInformationResponse>();

        Random rand = new Random();

        for (int i = 0; i < 5; i++)
        {
            var studentCount = rand.Next(1, 10); // Random number of students per record.
            var students = new List<Student>();

            for (int j = 0; j < studentCount; j++)
            {
                students.Add(new Student
                {
                    enrolmentId = rand.Next(1000, 9999),
                    attendanceStatus = new AttendanceStatus
                    {
                        code = "ATTEND" + j,
                        description = "Attended"
                    },
                    hasAttendanceChanges = rand.Next(0, 2) == 1,
                    hasAbsentNote = rand.Next(0, 2) == 1,
                    eqId = Guid.NewGuid().ToString(),
                    imageId = rand.Next(0, 2) == 1 ? (int?)rand.Next(100, 999) : null,
                    familyName = "Family" + j,
                    givenNames = "Given" + j,
                    birthDate = DateTime.Now.AddYears(-rand.Next(5, 20)).ToString("yyyy-MM-dd"),
                    age = ((DateTime.Now.Year - DateTime.Now.AddYears(-rand.Next(5, 20)).Year)).ToString(),
                    rollClass = "Class" + (j % 5),
                    yearLevel = new YearLevel
                    {
                        code = "YL" + (j % 5),
                        description = "Year Level " + (j % 5)
                    },
                    enrolmentStatus = new EnrolmentStatus
                    {
                        code = "ENROLLED",
                        description = "Currently Enrolled"
                    },
                    gender = new Gender
                    {
                        code = "M",
                        description = "Male"
                    },
                    absences = new List<Absence>
                    {
                        new Absence
                        {
                            studentAbsenceId = rand.Next(100, 999),
                            enrolmentId = rand.Next(1000, 9999),
                            absenceDate = DateTime.Now.AddDays(-rand.Next(1, 10)).ToString("yyyy-MM-dd"),
                            absenceReason = new AbsenceReason
                            {
                                code = "SICK",
                                description = "Sick"
                            },
                            partOfDayAbsence = new PartOfDayAbsence
                            {
                                code = "MORNING",
                                description = "Morning"
                            },
                            lateEarlyTime = null,
                            note = "Absent due to illness.",
                            modifiedDate = DateTime.Now.ToString("yyyy-MM-dd"),
                            modifiedBy = "Admin"
                        }
                    }
                });
            }

            response.Add(new StudentInformationResponse
            {
                attendanceId = i % 2 == 0 ? (int?)rand.Next(100, 999) : null,
                version = 1,
                isRollMarkable = true,
                notRollMarkableReason = null,
                isRollMarked = false,
                rollMarkedDate = null,
                rollMarkedUser = null,
                students = students
            });
        }

        return JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true });
    }
}

string json = Program.Main();