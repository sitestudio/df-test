using System;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static string Main()
    {
        var studentInformationResponses = new List<StudentInformationResponse>
        {
            new StudentInformationResponse
            {
                Students = new List<Student>
                {
                    new Student { enrolmentId = 2957, eqId = "26b7de91-1134-482e-967f-26fb5b516fd2", imageId = 15, familyName = "Doe", givenNames = "John", birthDate = "2011-10-14", age = "8", rollClass = "RollClass4", yearLevel = new YearLevel { code = "YL10", description = "Year Level 12" }, enrolmentStatus = new EnrolmentStatus { code = "ES1", description = "Enrolled" }, gender = new Gender { code = "F", description = "Female" }, hasAbsentNote = false, absences = new List<Absence>() },
                    new Student { enrolmentId = 1553, eqId = "c477fd9c-c825-41e5-97ed-1018d203783b", imageId = 2, familyName = "Doe", givenNames = "Jane", birthDate = "2010-10-14", age = "9", rollClass = "RollClass2", yearLevel = new YearLevel { code = "YL4", description = "Year Level 4" }, enrolmentStatus = new EnrolmentStatus { code = "ES1", description = "Enrolled" }, gender = new Gender { code = "M", description = "Male" }, hasAbsentNote = true, absences = new List<Absence>() }
                }
            },
            new StudentInformationResponse
            {
                Students = new List<Student>
                {
                    new Student { enrolmentId = 8622, eqId = "d9d744eb-ef12-430e-aef1-fcaeab708005", imageId = 78, familyName = "Smith", givenNames = "Alex", birthDate = "2008-10-14", age = "15", rollClass = "RollClass1", yearLevel = new YearLevel { code = "YL11", description = "Year Level 5" }, enrolmentStatus = new EnrolmentStatus { code = "ES2", description = "Enrolled" }, gender = new Gender { code = "M", description = "Male" }, hasAbsentNote = true, absences = new List<Absence>() },
                    new Student { enrolmentId = 7753, eqId = "2c200fb8-26ec-4660-8330-253cd82481bd", imageId = 12, familyName = "Brown", givenNames = "Emily", birthDate = "2017-10-14", age = "6", rollClass = "RollClass3", yearLevel = new YearLevel { code = "YL7", description = "Year Level 1" }, enrolmentStatus = new EnrolmentStatus { code = "ES3", description = "Enrolled" }, gender = new Gender { code = "F", description = "Female" }, hasAbsentNote = true, absences = new List<Absence>() }
                }
            },
            new StudentInformationResponse
            {
                Students = new List<Student>
                {
                    new Student { enrolmentId = 1539, eqId = "7b762043-7e07-4fab-81ed-d46b11cfbb34", imageId = 28, familyName = "Johnson", givenNames = "Michael", birthDate = "2012-10-14", age = "6", rollClass = "RollClass1", yearLevel = new YearLevel { code = "YL2", description = "Year Level 8" }, enrolmentStatus = new EnrolmentStatus { code = "ES1", description = "Enrolled" }, gender = new Gender { code = "M", description = "Male" }, hasAbsentNote = false, absences = new List<Absence>() },
                    new Student { enrolmentId = 3989, eqId = "7ba38699-0486-48fe-8316-b32c198b876c", imageId = 90, familyName = "Williams", givenNames = "Sarah", birthDate = "2016-10-14", age = "11", rollClass = "RollClass2", yearLevel = new YearLevel { code = "YL3", description = "Year Level 6" }, enrolmentStatus = new EnrolmentStatus { code = "ES1", description = "Enrolled" }, gender = new Gender { code = "M", description = "Male" }, hasAbsentNote = true, absences = new List<Absence>() }
                }
            },
            new StudentInformationResponse
            {
                Students = new List<Student>
                {
                    new Student { enrolmentId = 4251, eqId = "c6758672-3834-491e-b5ee-9dfbea179e17", imageId = 49, familyName = "Davis", givenNames = "Jessica", birthDate = "2015-10-14", age = "8", rollClass = "RollClass2", yearLevel = new YearLevel { code = "YL1", description = "Year Level 10" }, enrolmentStatus = new EnrolmentStatus { code = "ES2", description = "Enrolled" }, gender = new Gender { code = "F", description = "Female" }, hasAbsentNote = false, absences = new List<Absence>() },
                    new Student { enrolmentId = 7396, eqId = "57614115-e042-41d0-9cab-fb0add8c07c0", imageId = 72, familyName = "Miller", givenNames = "Chris", birthDate = "2012-10-14", age = "11", rollClass = "RollClass2", yearLevel = new YearLevel { code = "YL2", description = "Year Level 2" }, enrolmentStatus = new EnrolmentStatus { code = "ES3", description = "Enrolled" }, gender = new Gender { code = "M", description = "Male" }, hasAbsentNote = false, absences = new List<Absence>() }
                }
            },
            new StudentInformationResponse
            {
                Students = new List<Student>
                {
                    new Student { enrolmentId = 3093, eqId = "a9146f6c-f049-448c-94be-42be3c589f84", imageId = 86, familyName = "Anderson", givenNames = "David", birthDate = "2009-10-14", age = "15", rollClass = "RollClass4", yearLevel = new YearLevel { code = "YL6", description = "Year Level 10" }, enrolmentStatus = new EnrolmentStatus { code = "ES1", description = "Enrolled" }, gender = new Gender { code = "F", description = "Female" }, hasAbsentNote = false, absences = new List<Absence>() }
                }
            }
        };

        string json = JsonSerializer.Serialize(studentInformationResponses, new JsonSerializerOptions { WriteIndented = true });
        return json;
    }
}

string json = Program.Main();