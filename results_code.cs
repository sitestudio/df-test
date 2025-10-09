using System;
using System.Collections.Generic;
using System.Text.Json;

public class DayType
{
    public string Code { get; set; }
    public string Description { get; set; }
}

public class TimetableVersion
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Class
{
    public bool HasAttendanceChanges { get; set; }
    public AttendanceStatus AttendanceStatus { get; set; }
    public int TimetableClassId { get; set; }
    public string StartTime { get; set; } // DateTime as string
    public string EndTime { get; set; } // DateTime as string
    public string ClassName { get; set; }
    public Activity Activity { get; set; }
    public LearningArea LearningArea { get; set; }
    public Facility Facility { get; set; }
    public ClassType ClassType { get; set; }
    public bool IsCompositeClass { get; set; }
    public bool IsRollMarkable { get; set; }
    public string RollMarkedDate { get; set; } // DateTime as string
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

public class YearLevel
{
    public string Code { get; set; }
    public string Description { get; set; }
}

public class Period
{
    public int DayConfigId { get; set; }
    public DayConfigType DayConfigType { get; set; }
    public string StartTime { get; set; } // DateTime as string
    public string EndTime { get; set; } // DateTime as string
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

public class Schedule
{
    public string DayCycleCode { get; set; }
    public TimetableVersion TimetableVersion { get; set; }
    public List<Period> Periods { get; set; }
}

public class StudentSchedulesResponse
{
    public string Date { get; set; } // DateTime as string
    public DayType DayType { get; set; }
    public List<Schedule> Schedules { get; set; }
}

public class Program
{
    public static void Main()
    {
        var studentSchedulesResponses = new List<StudentSchedulesResponse>();
        var random = new Random();

        for (int i = 0; i < 100; i++)
        {
            studentSchedulesResponses.Add(new StudentSchedulesResponse
            {
                Date = DateTime.Now.AddDays(random.Next(-10, 10)).ToString("o"), // ISO 8601 format
                DayType = new DayType
                {
                    Code = "DAY" + random.Next(1, 10),
                    Description = "Description for Day Type " + random.Next(1, 10)
                },
                Schedules = new List<Schedule>
                {
                    new Schedule
                    {
                        DayCycleCode = "CYCLE" + random.Next(1, 10),
                        TimetableVersion = new TimetableVersion
                        {
                            Id = random.Next(1, 100),
                            Name = "Version " + random.Next(1, 10)
                        },
                        Periods = new List<Period>
                        {
                            new Period
                            {
                                DayConfigId = random.Next(1, 100),
                                DayConfigType = new DayConfigType
                                {
                                    Code = "TYPE" + random.Next(1, 5),
                                    Description = "Description for Type " + random.Next(1, 5)
                                },
                                StartTime = DateTime.Now.AddHours(random.Next(1, 8)).ToString("o"),
                                EndTime = DateTime.Now.AddHours(random.Next(9, 16)).ToString("o"),
                                ItemName = "Item " + random.Next(1, 20),
                                ShortName = "Short " + random.Next(1, 20),
                                IsTeachingAllocation = random.Next(0, 2) == 1,
                                Classes = new List<Class>
                                {
                                    new Class
                                    {
                                        HasAttendanceChanges = random.Next(0, 2) == 1,
                                        AttendanceStatus = new AttendanceStatus
                                        {
                                            Code = "ATT" + random.Next(1, 5),
                                            Description = "Attendance Status " + random.Next(1, 5)
                                        },
                                        TimetableClassId = random.Next(1, 100),
                                        StartTime = DateTime.Now.AddHours(random.Next(1, 8)).ToString("o"),
                                        EndTime = DateTime.Now.AddHours(random.Next(9, 16)).ToString("o"),
                                        ClassName = "Class " + random.Next(1, 20),
                                        Activity = new Activity
                                        {
                                            Code = "ACT" + random.Next(1, 5),
                                            Description = "Activity " + random.Next(1, 5)
                                        },
                                        LearningArea = new LearningArea
                                        {
                                            Code = "LEARN" + random.Next(1, 5),
                                            Description = "Learning Area " + random.Next(1, 5)
                                        },
                                        Facility = new Facility
                                        {
                                            Code = "FAC" + random.Next(1, 5),
                                            Description = "Facility " + random.Next(1, 5)
                                        },
                                        ClassType = new ClassType
                                        {
                                            Code = "CLASS" + random.Next(1, 5),
                                            Description = "Class Type " + random.Next(1, 5)
                                        },
                                        IsCompositeClass = random.Next(0, 2) == 1,
                                        IsRollMarkable = random.Next(0, 2) == 1,
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }

        json = JsonSerializer.Serialize(studentSchedulesResponses);
    }
}