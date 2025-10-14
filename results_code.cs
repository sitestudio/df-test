using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        var jsonFilePath = "https://raw.githubusercontent.com/sitestudio/df-test/refs/heads/main/results_response.json";
        using var httpClient = new HttpClient();
        var response = await httpClient.GetStringAsync(jsonFilePath);
        var studentInformationResponses = JsonSerializer.Deserialize<List<StudentInformationResponse>>(response);

        foreach (var studentResponse in studentInformationResponses)
        {
            if (studentResponse == null || studentResponse.students == null)
            {
                Console.WriteLine("Failed: StudentInformationResponse or students is null.");
                return;
            }
            
            foreach (var student in studentResponse.students)
            {
                // Check if eqId is a valid GUID
                if (!Guid.TryParse(student.eqId, out _))
                {
                    Console.WriteLine($"Failed: eqId '{student.eqId}' is not a valid GUID.");
                    return;
                }

                // Check if Family name starts with "Family"
                if (!student.familyName.StartsWith("Family", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Failed: Family name '{student.familyName}' does not start with 'Family'.");
                    return;
                }
            }
        }
        
        Console.WriteLine("Success");
    }

    public class StudentInformationResponse
    {
        public int? attendanceId { get; set; }
        public int version { get; set; }
        public bool isRollMarkable { get; set; }
        public object notRollMarkableReason { get; set; }
        public bool isRollMarked { get; set; }
        public DateTime? rollMarkedDate { get; set; }
        public string rollMarkedUser { get; set; }
        public List<Student> students { get; set; }
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
        public EnrollmentStatus enrolmentStatus { get; set; }
        public Gender gender { get; set; }
        public List<Absence> absences { get; set; }
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

    public class EnrollmentStatus
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
}

// Invoke the Main method
string json = await Program.Main();