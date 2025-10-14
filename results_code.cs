using System;
using System.Collections.Generic;
using System.Text.Json;

public class StudentInformationResponse
{
    public int? attendanceId { get; set; }
    public int version { get; set; }
    public bool isRollMarkable { get; set; }
    public object notRollMarkableReason { get; set; }
    public bool isRollMarked { get; set; }
    public string rollMarkedDate { get; set; }
    public string rollMarkedUser { get; set; }
    public List<Student> students { get; set; }
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

public static string Main()
{
    var random = new Random();
    var responses = new List<StudentInformationResponse>();

    for (int i = 0; i < 5; i++)
    {
        var studentCount = random.Next(1, 11); // Random count of students between 1 and 10
        var students = new List<Student>();
        
        for (int j = 0; j < studentCount; j++)
        {
            students.Add(new Student
            {
                enrolmentId = random.Next(1000, 9999),
                attendanceStatus = new AttendanceStatus
                {
                    code = "ATTD",
                    description = "Attended"
                },
                hasAttendanceChanges = random.Next(0, 2) == 1,
                hasAbsentNote = random.Next(0, 2) == 1,
                eqId = Guid.NewGuid().ToString(),
                imageId = random.Next(100, 999),
                familyName = "FamilyName" + j,
                givenNames = "GivenName" + j,
                birthDate = DateTime.Now.AddYears(-random.Next(6, 18)).ToString("yyyy-MM-dd"),
                age = (DateTime.Now.Year - (DateTime.Now.AddYears(-random.Next(6, 18)).Year)).ToString(),
                rollClass = "Class" + random.Next(1, 5),
                yearLevel = new YearLevel
                {
                    code = "Y" + random.Next(1, 13),
                    description = "Year " + random.Next(1, 13)
                },
                enrolmentStatus = new EnrolmentStatus
                {
                    code = "ENROLLED",
                    description = "Enrolled"
                },
                gender = new Gender
                {
                    code = "M",
                    description = "Male"
                },
                absences = new List<Absence>()
            });
        }
        
        responses.Add(new StudentInformationResponse
        {
            attendanceId = random.Next(1, 100),
            version = 1,
            isRollMarkable = true,
            notRollMarkableReason = null,
            isRollMarked = false,
            rollMarkedDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
            rollMarkedUser = "User" + i,
            students = students
        });
    }

    return JsonSerializer.Serialize(responses, new JsonSerializerOptions { WriteIndented = true });
}

string json = Program.Main();