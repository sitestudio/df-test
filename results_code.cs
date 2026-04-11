using System;
using System.Collections.Generic;
using System.Text.Json;

namespace GeneratedCode
{
    public class StudentInformationResponse
    {
        public int? AttendanceId { get; set; }
        public int Version { get; set; }
        public bool IsRollMarkable { get; set; }
        public NotRollMarkableReason NotRollMarkableReason { get; set; }
        public bool IsRollMarked { get; set; }
        public string? RollMarkedDate { get; set; }
        public string? RollMarkedUser { get; set; }
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
        public string? LateEarlyTime { get; set; }
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

    public static class Program
    {
        public static string Main()
        {
            var response1 = new StudentInformationResponse
            {
                AttendanceId = 101,
                Version = 1,
                IsRollMarkable = true,
                NotRollMarkableReason = null,
                IsRollMarked = true,
                RollMarkedDate = "2023-10-05T12:00:00Z",
                RollMarkedUser = "user1",
                Students = new List<Student>
                {
                    new Student
                    {
                        EnrolmentId = 201,
                        AttendanceStatus = new AttendanceStatus { Code = "A", Description = "Absent" },
                        HasAttendanceChanges = false,
                        HasAbsentNote = true,
                        EqId = "EQ123",
                        ImageId = null,
                        FamilyName = "Smith",
                        GivenNames = "John",
                        BirthDate = "2010-05-15T00:00:00Z",
                        Age = "13",
                        RollClass = "Class 1",
                        YearLevel = new YearLevel { Code = "1", Description = "Year 1" },
                        EnrolmentStatus = new EnrolmentStatus { Code = "ENR", Description = "Enrolled" },
                        Gender = new Gender { Code = "M", Description = "Male" },
                        Absences = new List<Absence>
                        {
                            new Absence
                            {
                                StudentAbsenceId = 301,
                                EnrolmentId = 201,
                                AbsenceDate = "2023-09-05T00:00:00Z",
                                AbsenceReason = new AbsenceReason { Code = "SICK", Description = "Sick" },
                                PartOfDayAbsence = new PartOfDayAbsence { Code = "FULL", Description = "Full Day" },
                                LateEarlyTime = null,
                                Note = "Doctor's appointment",
                                ModifiedDate = "2023-09-04T12:00:00Z",
                                ModifiedBy = "admin"
                            }
                        }
                    }
                }
            };

            var response2 = new StudentInformationResponse
            {
                AttendanceId = 102,
                Version = 1,
                IsRollMarkable = true,
                NotRollMarkableReason = null,
                IsRollMarked = false,
                RollMarkedDate = null,
                RollMarkedUser = null,
                Students = new List<Student>
                {
                    new Student
                    {
                        EnrolmentId = 202,
                        AttendanceStatus = new AttendanceStatus { Code = "P", Description = "Present" },
                        HasAttendanceChanges = false,
                        HasAbsentNote = false,
                        EqId = "EQ124",
                        ImageId = null,
                        FamilyName = "Doe",
                        GivenNames = "Jane",
                        BirthDate = "2011-06-20T00:00:00Z",
                        Age = "12",
                        RollClass = "Class 2",
                        YearLevel = new YearLevel { Code = "2", Description = "Year 2" },
                        EnrolmentStatus = new EnrolmentStatus { Code = "ENR", Description = "Enrolled" },
                        Gender = new Gender { Code = "F", Description = "Female" },
                        Absences = new List<Absence>()
                    },
                    new Student
                    {
                        EnrolmentId = 203,
                        AttendanceStatus = new AttendanceStatus { Code = "P", Description = "Present" },
                        HasAttendanceChanges = false,
                        HasAbsentNote = true,
                        EqId = "EQ125",
                        ImageId = null,
                        FamilyName = "Brown",
                        GivenNames = "Chris",
                        BirthDate = "2011-08-22T00:00:00Z",
                        Age = "12",
                        RollClass = "Class 2",
                        YearLevel = new YearLevel { Code = "2", Description = "Year 2" },
                        EnrolmentStatus = new EnrolmentStatus { Code = "ENR", Description = "Enrolled" },
                        Gender = new Gender { Code = "M", Description = "Male" },
                        Absences = new List<Absence>()
                    }
                }
            };

            var response3 = new StudentInformationResponse
            {
                AttendanceId = 103,
                Version = 2,
                IsRollMarkable = false,
                NotRollMarkableReason = new NotRollMarkableReason { Code = "HOLD", Description = "Pending documents" },
                IsRollMarked = true,
                RollMarkedDate = "2023-10-06T12:30:00Z",
                RollMarkedUser = "user2",
                Students = new List<Student>
                {
                    new Student
                    {
                        EnrolmentId = 204,
                        AttendanceStatus = new AttendanceStatus { Code = "A", Description = "Absent" },
                        HasAttendanceChanges = true,
                        HasAbsentNote = false,
                        EqId = "EQ126",
                        ImageId = null,
                        FamilyName = "Green",
                        GivenNames = "Alex",
                        BirthDate = "2012-02-10T00:00:00Z",
                        Age = "11",
                        RollClass = "Class 3",
                        YearLevel = new YearLevel { Code = "3", Description = "Year 3" },
                        EnrolmentStatus = new EnrolmentStatus { Code = "ENR", Description = "Enrolled" },
                        Gender = new Gender { Code = "M", Description = "Male" },
                        Absences = new List<Absence>
                        {
                            new Absence
                            {
                                StudentAbsenceId = 302,
                                EnrolmentId = 204,
                                AbsenceDate = "2023-08-10T00:00:00Z",
                                AbsenceReason = new AbsenceReason { Code = "FAMILY", Description = "Family Emergency" },
                                PartOfDayAbsence = new PartOfDayAbsence { Code = "FULL", Description = "Full Day" },
                                LateEarlyTime = null,
                                Note = "Family emergency",
                                ModifiedDate = "2023-08-09T12:00:00Z",
                                ModifiedBy = "admin"
                            }
                        }
                    }
                }
            };

            var response4 = new StudentInformationResponse
            {
                AttendanceId = 104,
                Version = 1,
                IsRollMarkable = true,
                NotRollMarkableReason = null,
                IsRollMarked = false,
                RollMarkedDate = null,
                RollMarkedUser = null,
                Students = new List<Student>
                {
                    new Student
                    {
                        EnrolmentId = 205,
                        AttendanceStatus = new AttendanceStatus { Code = "P", Description = "Present" },
                        HasAttendanceChanges = false,
                        HasAbsentNote = true,
                        EqId = "EQ127",
                        ImageId = null,
                        FamilyName = "Gray",
                        GivenNames = "Emily",
                        BirthDate = "2011-04-07T00:00:00Z",
                        Age = "12",
                        RollClass = "Class 1",
                        YearLevel = new YearLevel { Code = "1", Description = "Year 1" },
                        EnrolmentStatus = new EnrolmentStatus { Code = "ENR", Description = "Enrolled" },
                        Gender = new Gender { Code = "F", Description = "Female" },
                        Absences = new List<Absence>()
                    },
                    new Student
                    {
                        EnrolmentId = 206,
                        AttendanceStatus = new AttendanceStatus { Code = "A", Description = "Absent" },
                        HasAttendanceChanges = false,
                        HasAbsentNote = true,
                        EqId = "EQ128",
                        ImageId = null,
                        FamilyName = "Williams",
                        GivenNames = "Lisa",
                        BirthDate = "2011-09-18T00:00:00Z",
                        Age = "12",
                        RollClass = "Class 1",
                        YearLevel = new YearLevel { Code = "1", Description = "Year 1" },
                        EnrolmentStatus = new EnrolmentStatus { Code = "ENR", Description = "Enrolled" },
                        Gender = new Gender { Code = "F", Description = "Female" },
                        Absences = new List<Absence>()
                    },
                    new Student
                    {
                        EnrolmentId = 207,
                        AttendanceStatus = new AttendanceStatus { Code = "P", Description = "Present" },
                        HasAttendanceChanges = false,
                        HasAbsentNote = false,
                        EqId = "EQ129",
                        ImageId = null,
                        FamilyName = "Johnson",
                        GivenNames = "David",
                        BirthDate = "2010-11-30T00:00:00Z",
                        Age = "12",
                        RollClass = "Class 1",
                        YearLevel = new YearLevel { Code = "1", Description = "Year 1" },
                        EnrolmentStatus = new EnrolmentStatus { Code = "ENR", Description = "Enrolled" },
                        Gender = new Gender { Code = "M", Description = "Male" },
                        Absences = new List<Absence>()
                    }
                }
            };

            var response5 = new StudentInformationResponse
            {
                AttendanceId = 105,
                Version = 1,
                IsRollMarkable = false,
                NotRollMarkableReason = new NotRollMarkableReason { Code = "LATE", Description = "Late validation" },
                IsRollMarked = false,
                RollMarkedDate = "2023-10-07T09:30:00Z",
                RollMarkedUser = "admin",
                Students = new List<Student>
                {
                    new Student
                    {
                        EnrolmentId = 208,
                        AttendanceStatus = new AttendanceStatus { Code = "A", Description = "Absent" },
                        HasAttendanceChanges = true,
                        HasAbsentNote = false,
                        EqId = "EQ130",
                        ImageId = null,
                        FamilyName = "Williams",
                        GivenNames = "Alice",
                        BirthDate = "2012-02-01T00:00:00Z",
                        Age = "11",
                        RollClass = "Class 3",
                        YearLevel = new YearLevel { Code = "3", Description = "Year 3" },
                        EnrolmentStatus = new EnrolmentStatus { Code = "ENR", Description = "Enrolled" },
                        Gender = new Gender { Code = "F", Description = "Female" },
                        Absences = new List<Absence>
                        {
                            new Absence
                            {
                                StudentAbsenceId = 303,
                                EnrolmentId = 208,
                                AbsenceDate = "2023-09-20T00:00:00Z",
                                AbsenceReason = new AbsenceReason { Code = "SICK", Description = "Sick" },
                                PartOfDayAbsence = new PartOfDayAbsence { Code = "FULL", Description = "Full Day" },
                                LateEarlyTime = null,
                                Note = "Flu symptoms",
                                ModifiedDate = "2023-09-19T12:00:00Z",
                                ModifiedBy = "nurse"
                            }
                        }
                    }
                }
            };

            var responses = new List<StudentInformationResponse>
            {
                response1,
                response2,
                response3,
                response4,
                response5
            };

            return JsonSerializer.Serialize(responses, new JsonSerializerOptions { WriteIndented = true });
        }
    }

    string json = Program.Main();