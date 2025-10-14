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
                AttendanceId = 1,
                Version = 1,
                IsRollMarkable = true,
                NotRollMarkableReason = new Reason { Code = "None", Description = "N/A" },
                IsRollMarked = false,
                RollMarkedDate = null,
                RollMarkedUser = null,
                Students = new List<Student>
                {
                    new Student
                    {
                        EnrolmentId = 1001,
                        AttendanceStatus = new AttendanceStatus { Code = "Present", Description = "Present" },
                        HasAttendanceChanges = false,
                        HasAbsentNote = false,
                        EqId = "EQ001",
                        ImageId = null,
                        FamilyName = "Smith",
                        GivenNames = "John",
                        BirthDate = "2010-05-25",
                        Age = "13",
                        RollClass = "Class 1",
                        YearLevel = new YearLevel { Code = "Year 7", Description = "Year 7" },
                        EnrolmentStatus = new EnrolmentStatus { Code = "Enrolled", Description = "Enrolled" },
                        Gender = new Gender { Code = "M", Description = "Male" },
                        Absences = new List<Absence>()
                    }
                }
            },
            new StudentInformationResponse
            {
                AttendanceId = 2,
                Version = 1,
                IsRollMarkable = false,
                NotRollMarkableReason = new Reason { Code = "Excused", Description = "Doctor's appointment" },
                IsRollMarked = true,
                RollMarkedDate = "2023-10-12T08:00:00Z",
                RollMarkedUser = "teacher1",
                Students = new List<Student>
                {
                    new Student
                    {
                        EnrolmentId = 1002,
                        AttendanceStatus = new AttendanceStatus { Code = "Absent", Description = "Absent" },
                        HasAttendanceChanges = true,
                        HasAbsentNote = true,
                        EqId = "EQ002",
                        ImageId = null,
                        FamilyName = "Johnson",
                        GivenNames = "Emily",
                        BirthDate = "2009-03-15",
                        Age = "14",
                        RollClass = "Class 2",
                        YearLevel = new YearLevel { Code = "Year 8", Description = "Year 8" },
                        EnrolmentStatus = new EnrolmentStatus { Code = "Enrolled", Description = "Enrolled" },
                        Gender = new Gender { Code = "F", Description = "Female" },
                        Absences = new List<Absence>
                        {
                            new Absence
                            {
                                StudentAbsenceId = 1,
                                EnrolmentId = 1002,
                                AbsenceDate = "2023-10-12T00:00:00Z",
                                AbsenceReason = new AbsenceReason { Code = "Medical", Description = "Doctor's appointment" },
                                PartOfDayAbsence = new PartOfDayAbsence { Code = "FullDay", Description = "Full day" },
                                LateEarlyTime = null,
                                Note = "N/A",
                                ModifiedDate = "2023-10-12T09:00:00Z",
                                ModifiedBy = "teacher1"
                            }
                        }
                    },
                    new Student
                    {
                        EnrolmentId = 1003,
                        AttendanceStatus = new AttendanceStatus { Code = "Present", Description = "Present" },
                        HasAttendanceChanges = false,
                        HasAbsentNote = false,
                        EqId = "EQ003",
                        ImageId = null,
                        FamilyName = "Davis",
                        GivenNames = "Michael",
                        BirthDate = "2010-07-22",
                        Age = "13",
                        RollClass = "Class 2",
                        YearLevel = new YearLevel { Code = "Year 8", Description = "Year 8" },
                        EnrolmentStatus = new EnrolmentStatus { Code = "Enrolled", Description = "Enrolled" },
                        Gender = new Gender { Code = "M", Description = "Male" },
                        Absences = new List<Absence>()
                    }
                }
            },
            new StudentInformationResponse
            {
                AttendanceId = 3,
                Version = 1,
                IsRollMarkable = true,
                NotRollMarkableReason = new Reason { Code = "None", Description = "N/A" },
                IsRollMarked = false,
                RollMarkedDate = null,
                RollMarkedUser = null,
                Students = new List<Student>
                {
                    new Student
                    {
                        EnrolmentId = 1004,
                        AttendanceStatus = new AttendanceStatus { Code = "Present", Description = "Present" },
                        HasAttendanceChanges = false,
                        HasAbsentNote = false,
                        EqId = "EQ004",
                        ImageId = null,
                        FamilyName = "Williams",
                        GivenNames = "Sophia",
                        BirthDate = "2009-11-30",
                        Age = "14",
                        RollClass = "Class 3",
                        YearLevel = new YearLevel { Code = "Year 8", Description = "Year 8" },
                        EnrolmentStatus = new EnrolmentStatus { Code = "Enrolled", Description = "Enrolled" },
                        Gender = new Gender { Code = "F", Description = "Female" },
                        Absences = new List<Absence>()
                    },
                    new Student
                    {
                        EnrolmentId = 1005,
                        AttendanceStatus = new AttendanceStatus { Code = "Absent", Description = "Absent" },
                        HasAttendanceChanges = true,
                        HasAbsentNote = false,
                        EqId = "EQ005",
                        ImageId = null,
                        FamilyName = "Brown",
                        GivenNames = "Daniel",
                        BirthDate = "2009-04-18",
                        Age = "14",
                        RollClass = "Class 3",
                        YearLevel = new YearLevel { Code = "Year 8", Description = "Year 8" },
                        EnrolmentStatus = new EnrolmentStatus { Code = "Enrolled", Description = "Enrolled" },
                        Gender = new Gender { Code = "M", Description = "Male" },
                        Absences = new List<Absence>()
                    }
                }
            },
            new StudentInformationResponse
            {
                AttendanceId = 4,
                Version = 1,
                IsRollMarkable = true,
                NotRollMarkableReason = new Reason { Code = "None", Description = "N/A" },
                IsRollMarked = true,
                RollMarkedDate = "2023-10-10T08:00:00Z",
                RollMarkedUser = "teacher2",
                Students = new List<Student>
                {
                    new Student
                    {
                        EnrolmentId = 1006,
                        AttendanceStatus = new AttendanceStatus { Code = "Present", Description = "Present" },
                        HasAttendanceChanges = false,
                        HasAbsentNote = false,
                        EqId = "EQ006",
                        ImageId = null,
                        FamilyName = "Jones",
                        GivenNames = "Olivia",
                        BirthDate = "2008-02-14",
                        Age = "15",
                        RollClass = "Class 4",
                        YearLevel = new YearLevel { Code = "Year 9", Description = "Year 9" },
                        EnrolmentStatus = new EnrolmentStatus { Code = "Enrolled", Description = "Enrolled" },
                        Gender = new Gender { Code = "F", Description = "Female" },
                        Absences = new List<Absence>()
                    }
                }
            },
            new StudentInformationResponse
            {
                AttendanceId = 5,
                Version = 1,
                IsRollMarkable = false,
                NotRollMarkableReason = new Reason { Code = "Excused", Description = "Family emergency" },
                IsRollMarked = false,
                RollMarkedDate = null,
                RollMarkedUser = null,
                Students = new List<Student>
                {
                    new Student
                    {
                        EnrolmentId = 1007,
                        AttendanceStatus = new AttendanceStatus { Code = "Absent", Description = "Absent" },
                        HasAttendanceChanges = true,
                        HasAbsentNote = true,
                        EqId = "EQ007",
                        ImageId = null,
                        FamilyName = "Garcia",
                        GivenNames = "Liam",
                        BirthDate = "2011-10-05",
                        Age = "12",
                        RollClass = "Class 5",
                        YearLevel = new YearLevel { Code = "Year 6", Description = "Year 6" },
                        EnrolmentStatus = new EnrolmentStatus { Code = "Enrolled", Description = "Enrolled" },
                        Gender = new Gender { Code = "M", Description = "Male" },
                        Absences = new List<Absence>
                        {
                            new Absence
                            {
                                StudentAbsenceId = 2,
                                EnrolmentId = 1007,
                                AbsenceDate = "2023-10-11T00:00:00Z",
                                AbsenceReason = new AbsenceReason { Code = "Family", Description = "Family emergency" },
                                PartOfDayAbsence = new PartOfDayAbsence { Code = "FullDay", Description = "Full day" },
                                LateEarlyTime = null,
                                Note = "N/A",
                                ModifiedDate = "2023-10-11T09:00:00Z",
                                ModifiedBy = "parent"
                            }
                        }
                    }
                }
            }
        };

        return JsonSerializer.Serialize(studentInformationResponses, new JsonSerializerOptions { WriteIndented = true });
    }
}

public class StudentInformationResponse
{
    public int? AttendanceId { get; set; }
    public int Version { get; set; }
    public bool IsRollMarkable { get; set; }
    public Reason NotRollMarkableReason { get; set; }
    public bool IsRollMarked { get; set; }
    public string RollMarkedDate { get; set; }
    public string RollMarkedUser { get; set; }
    public List<Student> Students { get; set; }
}

public class Reason
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
    public string BirthDate { get; set; }
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
    public string AbsenceDate { get; set; }
    public AbsenceReason AbsenceReason { get; set; }
    public PartOfDayAbsence PartOfDayAbsence { get; set; }
    public string LateEarlyTime { get; set; }
    public string Note { get; set; }
    public string ModifiedDate { get; set; }
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