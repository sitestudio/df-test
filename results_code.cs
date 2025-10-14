using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Program
{
    public static async Task<string> Main()
    {
        string url = "https://raw.githubusercontent.com/sitestudio/df-test/refs/heads/main/results_response.json";
        
        // Fetch the JSON from the URL
        using HttpClient client = new HttpClient();
        string json = await client.GetStringAsync(url);

        // Deserialize into the StudentInformationResponse
        StudentInformationResponse response;
        try
        {
            response = JsonSerializer.Deserialize<StudentInformationResponse>(json);
        }
        catch (JsonException ex)
        {
            return $"Failed to deserialize JSON: {ex.Message}";
        }

        // Validate each student
        foreach (var student in response.students)
        {
            if (!Guid.TryParse(student.eqId, out _))
            {
                return $"Failed: eqId '{student.eqId}' is not a valid GUID.";
            }

            if (!student.familyName.StartsWith("Family", StringComparison.OrdinalIgnoreCase))
            {
                return $"Failed: familyName '{student.familyName}' does not start with 'Family'.";
            }
        }

        return "Success";
    }

    public class StudentInformationResponse
    {
        public List<Student> students { get; set; }
    }

    public class Student
    {
        public int enrolmentId { get; set; }
        public string eqId { get; set; }
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
        public object partOfDayAbsence { get; set; } // Assuming it’s an object based on the schema
        public string note { get; set; }
        public string modifiedDate { get; set; }
        public string modifiedBy { get; set; }
    }

    public class AbsenceReason
    {
        public string code { get; set; }
        public string description { get; set; }
    }
}

string json = Program.Main().GetAwaiter().GetResult();