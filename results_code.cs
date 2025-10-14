using System;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static string Main()
    {
        var sampleData = new List<StudentInformationResponse>
        {
            new StudentInformationResponse
            {
                attendanceId = 1,
                version = 1,
                isRollMarkable = true,
                notRollMarkableReason = new NotRollMarkableReason { code = "NV", description = "Not Valid" },
                isRollMarked = true,
                rollMarkedDate = "2023-10-01T10:00:00Z",
                rollMarkedUser = "teacher1",
                students = new List<Student>
                {
                    new Student { enrolmentId = 101, attendanceStatus = new AttendanceStatus { code = "P", description = "Present" }, hasAttendanceChanges = false, hasAbsentNote = false, eqId = "eq101", imageId = 1, familyName = "Smith", givenNames = "John", birthDate = "2010-01-01", age = "13", rollClass = "5A", yearLevel = new YearLevel { code = "5", description = "Year 5" }, enrolmentStatus = new EnrolmentStatus { code = "EN", description = "Enrolled" }, gender = new Gender { code = "M", description = "Male" }, absences = new List<Absence>() }
                }
            },
            new StudentInformationResponse
            {
                attendanceId = 2,
                version = 1,
                isRollMarkable = true,
                notRollMarkableReason = null,
                isRollMarked = false,
                rollMarkedDate = null,
                rollMarkedUser = null,
                students = new List<Student>
                {
                    new Student { enrolmentId = 102, attendanceStatus = new AttendanceStatus { code = "A", description = "Absent" }, hasAttendanceChanges = true, hasAbsentNote = true, eqId = "eq102", imageId = null, familyName = "Johnson", givenNames = "Alice", birthDate = "2009-05-23", age = "14", rollClass = "5B", yearLevel = new YearLevel { code = "5", description = "Year 5" }, enrolmentStatus = new EnrolmentStatus { code = "EN", description = "Enrolled" }, gender = new Gender { code = "F", description = "Female" }, absences = new List<Absence>() }
                }
            },
            new StudentInformationResponse
            {
                attendanceId = 3,
                version = 1,
                isRollMarkable = false,
                notRollMarkableReason = new NotRollMarkableReason { code = "PM", description = "Pending Mark" },
                isRollMarked = false,
                rollMarkedDate = null,
                rollMarkedUser = null,
                students = new List<Student>
                {
                    new Student { enrolmentId = 103, attendanceStatus = new AttendanceStatus { code = "P", description = "Present" }, hasAttendanceChanges = true, hasAbsentNote = false, eqId = "eq103", imageId = null, familyName = "Williams", givenNames = "Oliver", birthDate = "2011-09-12", age = "12", rollClass = "6A", yearLevel = new YearLevel { code = "6", description = "Year 6" }, enrolmentStatus = new EnrolmentStatus { code = "EN", description = "Enrolled" }, gender = new Gender { code = "M", description = "Male" }, absences = new List<Absence>() },
                    new Student { enrolmentId = 104, attendanceStatus = new AttendanceStatus { code = "A", description = "Absent" }, hasAttendanceChanges = false, hasAbsentNote = true, eqId = "eq104", imageId = null, familyName = "Jones", givenNames = "Emma", birthDate = "2010-04-08", age = "13", rollClass = "6B", yearLevel = new YearLevel { code = "6", description = "Year 6" }, enrolmentStatus = new EnrolmentStatus { code = "EN", description = "Enrolled" }, gender = new Gender { code = "F", description = "Female" }, absences = new List<Absence>() }
                }
            },
            new StudentInformationResponse
            {
                attendanceId = 4,
                version = 1,
                isRollMarkable = true,
                notRollMarkableReason = null,
                isRollMarked = true,
                rollMarkedDate = "2023-10-02T10:00:00Z",
                rollMarkedUser = "teacher2",
                students = new List<Student>
                {
                    new Student { enrolmentId = 105, attendanceStatus = new AttendanceStatus { code = "P", description = "Present" }, hasAttendanceChanges = false, hasAbsentNote = false, eqId = "eq105", imageId = null, familyName = "Brown", givenNames = "Liam", birthDate = "2010-11-11", age = "12", rollClass = "7A", yearLevel = new YearLevel { code = "7", description = "Year 7" }, enrolmentStatus = new EnrolmentStatus { code = "EN", description = "Enrolled" }, gender = new Gender { code = "M", description = "Male" }, absences = new List<Absence>() },
                    new Student { enrolmentId = 106, attendanceStatus = new AttendanceStatus { code = "A", description = "Absent" }, hasAttendanceChanges = false, hasAbsentNote = false, eqId = "eq106", imageId = 2, familyName = "Taylor", givenNames = "Mia", birthDate = "2009-10-10", age = "14", rollClass = "7B", yearLevel = new YearLevel { code = "7", description = "Year 7" }, enrolmentStatus = new EnrolmentStatus { code = "EN", description = "Enrolled" }, gender = new Gender { code = "F", description = "Female" }, absences = new List<Absence>() },
                    new Student { enrolmentId = 107, attendanceStatus = new AttendanceStatus { code = "P", description = "Present" }, hasAttendanceChanges = false, hasAbsentNote = true, eqId = "eq107", imageId = null, familyName = "Wilson", givenNames = "Sophia", birthDate = "2008-07-07", age = "15", rollClass = "7C", yearLevel = new YearLevel { code = "7", description = "Year 7" }, enrolmentStatus = new EnrolmentStatus { code = "EN", description = "Enrolled" }, gender = new Gender { code = "F", description = "Female" }, absences = new List<Absence>() }
                }
            },
            new StudentInformationResponse
            {
                attendanceId = 5,
                version = 1,
                isRollMarkable = true,
                notRollMarkableReason = null,
                isRollMarked = true,
                rollMarkedDate = "2023-10-03T10:00:00Z",
                rollMarkedUser = "teacher3",
                students = new List<Student>
                {
                    new Student { enrolmentId = 108, attendanceStatus = new AttendanceStatus { code = "P", description = "Present" }, hasAttendanceChanges = false, hasAbsentNote = false, eqId = "eq108", imageId = 3, familyName = "White", givenNames = "James", birthDate = "2011-02-02", age = "12", rollClass = "8A", yearLevel = new YearLevel { code = "8", description = "Year 8" }, enrolmentStatus = new EnrolmentStatus { code = "EN", description = "Enrolled" }, gender = new Gender { code = "M", description = "Male" }, absences = new List<Absence>() },
                    new Student { enrolmentId = 109, attendanceStatus = new AttendanceStatus { code = "A", description = "Absent" }, hasAttendanceChanges = false, hasAbsentNote = false, eqId = "eq109", imageId = null, familyName = "Harris", givenNames = "Charlotte", birthDate = "2010-03-21", age = "13", rollClass = "8B", yearLevel = new YearLevel { code = "8", description = "Year 8" }, enrolmentStatus = new EnrolmentStatus { code = "EN", description = "Enrolled" }, gender = new Gender { code = "F", description = "Female" }, absences = new List<Absence>() }
                }
            }
        };

        return JsonSerializer.Serialize(sampleData, new JsonSerializerOptions { WriteIndented = true });
    }
}

string json = Program.Main();