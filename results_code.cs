using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Student
{
    public int EnrolmentId { get; set; }
    public string EqId { get; set; } // GUID as a string
    public string FamilyName { get; set; }
    public string GivenNames { get; set; }
    public DateTime BirthDate { get; set; }
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
    public DateTime AbsenceDate { get; set; }
    public AbsenceReason AbsenceReason { get; set; }
    public PartOfDayAbsence PartOfDayAbsence { get; set; }
    public string Note { get; set; }
    public DateTime ModifiedDate { get; set; }
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

public class Program
{
    public static string Main()
    {
        string jsonFilePath = "path_to_your_json_file_here"; // Replace with actual file path
        try
        {
            string jsonData = File.ReadAllText(jsonFilePath);
            List<Student> students = JsonSerializer.Deserialize<List<Student>>(jsonData);
            
            foreach (var student in students)
            {
                if (!Guid.TryParse(student.EqId, out _))
                {
                    return $"Failed: eqId '{student.EqId}' is not a valid GUID.";
                }

                if (!student.FamilyName.StartsWith("Family"))
                {
                    return $"Failed: FamilyName '{student.FamilyName}' does not start with 'Family'.";
                }
            }

            return "Success";
        }
        catch (JsonException ex)
        {
            return $"Failed: JSON deserialization error - {ex.Message}";
        }
        catch (Exception ex)
        {
            return $"Failed: {ex.Message}";
        }
    }
}

// Usage
string json = Program.Main();