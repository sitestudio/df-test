using System;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static string Main()
    {
        try
        {
            List<StudentInformationResponse> responses = new List<StudentInformationResponse>
            {
                new StudentInformationResponse
                {
                    Students = new List<Student>
                    {
                        new Student { EnrolmentId = 2957, EqId = "26b7de91-1134-482e-967f-26fb5b516fd2", ImageId = 15, FamilyName = "FamilyName0", GivenNames = "GivenName0", BirthDate = "2011-10-14", Age = "8", RollClass = "RollClass4", YearLevel = new YearLevel { Code = "YL10", Description = "Year Level 12" }, EnrolmentStatus = new EnrolmentStatus { Code = "ES1", Description = "Enrolment Status 3" }, Gender = new Gender { Code = "F", Description = "Female" }, HasAbsentNote = false, Absences = new List<object>() },
                        new Student { EnrolmentId = 1553, EqId = "c477fd9c-c825-41e5-97ed-1018d203783b", ImageId = 2, FamilyName = "FamilyName1", GivenNames = "GivenName1", BirthDate = "2011-10-14", Age = "8", RollClass = "RollClass4", YearLevel = new YearLevel { Code = "YL4", Description = "Year Level 4" }, EnrolmentStatus = new EnrolmentStatus { Code = "ES1", Description = "Enrolment Status 3" }, Gender = new Gender { Code = "F", Description = "Male" }, HasAbsentNote = true, Absences = new List<object>() },
                    }
                },
                new StudentInformationResponse
                {
                    Students = new List<Student>
                    {
                        new Student { EnrolmentId = 8622, EqId = "d9d744eb-ef12-430e-aef1-fcaeab708005", ImageId = 78, FamilyName = "FamilyName0", GivenNames = "GivenName0", BirthDate = "2008-10-14", Age = "17", RollClass = "RollClass1", YearLevel = new YearLevel { Code = "YL11", Description = "Year Level 5" }, EnrolmentStatus = new EnrolmentStatus { Code = "ES2", Description = "Enrolment Status 1" }, Gender = new Gender { Code = "M", Description = "Female" }, HasAbsentNote = true, Absences = new List<object>() },
                        // More students can be added here as needed
                    }
                },
                new StudentInformationResponse
                {
                    Students = new List<Student>
                    {
                        new Student { EnrolmentId = 1539, EqId = "7b762043-7e07-4fab-81ed-d46b11cfbb34", ImageId = 28, FamilyName = "FamilyName0", GivenNames = "GivenName0", BirthDate = "2012-10-14", Age = "6", RollClass = "RollClass1", YearLevel = new YearLevel { Code = "YL2", Description = "Year Level 8" }, EnrolmentStatus = new EnrolmentStatus { Code = "ES3", Description = "Enrolment Status 2" }, Gender = new Gender { Code = "M", Description = "Male" }, HasAbsentNote = true, Absences = new List<object>() },
                        new Student { EnrolmentId = 3989, EqId = "7ba38699-0486-48fe-8316-b32c198b876c", ImageId = 90, FamilyName = "FamilyName1", GivenNames = "GivenName1", BirthDate = "2016-10-14", Age = "11", RollClass = "RollClass2", YearLevel = new YearLevel { Code = "YL3", Description = "Year Level 6" }, EnrolmentStatus = new EnrolmentStatus { Code = "ES1", Description = "Enrolment Status 1" }, Gender = new Gender { Code = "M", Description = "Male" }, HasAbsentNote = false, Absences = new List<object>() },
                        // More students can be added here as needed
                    }
                },
                new StudentInformationResponse
                {
                    Students = new List<Student>
                    {
                        new Student { EnrolmentId = 4251, EqId = "c6758672-3834-491e-b5ee-9dfbea179e17", ImageId = 49, FamilyName = "FamilyName0", GivenNames = "GivenName0", BirthDate = "2020-10-14", Age = "13", RollClass = "RollClass2", YearLevel = new YearLevel { Code = "YL1", Description = "Year Level 10" }, EnrolmentStatus = new EnrolmentStatus { Code = "ES2", Description = "Enrolment Status 2" }, Gender = new Gender { Code = "F", Description = "Female" }, HasAbsentNote = false, Absences = new List<object>() },
                    }
                },
                new StudentInformationResponse
                {
                    Students = new List<Student>
                    {
                        new Student { EnrolmentId = 3093, EqId = "a9146f6c-f049-448c-94be-42be3c589f84", ImageId = 86, FamilyName = "FamilyName0", GivenNames = "GivenName0", BirthDate = "2009-10-14", Age = "15", RollClass = "RollClass4", YearLevel = new YearLevel { Code = "YL6", Description = "Year Level 10" }, EnrolmentStatus = new EnrolmentStatus { Code = "ES1", Description = "Enrolment Status 3" }, Gender = new Gender { Code = "F", Description = "Female" }, HasAbsentNote = false, Absences = new List<object>() },
                    }
                }
            };

            string jsonString = JsonSerializer.Serialize(responses, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(jsonString);
            return "Success";
        }
        catch (Exception ex)
        {
            return "Failed: " + ex.Message;
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
        public int ImageId { get; set; }
        public string FamilyName { get; set; }
        public string GivenNames { get; set; }
        public string BirthDate { get; set; }  // DateTime as string
        public string Age { get; set; }
        public string RollClass { get; set; }
        public YearLevel YearLevel { get; set; }
        public EnrolmentStatus EnrolmentStatus { get; set; }
        public Gender Gender { get; set; }
        public bool HasAbsentNote { get; set; }
        public List<object> Absences { get; set; }
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
}
string json = Program.Main();