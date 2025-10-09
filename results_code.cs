using System;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static string Main()
    {
        var studentSchedulesResponse = new StudentSchedulesResponse
        {
            Students = new List<Student>()
        };

        for (int i = 0; i < 100; i++)
        {
            studentSchedulesResponse.Students.Add(new Student
            {
                EnrolmentId = i,
                EqId = Guid.NewGuid().ToString(),
                ImageId = (i % 2 == 0) ? (int?)i : null,
                FamilyName = $"FamilyName{i}",
                GivenNames = $"GivenName{i}",
                BirthDate = DateTime.UtcNow.AddYears(-i).ToString("o"),
                Age = (i % 30 + 1).ToString(),
                RollClass = $"RollClass{i % 10}",
                YearLevel = new YearLevel
                {
                    Code = $"Year{i % 12}",
                    Description = $"Year Level {i % 12}"
                },
                EnrolmentStatus = new EnrolmentStatus
                {
                    Code = "Active",
                    Description = "Active Status"
                },
                Gender = new Gender
                {
                    Code = (i % 2 == 0) ? "M" : "F",
                    Description = (i % 2 == 0) ? "Male" : "Female"
                },
                HasAbsentNote = (i % 2 == 0),
                Absences = new List<Absence>
                {
                    new Absence
                    {
                        StudentAbsenceId = i,
                        EnrolmentId = i,
                        AbsenceDate = DateTime.UtcNow.AddDays(-i).ToString("o"),
                        AbsenceReason = new AbsenceReason
                        {
                            Code = "Sick",
                            Description = "Sick leave"
                        },
                        PartOfDayAbsence = new PartOfDayAbsence
                        {
                            Code = "Whole Day",
                            Description = "Whole Day Absence"
                        },
                        LateEarlyTime = null,
                        Note = $"Note for absence {i}",
                        ModifiedDate = DateTime.UtcNow.ToString("o"),
                        ModifiedBy = $"User{i}"
                    }
                }
            });
        }

        return JsonSerializer.Serialize(studentSchedulesResponse);
    }

    public class StudentSchedulesResponse
    {
        public List<Student> Students { get; set; }
    }

    public class Student
    {
        public int EnrolmentId { get; set; }
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
        public bool HasAbsentNote { get; set; }
        public List<Absence> Absences { get; set; }
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
}

json = Program.Main()