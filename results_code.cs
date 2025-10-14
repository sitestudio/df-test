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
                notRollMarkableReason = null,
                isRollMarked = false,
                rollMarkedDate = null,
                rollMarkedUser = null,
                students = new List<Student>
                {
                    new Student { enrolmentId = 1, attendanceStatus = new AttendanceStatus { code = "P", description = "Present" }, hasAttendanceChanges = false, hasAbsentNote = false, eqId = "E123", imageId = null, familyName = "Smith", givenNames = "John", birthDate = "2005-05-01T00:00:00Z", age = "18", rollClass = "10A", yearLevel = new YearLevel { code = "10", description = "Tenth Grade" }, enrolmentStatus = new EnrolmentStatus { code = "Enrolled", description = "Currently Enrolled" }, gender = new Gender { code = "M", description = "Male" }, absences = new List<Absence>() },
                }
            },
            new StudentInformationResponse
            {
                attendanceId = 2,
                version = 1,
                isRollMarkable = true,
                notRollMarkableReason = null,
                isRollMarked = true,
                rollMarkedDate = "2023-10-01T10:00:00Z",
                rollMarkedUser = "admin",
                students = new List<Student>
                {
                    new Student { enrolmentId = 2, attendanceStatus = new AttendanceStatus { code = "A", description = "Absent" }, hasAttendanceChanges = true, hasAbsentNote = true, eqId = "E124", imageId = 1001, familyName = "Johnson", givenNames = "Emily", birthDate = "2004-06-15T00:00:00Z", age = "19", rollClass = "11B", yearLevel = new YearLevel { code = "11", description = "Eleventh Grade" }, enrolmentStatus = new EnrolmentStatus { code = "Pending", description = "Pending Enrollment" }, gender = new Gender { code = "F", description = "Female" }, absences = new List<Absence>
                    {
                        new Absence { studentAbsenceId = 1, enrolmentId = 2, absenceDate = "2023-09-30T00:00:00Z", absenceReason = new AbsenceReason { code = "S", description = "Sick" }, partOfDayAbsence = new PartOfDayAbsence { code = "Full", description = "Full Day" }, lateEarlyTime = null, note = "Doctor's appointment", modifiedDate = "2023-10-01T00:00:00Z", modifiedBy = "admin" }
                    }
                    }
                }
            },
            new StudentInformationResponse
            {
                attendanceId = 3,
                version = 1,
                isRollMarkable = false,
                notRollMarkableReason = new NotRollMarkableReason { code = "H", description = "Holiday" },
                isRollMarked = true,
                rollMarkedDate = "2023-10-02T12:00:00Z",
                rollMarkedUser = "teacher",
                students = new List<Student>
                {
                    new Student { enrolmentId = 3, attendanceStatus = new AttendanceStatus { code = "P", description = "Present" }, hasAttendanceChanges = false, hasAbsentNote = false, eqId = "E125", imageId = null, familyName = "Williams", givenNames = "Michael", birthDate = "2004-08-21T00:00:00Z", age = "19", rollClass = "12C", yearLevel = new YearLevel { code = "12", description = "Twelfth Grade" }, enrolmentStatus = new EnrolmentStatus { code = "Graduated", description = "Graduated" }, gender = new Gender { code = "M", description = "Male" }, absences = new List<Absence>() },
                    new Student { enrolmentId = 4, attendanceStatus = new AttendanceStatus { code = "A", description = "Absent" }, hasAttendanceChanges = true, hasAbsentNote = true, eqId = "E126", imageId = null, familyName = "Brown", givenNames = "Sarah", birthDate = "2005-04-15T00:00:00Z", age = "18", rollClass = "12C", yearLevel = new YearLevel { code = "12", description = "Twelfth Grade" }, enrolmentStatus = new EnrolmentStatus { code = "Graduated", description = "Graduated" }, gender = new Gender { code = "F", description = "Female" }, absences = new List<Absence>() }
                }
            },
            new StudentInformationResponse
            {
                attendanceId = 4,
                version = 1,
                isRollMarkable = true,
                notRollMarkableReason = null,
                isRollMarked = false,
                rollMarkedDate = null,
                rollMarkedUser = null,
                students = new List<Student>
                {
                    new Student { enrolmentId = 5, attendanceStatus = new AttendanceStatus { code = "P", description = "Present" }, hasAttendanceChanges = false, hasAbsentNote = false, eqId = "E127", imageId = null, familyName = "Davis", givenNames = "David", birthDate = "2005-02-28T00:00:00Z", age = "18", rollClass = "10A", yearLevel = new YearLevel { code = "10", description = "Tenth Grade" }, enrolmentStatus = new EnrolmentStatus { code = "Enrolled", description = "Currently Enrolled" }, gender = new Gender { code = "M", description = "Male" }, absences = new List<Absence>() },
                    new Student { enrolmentId = 6, attendanceStatus = new AttendanceStatus { code = "A", description = "Absent" }, hasAttendanceChanges = true, hasAbsentNote = true, eqId = "E128", imageId = null, familyName = "Martinez", givenNames = "Ana", birthDate = "2004-11-29T00:00:00Z", age = "19", rollClass = "10A", yearLevel = new YearLevel { code = "10", description = "Tenth Grade" }, enrolmentStatus = new EnrolmentStatus { code = "Enrolled", description = "Currently Enrolled" }, gender = new Gender { code = "F", description = "Female" }, absences = new List<Absence>() }
                }
            },
            new StudentInformationResponse
            {
                attendanceId = 5,
                version = 1,
                isRollMarkable = true,
                notRollMarkableReason = null,
                isRollMarked = false,
                rollMarkedDate = null,
                rollMarkedUser = null,
                students = new List<Student>
                {
                    new Student { enrolmentId = 7, attendanceStatus = new AttendanceStatus { code = "P", description = "Present" }, hasAttendanceChanges = false, hasAbsentNote = false, eqId = "E129", imageId = null, familyName = "Garcia", givenNames = "Carlos", birthDate = "2006-01-01T00:00:00Z", age = "17", rollClass = "9B", yearLevel = new YearLevel { code = "9", description = "Ninth Grade" }, enrolmentStatus = new EnrolmentStatus { code = "Enrolled", description = "Currently Enrolled" }, gender = new Gender { code = "M", description = "Male" }, absences = new List<Absence>() },
                    new Student { enrolmentId = 8, attendanceStatus = new AttendanceStatus { code = "P", description = "Present" }, hasAttendanceChanges = false, hasAbsentNote = false, eqId = "E130", imageId = null, familyName = "Lee", givenNames = "Soo", birthDate = "2005-03-12T00:00:00Z", age = "18", rollClass = "9B", yearLevel = new YearLevel { code = "9", description = "Ninth Grade" }, enrolmentStatus = new EnrolmentStatus { code = "Enrolled", description = "Currently Enrolled" }, gender = new Gender { code = "F", description = "Female" }, absences = new List<Absence>() },
                    new Student { enrolmentId = 9, attendanceStatus = new AttendanceStatus { code = "A", description = "Absent" }, hasAttendanceChanges = true, hasAbsentNote = true, eqId = "E131", imageId = null, familyName = "Kim", givenNames = "Jin", birthDate = "2006-05-22T00:00:00Z", age = "17", rollClass = "9B", yearLevel = new YearLevel { code = "9", description = "Ninth Grade" }, enrolmentStatus = new EnrolmentStatus { code = "Enrolled", description = "Currently Enrolled" }, gender = new Gender { code = "M", description = "Male" }, absences = new List<Absence>() }
                }
            },
        };

        return JsonSerializer.Serialize(sampleData, new JsonSerializerOptions { WriteIndented = true });
    }
}

string json = Program.Main();