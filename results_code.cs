using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

public class Program
{
    public static string Main()
    {
        string json = "[{"students":[{"enrolmentId":2957,"eqId":"26b7de91-1134-482e-967f-26fb5b516fd2","imageId":15,"familyName":"FamilyName0","givenNames":"GivenName0","birthDate":"2011-10-14","age":"8","rollClass":"RollClass4","yearLevel":{"code":"YL10","description":"Year Level 12"},"enrolmentStatus":{"code":"ES1","description":"Enrolment Status"},"gender":{"code":"G1","description":"Male"},"hasAbsentNote":false,"absences":[]}]}]";
        
        try
        {
            var response = JsonSerializer.Deserialize<List<StudentsResponse>>(json);
            foreach (var studentResponse in response)
            {
                foreach (var student in studentResponse.students)
                {
                    if (!Guid.TryParse(student.eqId, out _))
                    {
                        return $"Failed: eqId is not a valid GUID for student {student.enrolmentId}.";
                    }

                    if (!student.familyName.StartsWith("Family"))
                    {
                        return $"Failed: familyName '{student.familyName}' does not start with 'Family' for student {student.enrolmentId}.";
                    }
                }
            }
        }
        catch (JsonException ex)
        {
            return $"Failed: JSON deserialization error: {ex.Message}";
        }
        return "Success";
    }
}

public class StudentsResponse
{
    public List<Student> students { get; set; }
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
    public DateTime absenceDate { get; set; }
    public AbsenceReason absenceReason { get; set; }
    public PartOfDayAbsence partOfDayAbsence { get; set; }
    public string lateEarlyTime { get; set; }
    public string note { get; set; }
    public DateTime modifiedDate { get; set; }
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