using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class Program
{
    public static async Task<string> Main()
    {
        string url = "https://raw.githubusercontent.com/sitestudio/df-test/refs/heads/main/results_response.json";
        using HttpClient client = new HttpClient();
        string json = await client.GetStringAsync(url);

        try
        {
            var studentInformationResponse = JsonSerializer.Deserialize<StudentInformationResponse>(json);

            foreach (var student in studentInformationResponse.Students)
            {
                if (!Guid.TryParse(student.EqId, out _))
                    return $"Failed: eqId '{student.EqId}' is not a valid GUID.";

                if (!student.FamilyName.StartsWith("Family"))
                    return $"Failed: familyName '{student.FamilyName}' does not start with 'Family'.";
            }

            return "Success";
        }
        catch (JsonException ex)
        {
            return $"Failed: JSON deserialization error - {ex.Message}";
        }
    }
}

public class StudentInformationResponse
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

// At the end of the code.
string json = await Program.Main();