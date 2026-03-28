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
    public string absenceDate { get; set; }
    public AbsenceReason absenceReason { get; set; }
    public PartOfDayAbsence partOfDayAbsence { get; set; }
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

public static string Main()
{
    var response = new StudentInformationResponse
    {
        students = new List<Student>
        {
            new Student
            {
                enrolmentId = 1,
                eqId = "EQ001",
                imageId = null,
                familyName = "Smith",
                givenNames = "John",
                birthDate = "2005-03-15T00:00:00Z",
                age = "16",
                rollClass = "10A",
                yearLevel = new YearLevel { code = "10", description = "Year 10" },
                enrolmentStatus = new EnrolmentStatus { code = "active", description = "Active" },
                gender = new Gender { code = "M", description = "Male" },
                hasAbsentNote = false,
                absences = new List<Absence>()
            },
            new Student
            {
                enrolmentId = 2,
                eqId = "EQ002",
                imageId = null,
                familyName = "Johnson",
                givenNames = "Emily",
                birthDate = "2006-05-22T00:00:00Z",
                age = "15",
                rollClass = "10B",
                yearLevel = new YearLevel { code = "10", description = "Year 10" },
                enrolmentStatus = new EnrolmentStatus { code = "active", description = "Active" },
                gender = new Gender { code = "F", description = "Female" },
                hasAbsentNote = true,
                absences = new List<Absence>
                {
                    new Absence
                    {
                        studentAbsenceId = 1,
                        enrolmentId = 2,
                        absenceDate = "2021-10-04T00:00:00Z",
                        absenceReason = new AbsenceReason { code = "sick", description = "Sick" },
                        partOfDayAbsence = null,
                        note = "Flu",
                        modifiedDate = "2021-10-04T12:00:00Z",
                        modifiedBy = "teacher01"
                    }
                }
            },
            new Student
            {
                enrolmentId = 3,
                eqId = "EQ003",
                imageId = null,
                familyName = "Williams",
                givenNames = "Mike",
                birthDate = "2004-07-12T00:00:00Z",
                age = "17",
                rollClass = "11A",
                yearLevel = new YearLevel { code = "11", description = "Year 11" },
                enrolmentStatus = new EnrolmentStatus { code = "inactive", description = "Inactive" },
                gender = new Gender { code = "M", description = "Male" },
                hasAbsentNote = false,
                absences = new List<Absence>()
            },
            new Student
            {
                enrolmentId = 4,
                eqId = "EQ004",
                imageId = null,
                familyName = "Brown",
                givenNames = "Alice",
                birthDate = "2006-01-30T00:00:00Z",
                age = "15",
                rollClass = "10C",
                yearLevel = new YearLevel { code = "10", description = "Year 10" },
                enrolmentStatus = new EnrolmentStatus { code = "active", description = "Active" },
                gender = new Gender { code = "F", description = "Female" },
                hasAbsentNote = false,
                absences = new List<Absence>()
            },
            new Student
            {
                enrolmentId = 5,
                eqId = "EQ005",
                imageId = null,
                familyName = "Garcia",
                givenNames = "Luis",
                birthDate = "2003-11-18T00:00:00Z",
                age = "18",
                rollClass = "12A",
                yearLevel = new YearLevel { code = "12", description = "Year 12" },
                enrolmentStatus = new EnrolmentStatus { code = "active", description = "Active" },
                gender = new Gender { code = "M", description = "Male" },
                hasAbsentNote = true,
                absences = new List<Absence>
                {
                    new Absence
                    {
                        studentAbsenceId = 2,
                        enrolmentId = 5,
                        absenceDate = "2021-10-01T00:00:00Z",
                        absenceReason = new AbsenceReason { code = "vacation", description = "Vacation" },
                        partOfDayAbsence = null,
                        note = "Family trip",
                        modifiedDate = "2021-10-01T12:00:00Z",
                        modifiedBy = "teacher02"
                    }
                }
            }
        }
    };

    return JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true });
}
string json = Program.Main();