using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class Program
{
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

    public class Student
    {
        public int enrolmentId { get; set; }
        public AttendanceStatus attendanceStatus { get; set; }
        public bool hasAttendanceChanges { get; set; }
        public bool hasAbsentNote { get; set; }
        public string eqId { get; set; }
        public int? imageId { get; set; }
        public string familyName { get; set; }
        public string givenNames { get; set; }
        public DateTime birthDate { get; set; }
        public string age { get; set; }
        public string rollClass { get; set; }
        public YearLevel yearLevel { get; set; }
        public object enrolmentStatus { get; set; }
        public object gender { get; set; }
        public List<object> absences { get; set; }
    }

    public class StudentInformationResponse
    {
        public List<Student> students { get; set; }
    }

    public static async Task<string> Main()
    {
        try
        {
            string url = "https://raw.githubusercontent.com/sitestudio/df-test/refs/heads/main/results_response.json";
            using HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(url);
            var studentInformationResponse = JsonSerializer.Deserialize<List<StudentInformationResponse>>(response);

            foreach (var studentInfo in studentInformationResponse)
            {
                foreach (var student in studentInfo.students)
                {
                    // Check if eqId is a GUID
                    if (!Guid.TryParse(student.eqId, out _))
                    {
                        return $"Failed: eqId '{student.eqId}' is not a valid GUID.";
                    }

                    // Check if Family name starts with "Family"
                    if (student.familyName == null || !student.familyName.StartsWith("Family"))
                    {
                        return $"Failed: Family name '{student.familyName}' does not start with 'Family'.";
                    }
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

string json = await Program.Main();