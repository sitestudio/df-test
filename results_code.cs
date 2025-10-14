using System;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static string Main()
    {
        var random = new Random();
        var compositeResponse = new CompositeStudentInformationResponse
        {
            session = "2023-2024",
            isRollMarkable = true,
            notRollMarkableReason = null,
            isRollMarked = false,
            rollMarkedDate = null,
            rollMarkedUser = null,
            timetableClassIds = "classId123",
            classes = new List<ClassInfo> { GenerateClassInfo(random) },
            students = new List<StudentInfo>()
        };

        var studentsResponse = new StudentsResponse
        {
            students = new List<StudentDetail>()
        };

        int numberOfStudentsInComposite = random.Next(10, 30); // Random number of students
        for (int i = 0; i < numberOfStudentsInComposite; i++)
        {
            var student = GenerateStudentInfo(random, i);
            compositeResponse.students.Add(student);
            studentsResponse.students.Add(new StudentDetail
            {
                enrolmentId = student.enrolmentId,
                eqId = student.eqId,
                imageId = student.imageId,
                familyName = student.familyName,
                givenNames = student.givenNames,
                birthDate = student.birthDate,
                age = CalculateAge(student.birthDate),
                rollClass = student.rollClass,
                yearLevel = student.yearLevel,
                enrolmentStatus = student.enrolmentStatus,
                gender = student.gender,
                hasAbsentNote = student.hasAbsentNote,
                absences = student.absences
            });
        }

        string compositeJson = JsonSerializer.Serialize(compositeResponse, new JsonSerializerOptions { WriteIndented = true });
        string studentsJson = JsonSerializer.Serialize(studentsResponse, new JsonSerializerOptions { WriteIndented = true });

        return compositeJson + "\
\
" + studentsJson; // Combine both JSON strings
    }

    private static ClassInfo GenerateClassInfo(Random random)
    {
        return new ClassInfo
        {
            attendanceId = random.Next(1, 1000),
            version = random.Next(1, 5),
            isRollMarkable = random.Next(0, 2) == 1,
            notRollMarkableReason = null,
            isRollMarked = random.Next(0, 2) == 1,
            rollMarkedDate = null,
            rollMarkedUser = null
        };
    }

    private static StudentInfo GenerateStudentInfo(Random random, int index)
    {
        int enrolmentId = random.Next(1, 1000);
        DateTime birthDate = DateTime.Now.AddYears(-18).AddDays(random.Next(0, 365)); // Random date for a student who is max 18
        return new StudentInfo
        {
            enrolmentId = enrolmentId,
            attendanceStatus = new AttendanceStatus { code = "A", description = "Absent" },
            hasAttendanceChanges = random.Next(0, 2) == 1,
            hasAbsentNote = random.Next(0, 2) == 1,
            eqId = "EQ" + index.ToString("D4"), // Unique eqId for each student
            imageId = null,
            familyName = "FamilyName" + index,
            givenNames = "GivenName" + index,
            birthDate = birthDate.ToString("yyyy-MM-dd"),
            rollClass = "Year 12",
            yearLevel = new YearLevel { code = "12", description = "Year 12" },
            enrolmentStatus = new EnrolmentStatus { code = "E", description = "Enrolled" },
            gender = new Gender { code = "M", description = "Male" },
            absences = new List<AbsenceInfo>()
        };
    }

    private static string CalculateAge(string birthDateString)
    {
        DateTime birthDate = DateTime.Parse(birthDateString);
        int age = DateTime.Now.Year - birthDate.Year;
        if (birthDate > DateTime.Now.AddYears(-age)) age--;
        return age.ToString();
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
    public List<ClassInfo> classes { get; set; }
    public List<StudentInfo> students { get; set; }
}

public class StudentsResponse
{
    public List<StudentDetail> students { get; set; }
}

public class ClassInfo
{
    public int? attendanceId { get; set; }
    public int? version { get; set; }
    public bool isRollMarkable { get; set; }
    public object notRollMarkableReason { get; set; }
    public bool? isRollMarked { get; set; }
    public string rollMarkedDate { get; set; }
    public string rollMarkedUser { get; set; }
}

public class StudentInfo
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
    public string rollClass { get; set; }
    public YearLevel yearLevel { get; set; }
    public EnrolmentStatus enrolmentStatus { get; set; }
    public Gender gender { get; set; }
    public List<AbsenceInfo> absences { get; set; }
}

public class StudentDetail
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
    public List<AbsenceInfo> absences { get; set; }
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

public class AbsenceInfo
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