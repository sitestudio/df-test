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
            // Read JSON data from the file.
            string json = File.ReadAllText("results_response.json");
            var response = JsonSerializer.Deserialize<StudentsResponse>(json);

            // Check if the data meets the specified criteria.
            if (response.Students.Any(student => !IsValidEqId(student.EqId) || !IsValidFamilyName(student.FamilyName)))
            {
                return "Failed: Some records do not match the specified criteria.";
            }

            return "Success";
        }
        catch (Exception ex)
        {
            return $"Failed: {ex.Message}";
        }
    }

    private static bool IsValidEqId(string eqId)
    {
        return Guid.TryParse(eqId, out _);
    }

    private static bool IsValidFamilyName(string familyName)
    {
        return familyName.StartsWith("Family", StringComparison.Ordinal);
    }
}

public class StudentsResponse
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

string json = Program.Main();