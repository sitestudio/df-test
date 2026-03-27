using System;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static string Main()
    {
        var studentRecords = new List<StudentsResponse>
        {
            new StudentsResponse
            {
                students = new List<Student>
                {
                    new Student { enrolmentId = 1, eqId = "EQ001", imageId = 101, familyName = "Smith", givenNames = "John", birthDate = "2005-07-10", age = "16", rollClass = "10A", yearLevel = new YearLevel { code = "10", description = "Year 10" }, enrolmentStatus = new EnrolmentStatus { code = "ENR", description = "Enrolled" }, gender = new Gender { code = "M", description = "Male" }, hasAbsentNote = false, absences = new List<Absence>() }
                }
            },
            new StudentsResponse
            {
                students = new List<Student>
                {
                    new Student { enrolmentId = 2, eqId = "EQ002", imageId = 102, familyName = "Johnson", givenNames = "Emily", birthDate = "2006-05-15", age = "15", rollClass = "9B", yearLevel = new YearLevel { code = "9", description = "Year 9" }, enrolmentStatus = new EnrolmentStatus { code = "ENR", description = "Enrolled" }, gender = new Gender { code = "F", description = "Female" }, hasAbsentNote = true, absences = new List<Absence> { new Absence { studentAbsenceId = 201, enrolmentId = 2, absenceDate = "2023-09-10", absenceReason = new AbsenceReason { code = "SICK", description = "Sick" }, note = "Doctor's Appointment", modifiedDate = "2023-09-15", modifiedBy = "admin" } } }
                }
            },
            new StudentsResponse
            {
                students = new List<Student>
                {
                    new Student { enrolmentId = 3, eqId = "EQ003", imageId = 103, familyName = "Williams", givenNames = "Michael", birthDate = "2007-03-22", age = "16", rollClass = "10C", yearLevel = new YearLevel { code = "10", description = "Year 10" }, enrolmentStatus = new EnrolmentStatus { code = "ENR", description = "Enrolled" }, gender = new Gender { code = "M", description = "Male" }, hasAbsentNote = false, absences = new List<Absence>() },
                    new Student { enrolmentId = 4, eqId = "EQ004", imageId = 104, familyName = "Davis", givenNames = "Sophia", birthDate = "2006-02-09", age = "15", rollClass = "9A", yearLevel = new YearLevel { code = "9", description = "Year 9" }, enrolmentStatus = new EnrolmentStatus { code = "ENR", description = "Enrolled" }, gender = new Gender { code = "F", description = "Female" }, hasAbsentNote = true, absences = new List<Absence>() }
                }
            },
            new StudentsResponse
            {
                students = new List<Student>()
            },
            new StudentsResponse
            {
                students = new List<Student>
                {
                    new Student { enrolmentId = 5, eqId = "EQ005", imageId = 105, familyName = "Garcia", givenNames = "Lucas", birthDate = "2008-12-01", age = "14", rollClass = "8B", yearLevel = new YearLevel { code = "8", description = "Year 8" }, enrolmentStatus = new EnrolmentStatus { code = "ENR", description = "Enrolled" }, gender = new Gender { code = "M", description = "Male" }, hasAbsentNote = false, absences = new List<Absence>() },
                    new Student { enrolmentId = 6, eqId = "EQ006", imageId = 106, familyName = "Martinez", givenNames = "Isabella", birthDate = "2007-04-20", age = "16", rollClass = "9C", yearLevel = new YearLevel { code = "9", description = "Year 9" }, enrolmentStatus = new EnrolmentStatus { code = "ENR", description = "Enrolled" }, gender = new Gender { code = "F", description = "Female" }, hasAbsentNote = true, absences = new List<Absence> { new Absence { studentAbsenceId = 202, enrolmentId = 6, absenceDate = "2023-09-17", absenceReason = new AbsenceReason { code = "VAC", description = "Vacation" }, note = "Family trip", modifiedDate = "2023-09-18", modifiedBy = "admin" } } }
                }
            }
        };

        return JsonSerializer.Serialize(studentRecords, new JsonSerializerOptions { WriteIndented = true });
    }
}

string json = Program.Main();