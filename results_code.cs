using System;
using System.Collections.Generic;
using System.Text.Json;

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

public class NotRollMarkableReason
{
    public string code { get; set; }
    public string description { get; set; }
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
    var responses = new List<StudentInformationResponse>();

    Random rnd = new Random();

    for (int i = 0; i < 5; i++)
    {
        var response = new StudentInformationResponse
        {
            attendanceId = i % 2 == 0 ? (int?)null : rnd.Next(1, 100),
            version = 1,
            isRollMarkable = true,
            notRollMarkableReason = null,
            isRollMarked = false,
            rollMarkedDate = DateTime.UtcNow.ToString("o"),
            rollMarkedUser = null,
            students = new List<Student>()
        };

        int studentCount = rnd.Next(1, 11); // Random number of students between 1 and 10
        for (int j = 0; j < studentCount; j++)
        {
            var student = new Student
            {
                enrolmentId = rnd.Next(1000, 9999),
                attendanceStatus = new AttendanceStatus { code = "Present", description = "Present" },
                hasAttendanceChanges = false,
                hasAbsentNote = false,
                eqId = "EQ" + rnd.Next(1, 100),
                imageId = null,
                familyName = "Family" + j,
                givenNames = "Given" + j,
                birthDate = DateTime.UtcNow.AddYears(-rnd.Next(5, 18)).ToString("o"),
                age = rnd.Next(5, 18).ToString(),
                rollClass = "Class" + rnd.Next(1, 5),
                yearLevel = new YearLevel { code = "Y" + rnd.Next(1, 13), description = "Year " + rnd.Next(1, 13) },
                enrolmentStatus = new EnrolmentStatus { code = "Active", description = "Active" },
                gender = new Gender { code = "M", description = "Male" },
                absences = new List<Absence>()
            };

            int absenceCount = rnd.Next(0, 3); // Random number of absences (0 to 2)
            for (int k = 0; k < absenceCount; k++)
            {
                var absence = new Absence
                {
                    studentAbsenceId = rnd.Next(1, 1000),
                    enrolmentId = student.enrolmentId,
                    absenceDate = DateTime.UtcNow.AddDays(-rnd.Next(1, 30)).ToString("o"),
                    absenceReason = new AbsenceReason { code = "SICK", description = "Sick" },
                    partOfDayAbsence = new PartOfDayAbsence { code = "AM", description = "AM" },
                    lateEarlyTime = null,
                    note = "Note for absence",
                    modifiedDate = DateTime.UtcNow.ToString("o"),
                    modifiedBy = "System"
                };
                student.absences.Add(absence);
            }

            response.students.Add(student);
        }

        responses.Add(response);
    }

    return JsonSerializer.Serialize(responses, new JsonSerializerOptions { WriteIndented = true });
}

string json = Program.Main();