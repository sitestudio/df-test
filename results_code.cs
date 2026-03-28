using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Program
{
    public class StudentInformationResponse
    {
        public int AttendanceId { get; set; }
        public int Version { get; set; }
        public bool IsRollMarkable { get; set; }
        public NotRollMarkableReason NotRollMarkableReason { get; set; }
        public bool IsRollMarked { get; set; }
        public DateTime? RollMarkedDate { get; set; }
        public string RollMarkedUser { get; set; }
        public List<Student> Students { get; set; }
    }

    public class NotRollMarkableReason
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class Student
    {
        public int EnrolmentId { get; set; }
        public AttendanceStatus AttendanceStatus { get; set; }
        public bool HasAttendanceChanges { get; set; }
        public bool HasAbsentNote { get; set; }
        public string EqId { get; set; }
        public int? ImageId { get; set; }
        public string FamilyName { get; set; }
        public string GivenNames { get; set; }
        public DateTime BirthDate { get; set; }
        public string Age { get; set; }
        public string RollClass { get; set; }
        public YearLevel YearLevel { get; set; }
        public EnrolmentStatus EnrolmentStatus { get; set; }
        public Gender Gender { get; set; }
        public List<Absence> Absences { get; set; }
    }

    public class AttendanceStatus
    {
        public string Code { get; set; }
        public string Description { get; set; }
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
        public string LateEarlyTime { get; set; }
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

    public static async Task<string> Main()
    {
        try
        {
            string jsonFilePath = "https://raw.githubusercontent.com/sitestudio/df-test/refs/heads/main/results_response.json";
            var json = await new HttpClient().GetStringAsync(jsonFilePath);
            var studentInformationResponse = JsonSerializer.Deserialize<List<StudentInformationResponse>>(json);

            foreach (var response in studentInformationResponse)
            {
                foreach (var student in response.Students)
                {
                    // Check if eqId is a valid GUID
                    if (!Guid.TryParse(student.EqId, out _))
                    {
                        return $"Failed: eqId '{student.EqId}' is not a valid GUID.";
                    }

                    // Check if FamilyName starts with "Family"
                    if (!student.FamilyName.StartsWith("Family", StringComparison.OrdinalIgnoreCase))
                    {
                        return $"Failed: FamilyName '{student.FamilyName}' does not start with 'Family'.";
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

string json = Program.Main();