using System;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static string Main()
    {
        var compositeResponse = new CompositeStudentInformationResponse
        {
            session = "2023",
            isRollMarkable = true,
            notRollMarkableReason = null,
            isRollMarked = false,
            rollMarkedDate = null,
            rollMarkedUser = null,
            timetableClassIds = "T-Class-1, T-Class-2",
            classes = new List<Class>
            {
                new Class { attendanceId = 1, version = 1, isRollMarkable = true, notRollMarkableReason = null, isRollMarked = false, rollMarkedDate = null, rollMarkedUser = null },
                new Class { attendanceId = 2, version = 1, isRollMarkable = false, notRollMarkableReason = new Reason { code = "001", description = "Not available" }, isRollMarked = false, rollMarkedDate = null, rollMarkedUser = null }
            },
            students = new List<Student>
            {
                new Student { session = "2023", timetableClassId = 1, enrolmentId = 101, attendanceStatus = new Status { code = "P", description = "Present" }, hasAttendanceChanges = false, hasAbsentNote = false, eqId = "E-101", imageId = null, familyName = "Smith", givenNames = "John", birthDate = "2005-06-15", age = "18", rollClass = "12A", yearLevel = new YearLevel { code = "12", description = "Year 12" }, enrolmentStatus = new Status { code = "ENR", description = "Enrolled" }, gender = new Gender { code = "M", description = "Male" }, absences = new List<Absence>() },
                new Student { session = "2023", timetableClassId = 1, enrolmentId = 102, attendanceStatus = new Status { code = "P", description = "Present" }, hasAttendanceChanges = false, hasAbsentNote = false, eqId = "E-102", imageId = null, familyName = "Brown", givenNames = "Alice", birthDate = "2006-07-20", age = "17", rollClass = "12B", yearLevel = new YearLevel { code = "12", description = "Year 12" }, enrolmentStatus = new Status { code = "ENR", description = "Enrolled" }, gender = new Gender { code = "F", description = "Female" }, absences = new List<Absence>() }
            }
        };

        var studentsResponse = new StudentsResponse
        {
            students = new List<StudentResponse>
            {
                new StudentResponse { enrolmentId = 201, eqId = "E-101", imageId = null, familyName = "Smith", givenNames = "John", birthDate = "2005-06-15", age = "18", rollClass = "12A", yearLevel = new YearLevelResponse { code = "12", description = "Year 12" }, enrolmentStatus = new StatusResponse { code = "ENR", description = "Enrolled" }, gender = new GenderResponse { code = "M", description = "Male" }, hasAbsentNote = false, absences = new List<AbsenceResponse>() },
                new StudentResponse { enrolmentId = 202, eqId = "E-102", imageId = null, familyName = "Brown", givenNames = "Alice", birthDate = "2006-07-20", age = "17", rollClass = "12B", yearLevel = new YearLevelResponse { code = "12", description = "Year 12" }, enrolmentStatus = new StatusResponse { code = "ENR", description = "Enrolled" }, gender = new GenderResponse { code = "F", description = "Female" }, hasAbsentNote = false, absences = new List<AbsenceResponse>() },
                new StudentResponse { enrolmentId = 203, eqId = "E-101", imageId = null, familyName = "Johnson", givenNames = "Michael", birthDate = "2004-05-12", age = "19", rollClass = "12C", yearLevel = new YearLevelResponse { code = "12", description = "Year 12" }, enrolmentStatus = new StatusResponse { code = "ENR", description = "Enrolled" }, gender = new GenderResponse { code = "M", description = "Male" }, hasAbsentNote = true, absences = new List<AbsenceResponse>() }
            }
        };

        return JsonSerializer.Serialize(new { CompositeStudentInformationResponse = compositeResponse, StudentsResponse = studentsResponse }, new JsonSerializerOptions { WriteIndented = true });
    }

    public class CompositeStudentInformationResponse
    {
        public string session { get; set; }
        public bool isRollMarkable { get; set; }
        public Reason notRollMarkableReason { get; set; }
        public bool isRollMarked { get; set; }
        public string rollMarkedDate { get; set; }
        public string rollMarkedUser { get; set; }
        public string timetableClassIds { get; set; }
        public List<Class> classes { get; set; }
        public List<Student> students { get; set; }
    }

    public class Class
    {
        public int? attendanceId { get; set; }
        public int? version { get; set; }
        public bool isRollMarkable { get; set; }
        public Reason notRollMarkableReason { get; set; }
        public bool? isRollMarked { get; set; }
        public string rollMarkedDate { get; set; }
        public string rollMarkedUser { get; set; }
    }

    public class Reason
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    public class Student
    {
        public string session { get; set; }
        public int timetableClassId { get; set; }
        public int enrolmentId { get; set; }
        public Status attendanceStatus { get; set; }
        public bool hasAttendanceChanges { get; set; }
        public bool hasAbsentNote { get; set; }
        public string eqId { get; set; }
        public int? imageId { get; set; }
        public string familyName { get; set; }
        public string givenNames { get; set; }
        public string birthDate { get; set; }
        public string age { get; set; }
        public string rollClass { get; set; }
        public YearLevel yearLevel { get; set; }
        public Status enrolmentStatus { get; set; }
        public Gender gender { get; set; }
        public List<Absence> absences { get; set; }
    }

    public class Status
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    public class YearLevel
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    public class Gender
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    public class Absence { }

    public class StudentsResponse
    {
        public List<StudentResponse> students { get; set; }
    }

    public class StudentResponse
    {
        public int enrolmentId { get; set; }
        public string eqId { get; set; }
        public int? imageId { get; set; }
        public string familyName { get; set; }
        public string givenNames { get; set; }
        public string birthDate { get; set; }
        public string age { get; set; }
        public string rollClass { get; set; }
        public YearLevelResponse yearLevel { get; set; }
        public StatusResponse enrolmentStatus { get; set; }
        public GenderResponse gender { get; set; }
        public bool hasAbsentNote { get; set; }
        public List<AbsenceResponse> absences { get; set; }
    }

    public class YearLevelResponse
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    public class StatusResponse
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    public class GenderResponse
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    public class AbsenceResponse { }
}

string json = Program.Main();