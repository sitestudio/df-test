using System;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static string Main()
    {
        var random = new Random();
        var compositeStudentInformationResponse = new CompositeStudentInformationResponse
        {
            session = "2023",
            isRollMarkable = true,
            notRollMarkableReason = null,
            isRollMarked = false,
            rollMarkedDate = null,
            rollMarkedUser = null,
            timetableClassIds = "TID123",
            classes = new List<Class>
            {
                new Class
                {
                    attendanceId = random.Next(1, 100),
                    version = random.Next(1, 5),
                    isRollMarkable = true,
                    notRollMarkableReason = null,
                    isRollMarked = false,
                    rollMarkedDate = null,
                    rollMarkedUser = null
                }
            },
            students = new List<Student>()
        };

        var studentsResponse = new StudentsResponse
        {
            students = new List<StudentResponse>()
        };

        for (int i = 0; i < 5; i++)
        {
            string eqId = Guid.NewGuid().ToString();
            var studentBirthDate = DateTime.Now.AddYears(-random.Next(17, 18)).AddDays(random.Next(-365, 0)).ToString("yyyy-MM-dd");
            var student = new Student
            {
                session = "2023",
                timetableClassId = random.Next(1, 100),
                enrolmentId = random.Next(1, 1000),
                attendanceStatus = new AttendanceStatus
                {
                    code = "Present",
                    description = "Present"
                },
                hasAttendanceChanges = false,
                hasAbsentNote = false,
                eqId = eqId,
                imageId = null,
                familyName = "Family" + i,
                givenNames = "Given" + i,
                birthDate = studentBirthDate,
                age = "17",
                rollClass = "Year 12",
                yearLevel = new YearLevel
                {
                    code = "12",
                    description = "Year 12"
                },
                enrolmentStatus = new EnrolmentStatus
                {
                    code = "Active",
                    description = "Active"
                },
                gender = new Gender
                {
                    code = "M",
                    description = "Male"
                },
                absences = new List<Absence>()
            };

            compositeStudentInformationResponse.students.Add(student);
            studentsResponse.students.Add(new StudentResponse
            {
                enrolmentId = student.enrolmentId,
                eqId = eqId,
                imageId = null,
                familyName = student.familyName,
                givenNames = student.givenNames,
                birthDate = student.birthDate,
                age = student.age,
                rollClass = student.rollClass,
                yearLevel = student.yearLevel,
                enrolmentStatus = student.enrolmentStatus,
                gender = student.gender,
                hasAbsentNote = student.hasAbsentNote,
                absences = student.absences
            });
        }

        return JsonSerializer.Serialize(new { compositeStudentInformationResponse, studentsResponse }, new JsonSerializerOptions { WriteIndented = true });
    }
}

public class CompositeStudentInformationResponse
{
    public string session { get; set; }
    public bool isRollMarkable { get; set; }
    public object notRollMarkableReason { get; set; }
    public bool isRollMarked { get; set; }
    public string rollMarkedDate { get; set; }
    public string rollMarkedUser { get; set; }
    public string timetableClassIds { get; set; }
    public List<Class> classes { get; set; }
    public List<Student> students { get; set; }
}

public class Class
{
    public int attendanceId { get; set; }
    public int version { get; set; }
    public bool isRollMarkable { get; set; }
    public object notRollMarkableReason { get; set; }
    public bool? isRollMarked { get; set; }
    public string rollMarkedDate { get; set; }
    public string rollMarkedUser { get; set; }
}

public class Student
{
    public string session { get; set; }
    public int timetableClassId { get; set; }
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

public class StudentsResponse
{
    public List<StudentResponse> students { get; set; }
}

public class StudentResponse
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

public class Absence
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

string json = Program.Main();