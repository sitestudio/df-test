using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Program
{
    public static string Main()
    {
        try
        {
            // Load the JSON data
            string json = File.ReadAllText("results_response.json");
            var response = JsonSerializer.Deserialize<StudentsResponse>(json);

            // Validate each student
            foreach (var student in response.students)
            {
                // Validate eqId
                if (!Guid.TryParse(student.eqId, out _))
                {
                    return $"Failed: eqId is not a valid GUID for student with enrolmentId {student.enrolmentId}.";
                }

                // Validate familyName
                if (!student.familyName.StartsWith("Family"))
                {
                    return $"Failed: familyName '{student.familyName}' does not start with 'Family' for enrolmentId {student.enrolmentId}.";
                }
            }
            
            return "Success";
        }
        catch (Exception ex)
        {
            return $"Failed: {ex.Message}";
        }
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

// This line is for executing the main method.
string json = Program.Main();