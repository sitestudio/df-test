using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class Program
{
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

    public class StudentsResponse
    {
        public List<Student> students { get; set; }
    }

    public static async Task<string> Main()
    {
        try
        {
            using HttpClient client = new HttpClient();
            string url = "https://raw.githubusercontent.com/sitestudio/df-test/refs/heads/main/results_response.json";
            string json = await client.GetStringAsync(url);
            var response = JsonSerializer.Deserialize<StudentsResponse>(json);

            foreach(var student in response.students)
            {
                if (!Guid.TryParse(student.eqId, out _))
                {
                    return $"Failed: eqId {student.eqId} is not a valid GUID.";
                }

                if (!student.familyName.StartsWith("Family", StringComparison.OrdinalIgnoreCase))
                {
                    return $"Failed: familyName {student.familyName} does not start with 'Family'.";
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

string json = Program.Main();