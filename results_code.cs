using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class GeneratedCode
{
    public static void Main(string[] args)
    {
        var sampleRecords = new List<StudentSchedulesResponse>();
        for (int i = 0; i < 100; i++)
        {
            sampleRecords.Add(GenerateStudentSchedule());
        }
        
        string jsonOutput = JsonConvert.SerializeObject(sampleRecords, Formatting.Indented);
        Console.WriteLine(jsonOutput);
    }

    private static StudentSchedulesResponse GenerateStudentSchedule()
    {
        var random = new Random();
        var date = DateTime.UtcNow.AddDays(random.Next(-30, 30)).ToString("yyyy-MM-ddTHH:mm:ssZ");
        
        var dayType = new DayType
        {
            Code = new[] { "WD", "WE", "SD" }[random.Next(3)],
            Description = new[] { "Weekday", "Weekend", "School Day" }[random.Next(3)]
        };

        var schedules = new List<Schedule>();
        for (int j = 0; j < random.Next(1, 5); j++)
        {
            var timetableVersion = new TimetableVersion
            {
                Id = random.Next(1, 100),
                Name = $"Timetable {random.Next(1, 10)}"
            };

            var periods = new List<Period>();
            for (int k = 0; k < random.Next(1, 8); k++)
            {
                var startTime = DateTime.UtcNow.AddHours(random.Next(0, 8)).AddMinutes(random.Next(0, 59)).ToString("yyyy-MM-ddTHH:mm:ssZ");
                var endTime = DateTime.UtcNow.AddHours(random.Next(9, 17)).AddMinutes(random.Next(0, 59)).ToString("yyyy-MM-ddTHH:mm:ssZ");

                var period = new Period()
                {
                    DayConfigId = random.Next(1, 50),
                    DayConfigType = new DayConfigType
                    {
                        Code = new[] { "A", "B", "C" }[random.Next(3)],
                        Description = new[] { "Type A", "Type B", "Type C" }[random.Next(3)]
                    },
                    StartTime = startTime,
                    EndTime = endTime,
                    ItemName = $"Period {random.Next(1, 10)}",
                    ShortName = new[] { "Math", "Eng", "Sci", "Hist", "PE" }[random.Next(5)],
                    IsTeachingAllocation = random.Next(2) == 0,
                    Classes = new List<Class>()
                };

                for (int l = 0; l < random.Next(1, 5); l++)
                {
                    period.Classes.Add(new Class
                    {
                        HasAttendanceChanges = random.Next(2) == 0,
                        AttendanceStatus = new AttendanceStatus
                        {
                            Code = new[] { "P", "A", "L" }[random.Next(3)],
                            Description = new[] { "Present", "Absent", "Late" }[random.Next(3)]
                        },
                        TimetableClassId = random.Next(1, 100),
                        StartTime = startTime,
                        EndTime = endTime,
                        ClassName = $"Class {random.Next(1, 20)}",
                        Activity = new Activity
                        {
                            Code = new[] { "ACT1", "ACT2" }[random.Next(2)],
                            Description = new[] { "Activity 1", "Activity 2" }[random.Next(2)]
                        },
                        LearningArea = new LearningArea
                        {
                            Code = new[] { "LA1", "LA2" }[random.Next(2)],
                            Description = new[] { "Area 1", "Area 2" }[random.Next(2)]
                        },
                        Facility = new Facility
                        {
                            Code = new[] { "FAC1", "FAC2" }[random.Next(2)],
                            Description = new[] { "Facility 1", "Facility 2" }[random.Next(2)]
                        },
                        ClassType = new ClassType
                        {
                            Code = new[] { "TYPE1", "TYPE2" }[random.Next(2)],
                            Description = new[] { "Type 1", "Type 2" }[random.Next(2)]
                        },
                        IsCompositeClass = random.Next(2) == 0,
                        IsRollMarkable = random.Next(2) == 0,
                        NotRollMarkableReason = new NotRollMarkableReason
                        {
                            Code = new[] { "NR1", "NR2" }[random.Next(2)],
                            Description = new[] { "No reason", "Another reason" }[random.Next(2)]
                        },
                        IsRollMarked = random.Next(2) == 0,
                        RollMarkedDate = random.Next(2) == 0 ? (DateTime?)null : DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                        RollMarkedUser = random.Next(2) == 0 ? null : "User" + random.Next(1, 3),
                        Session = new[] { "Session 1", "Session 2" }[random.Next(2)],
                        YearLevel = new YearLevel
                        {
                            Code = new[] { "Y1", "Y2" }[random.Next(2)],
                            Description = new[] { "Year 1", "Year 2" }[random.Next(2)]
                        },
                        Teachers = new List<Teacher>
                        {
                            new Teacher
                            {
                                StaffCentreId = random.Next(1, 11),
                                Title = new[] { "Mr", "Ms", "Mrs" }[random.Next(3)],
                                FamilyName = new[] { "Smith", "Johnson", "Williams" }[random.Next(3)],
                                GivenNames = new[] { "John", "Emily", "Alice" }[random.Next(3)],
                                TimetableCode = $"TC{random.Next(1, 100)}"
                            }
                        }
                    });
                }
                periods.Add(period);
            }

            schedules.Add(new Schedule
            {
                DayCycleCode = new[] { "Cycle 1", "Cycle 2" }[random.Next(2)],
                TimetableVersion = timetableVersion,
                Periods = periods
            });
        }

        return new StudentSchedulesResponse
        {
            Date = date,
            DayType = dayType,
            Schedules = schedules
        };
    }

    // Define the necessary classes for the response
    public class StudentSchedulesResponse
    {
        public string Date { get; set; }
        public DayType DayType { get; set; }
        public List<Schedule> Schedules { get; set; }
    }

    public class DayType
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class Schedule
    {
        public string DayCycleCode { get; set; }
        public TimetableVersion TimetableVersion { get; set; }
        public List<Period> Periods { get; set; }
    }

    public class TimetableVersion
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Period
    {
        public int DayConfigId { get; set; }
        public DayConfigType DayConfigType { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ItemName { get; set; }
        public string ShortName { get; set; }
        public bool IsTeachingAllocation { get; set; }
        public List<Class> Classes { get; set; }
    }

    public class DayConfigType
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class Class
    {
        public bool HasAttendanceChanges { get; set; }
        public AttendanceStatus AttendanceStatus { get; set; }
        public int TimetableClassId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ClassName { get; set; }
        public Activity Activity { get; set; }
        public LearningArea LearningArea { get; set; }
        public Facility Facility { get; set; }
        public ClassType ClassType { get; set; }
        public bool IsCompositeClass { get; set; }
        public bool IsRollMarkable { get; set; }
        public NotRollMarkableReason NotRollMarkableReason { get; set; }
        public bool IsRollMarked { get; set; }
        public string RollMarkedDate { get; set; }
        public string RollMarkedUser { get; set; }
        public string Session { get; set; }
        public YearLevel YearLevel { get; set; }
        public List<Teacher> Teachers { get; set; }
    }

    public class AttendanceStatus
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class Activity
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class LearningArea
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class Facility
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class ClassType
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class NotRollMarkableReason
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class YearLevel
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class Teacher
    {
        public int StaffCentreId { get; set; }
        public string Title { get; set; }
        public string FamilyName { get; set; }
        public string GivenNames { get; set; }
        public string TimetableCode { get; set; }
    }
}