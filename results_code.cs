using System;
using System.Collections.Generic;

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

public class Program
{
    public static void Main()
    {
        var random = new Random();
        var studentSchedulesResponses = new List<StudentSchedulesResponse>();

        for (int i = 0; i < 100; i++)
        {
            var studentSchedule = new StudentSchedulesResponse
            {
                Date = DateTime.Now.AddDays(random.Next(-365, 0)).ToString("yyyy-MM-ddTHH:mm:ss"),
                DayType = new DayType
                {
                    Code = random.Next(0, 2) == 0 ? "weekday" : "weekend",
                    Description = random.Next(0, 2) == 0 ? "Weekday" : "Weekend"
                },
                Schedules = new List<Schedule>()
            };

            for (int j = 0; j < random.Next(1, 6); j++)
            {
                var schedule = new Schedule
                {
                    DayCycleCode = "Cycle " + random.Next(1, 4),
                    TimetableVersion = new TimetableVersion
                    {
                        Id = random.Next(1, 100),
                        Name = random.Next(0, 3) == 0 ? "Version 1" : random.Next(0, 3) == 1 ? "Version 2" : "Version 3"
                    },
                    Periods = new List<Period>()
                };

                for (int k = 0; k < random.Next(1, 6); k++)
                {
                    var period = new Period
                    {
                        DayConfigId = random.Next(1, 100),
                        DayConfigType = new DayConfigType
                        {
                            Code = random.Next(0, 2) == 0 ? "Normal" : "Special",
                            Description = "Description " + random.Next(1, 5)
                        },
                        StartTime = DateTime.Now.AddHours(random.Next(8, 15)).ToString("yyyy-MM-ddTHH:mm:ss"),
                        EndTime = DateTime.Now.AddHours(random.Next(16, 18)).ToString("yyyy-MM-ddTHH:mm:ss"),
                        ItemName = "Subject " + random.Next(1, 10),
                        ShortName = "Short " + random.Next(1, 5),
                        IsTeachingAllocation = random.Next(0, 2) == 1,
                        Classes = new List<Class>()
                    };

                    for (int l = 0; l < random.Next(1, 5); l++)
                    {
                        var cls = new Class
                        {
                            HasAttendanceChanges = random.Next(0, 2) == 1,
                            AttendanceStatus = new AttendanceStatus
                            {
                                Code = random.Next(0, 3) == 0 ? "P" : random.Next(0, 3) == 1 ? "A" : "L",
                                Description = random.Next(0, 3) == 0 ? "Present" : random.Next(0, 3) == 1 ? "Absent" : "Late"
                            },
                            TimetableClassId = random.Next(1, 100),
                            StartTime = DateTime.Now.AddHours(random.Next(8, 15)).ToString("yyyy-MM-ddTHH:mm:ss"),
                            EndTime = DateTime.Now.AddHours(random.Next(16, 18)).ToString("yyyy-MM-ddTHH:mm:ss"),
                            ClassName = "Class " + random.Next(1, 5),
                            Activity = new Activity
                            {
                                Code = "Act" + random.Next(1, 10),
                                Description = "Activity Description " + random.Next(1, 5)
                            },
                            LearningArea = new LearningArea
                            {
                                Code = "Area" + random.Next(1, 10),
                                Description = "Learning Area " + random.Next(1, 5)
                            },
                            Facility = new Facility
                            {
                                Code = "Fac" + random.Next(1, 10),
                                Description = "Facility Description " + random.Next(1, 5)
                            },
                            ClassType = new ClassType
                            {
                                Code = "Type" + random.Next(1, 3),
                                Description = "Class Type Description"
                            },
                            IsCompositeClass = random.Next(0, 2) == 1,
                            IsRollMarkable = random.Next(0, 2) == 1,
                            NotRollMarkableReason = new NotRollMarkableReason
                            {
                                Code = "Reason" + random.Next(1, 3),
                                Description = "No Reason"
                            },
                            IsRollMarked = random.Next(0, 2) == 1,
                            RollMarkedDate = DateTime.Now.AddDays(random.Next(-10, 0)).ToString("yyyy-MM-ddTHH:mm:ss"),
                            RollMarkedUser = "User" + random.Next(1, 5),
                            Session = "Session " + random.Next(1, 3),
                            YearLevel = new YearLevel
                            {
                                Code = "Year" + random.Next(1, 5),
                                Description = "Year Level Description"
                            },
                            Teachers = new List<Teacher>()
                        };

                        for (int m = 0; m < random.Next(1, 4); m++)
                        {
                            cls.Teachers.Add(new Teacher
                            {
                                StaffCentreId = random.Next(1, 100),
                                Title = "Title " + random.Next(1, 3),
                                FamilyName = "Family " + random.Next(1, 5),
                                GivenNames = "Given " + random.Next(1, 5),
                                TimetableCode = "TCode " + random.Next(1, 5)
                            });
                        }

                        period.Classes.Add(cls);
                    }

                    schedule.Periods.Add(period);
                }

                studentSchedule.Schedules.Add(schedule);
            }

            studentSchedulesResponses.Add(studentSchedule);
        }

        // Here you can serialize studentSchedulesResponses to JSON or save it as needed
        // e.g. string json = JsonSerializer.Serialize(studentSchedulesResponses, new JsonSerializerOptions { WriteIndented = true });
    }
}