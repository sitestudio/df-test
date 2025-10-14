using System;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static string Main()
    {
        var compositeResponse = new CompositeStudentInformationResponse
        {
            session = "2023-2024",
            isRollMarkable = true,
            notRollMarkableReason = new NotRollMarkableReason { code = "0", description = "No Reason" },
            isRollMarked = true,
            rollMarkedDate = DateTime.UtcNow.ToString("o"),
            rollMarkedUser = "admin",
            timetableClassIds = "class123;class456",
            classes = new List<ClassInfo>
            {
                new ClassInfo
                {
                    attendanceId = 1,
                    version = 1,
                    isRollMarkable = true,
                    notRollMarkableReason = new NotRollMarkableReason { code = "0", description = "No Reason" },
                    isRollMarked = true,
                    rollMarkedDate = DateTime.UtcNow.ToString("o"),
                    rollMarkedUser = "admin"
                }
            },
            students = new List<StudentInfo>
            {
                new StudentInfo
                {
                    session = "2023-2024",
                    timetableClassId = 1,
                    enrolmentId = 1,
                    attendanceStatus = new AttendanceStatus { code = "P", description = "Present" },
                    hasAttendanceChanges = false,
                    hasAbsentNote = false,
                    eqId = "eq1",
                    imageId = null,
                    familyName = "Smith",
                    givenNames = "John",
                    birthDate = "2005-01-15T00:00:00Z",
                    age = "18",
                    rollClass = "Math",
                    yearLevel = new YearLevel { code = "12", description = "Year 12" },
                    enrolmentStatus = new EnrolmentStatus { code = "EN", description = "Enrolled" },
                    gender = new Gender { code = "M", description = "Male" },
                    absences = new List<AbsenceRecord>()
                },
                new StudentInfo
                {
                    session = "2023-2024",
                    timetableClassId = 1,
                    enrolmentId = 2,
                    attendanceStatus = new AttendanceStatus { code = "A", description = "Absent" },
                    hasAttendanceChanges = false,
                    hasAbsentNote = true,
                    eqId = "eq2",
                    imageId = null,
                    familyName = "Doe",
                    givenNames = "Jane",
                    birthDate = "2004-05-22T00:00:00Z",
                    age = "19",
                    rollClass = "English",
                    yearLevel = new YearLevel { code = "12", description = "Year 12" },
                    enrolmentStatus = new EnrolmentStatus { code = "EN", description = "Enrolled" },
                    gender = new Gender { code = "F", description = "Female" },
                    absences = new List<AbsenceRecord>
                    {
                        new AbsenceRecord
                        {
                            studentAbsenceId = 1,
                            enrolmentId = 2,
                            absenceDate = "2023-10-01T00:00:00Z",
                            absenceReason = new AbsenceReason { code = "S", description = "Sick" },
                            partOfDayAbsence = new PartOfDayAbsence { code = "FullDay", description = "Full Day" },
                            lateEarlyTime = null,
                            note = "Doctor's appointment",
                            modifiedDate = DateTime.UtcNow.ToString("o"),
                            modifiedBy = "admin"
                        }
                    }
                },
                new StudentInfo
                {
                    session = "2023-2024",
                    timetableClassId = 1,
                    enrolmentId = 3,
                    attendanceStatus = new AttendanceStatus { code = "P", description = "Present" },
                    hasAttendanceChanges = false,
                    hasAbsentNote = false,
                    eqId = "eq3",
                    imageId = null,
                    familyName = "Brown",
                    givenNames = "Emily",
                    birthDate = "2005-07-10T00:00:00Z",
                    age = "18",
                    rollClass = "Science",
                    yearLevel = new YearLevel { code = "11", description = "Year 11" },
                    enrolmentStatus = new EnrolmentStatus { code = "EN", description = "Enrolled" },
                    gender = new Gender { code = "F", description = "Female" },
                    absences = new List<AbsenceRecord>()
                }
            }
        };

        var studentsResponse = new StudentsResponse
        {
            students = new List<StudentRecord>
            {
                new StudentRecord
                {
                    enrolmentId = 1,
                    eqId = "eq1",
                    imageId = null,
                    familyName = "Smith",
                    givenNames = "John",
                    birthDate = "2005-01-15T00:00:00Z",
                    age = "18",
                    rollClass = "Math",
                    yearLevel = new YearLevel { code = "12", description = "Year 12" },
                    enrolmentStatus = new EnrolmentStatus { code = "EN", description = "Enrolled" },
                    gender = new Gender { code = "M", description = "Male" },
                    hasAbsentNote = false,
                    absences = new List<AbsenceRecord>()
                },
                new StudentRecord
                {
                    enrolmentId = 2,
                    eqId = "eq2",
                    imageId = null,
                    familyName = "Doe",
                    givenNames = "Jane",
                    birthDate = "2004-05-22T00:00:00Z",
                    age = "19",
                    rollClass = "English",
                    yearLevel = new YearLevel { code = "12", description = "Year 12" },
                    enrolmentStatus = new EnrolmentStatus { code = "EN", description = "Enrolled" },
                    gender = new Gender { code = "F", description = "Female" },
                    hasAbsentNote = true,
                    absences = new List<AbsenceRecord>()
                },
                new StudentRecord
                {
                    enrolmentId = 3,
                    eqId = "eq3",
                    imageId = null,
                    familyName = "Brown",
                    givenNames = "Emily",
                    birthDate = "2005-07-10T00:00:00Z",
                    age = "18",
                    rollClass = "Science",
                    yearLevel = new YearLevel { code = "11", description = "Year 11" },
                    enrolmentStatus = new EnrolmentStatus { code = "EN", description = "Enrolled" },
                    gender = new Gender { code = "F", description = "Female" },
                    hasAbsentNote = false,
                    absences = new List<AbsenceRecord>()
                },
                new StudentRecord
                {
                    enrolmentId = 4,
                    eqId = "eq4",
                    imageId = null,
                    familyName = "Johnson",
                    givenNames = "Michael",
                    birthDate = "2006-02-14T00:00:00Z",
                    age = "17",
                    rollClass = "History",
                    yearLevel = new YearLevel { code = "10", description = "Year 10" },
                    enrolmentStatus = new EnrolmentStatus { code = "EN", description = "Enrolled" },
                    gender = new Gender { code = "M", description = "Male" },
                    hasAbsentNote = false,
                    absences = new List<AbsenceRecord>()
                }
            }
        };

        return JsonSerializer.Serialize(new { compositeResponse, studentsResponse }, new JsonSerializerOptions { WriteIndented = true });
    }

    public class CompositeStudentInformationResponse
    {
        public string session { get; set; }
        public bool isRollMarkable { get; set; }
        public NotRollMarkableReason notRollMarkableReason { get; set; }
        public bool isRollMarked { get; set; }
        public string rollMarkedDate { get; set; }
        public string rollMarkedUser { get; set; }
        public string timetableClassIds { get; set; }
        public List<ClassInfo> classes { get; set; }
        public List<StudentInfo> students { get; set; }
    }

    public class NotRollMarkableReason
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    public class ClassInfo
    {
        public int? attendanceId { get; set; }
        public int? version { get; set; }
        public bool isRollMarkable { get; set; }
        public NotRollMarkableReason notRollMarkableReason { get; set; }
        public bool? isRollMarked { get; set; }
        public string rollMarkedDate { get; set; }
        public string rollMarkedUser { get; set; }
    }

    public class StudentInfo
    {
        public string session { get; set; }
        public int timetableClassId { get; set; }
        public int enrolmentId { get; set; }
        public AttendanceStatus attendanceStatus { get; set; }
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
        public EnrolmentStatus enrolmentStatus { get; set; }
        public Gender gender { get; set; }
        public List<AbsenceRecord> absences { get; set; }
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

    public class AbsenceRecord
    {
        public int studentAbsenceId { get; set; }
        public int enrolmentId { get; set; }
        public string absenceDate { get; set; }
        public AbsenceReason absenceReason { get; set; }
        public PartOfDayAbsence partOfDayAbsence { get; set; }
        public string lateEarlyTime { get; set; }
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
        public List<StudentRecord> students { get; set; }
    }

    public class StudentRecord
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
        public List<AbsenceRecord> absences { get; set; }
    }
}

// The generated JSON output
string json = Program.Main();