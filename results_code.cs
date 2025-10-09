using System;
using System.Collections.Generic;
using System.Text.Json;

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
    public object NotRollMarkableReason { get; set; }
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
        var studentSchedulesResponses = new List<StudentSchedulesResponse>();
        var random = new Random();

        for (int i = 0; i < 100; i++)
        {
            var studentSchedule = new StudentSchedulesResponse
            {
                Date = DateTime.UtcNow.AddDays(random.Next(-365, 0)).ToString("o"),
                DayType = new DayType
                {
                    Code = "DAY" + random.Next(1, 5),
                    Description = "Day type " + random.Next(1, 5)
                },
                Schedules = new List<Schedule>
                {
                    new Schedule
                    {
                        DayCycleCode = "Cycle" + random.Next(1, 10),
                        TimetableVersion = new TimetableVersion
                        {
                            Id = random.Next(1, 100),
                            Name = "Version " + random.Next(1, 10)
                        },
                        Periods = new List<Period>
                        {
                            new Period
                            {
                                DayConfigId = random.Next(1, 1000),
                                DayConfigType = new DayConfigType
                                {
                                    Code = "Config" + random.Next(1, 5),
                                    Description = "Config description " + random.Next(1, 5)
                                },
                                StartTime = DateTime.UtcNow.AddHours(random.Next(0, 24)).ToString("o"),
                                EndTime = DateTime.UtcNow.AddHours(random.Next(0, 24)).ToString("o"),
                                ItemName = "Item " + random.Next(1, 100),
                                ShortName = "Short " + random.Next(1, 100),
                                IsTeachingAllocation = random.Next(0, 2) == 0,
                                Classes = new List<Class>
                                {
                                    new Class
                                    {
                                        HasAttendanceChanges = random.Next(0, 2) == 0,
                                        AttendanceStatus = new AttendanceStatus
                                        {
                                            Code = "Status" + random.Next(1, 3),
                                            Description = "Attendance status description " + random.Next(1, 3)
                                        },
                                        TimetableClassId = random.Next(1, 1000),
                                        StartTime = DateTime.UtcNow.AddHours(random.Next(0, 24)).ToString("o"),
                                        EndTime = DateTime.UtcNow.AddHours(random.Next(0, 24)).ToString("o"),
                                        ClassName = "Class " + random.Next(1, 100),
                                        Activity = new Activity
                                        {
                                            Code = "Activity" + random.Next(1, 5),
                                            Description = "Activity description " + random.Next(1, 5)
                                        },
                                        LearningArea = new LearningArea
                                        {
                                            Code = "Area" + random.Next(1, 5),
                                            Description = "Learning Area description " + random.Next(1, 5)
                                        },
                                        Facility = new Facility
                                        {
                                            Code = "Facility" + random.Next(1, 5),
                                            Description = "Facility description " + random.Next(1, 5)
                                        },
                                        ClassType = new ClassType
                                        {
                                            Code = "Type" + random.Next(1, 5),
                                            Description = "Class type " + random.Next(1, 5)
                                        },
                                        IsCompositeClass = random.Next(0, 2) == 0,
                                        IsRollMarkable = random.Next(0, 2) == 0,
                                        NotRollMarkableReason = null,  // Set a random object or leave null
                                        IsRollMarked = random.Next(0, 2) == 0,
                                        RollMarkedDate = random.Next(0, 2) == 0 ? DateTime.UtcNow.ToString("o") : null,
                                        RollMarkedUser = random.Next(0, 2) == 0 ? "User " + random.Next(1, 100) : null,
                                        Session = "Session " + random.Next(1, 5),
                                        YearLevel = new YearLevel
                                        {
                                            Code = "Year" + random.Next(1, 5),
                                            Description = "Year level description " + random.Next(1, 5)
                                        },
                                        Teachers = new List<Teacher>
                                        {
                                            new Teacher
                                            {
                                                StaffCentreId = random.Next(1, 1000),
                                                Title = "Mr.",
                                                FamilyName = "FamilyName" + random.Next(1, 100),
                                                GivenNames = "GivenName" + random.Next(1, 100),
                                                TimetableCode = "TCode" + random.Next(1, 5)
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            studentSchedulesResponses.Add(studentSchedule);
        }

        // Serialize the list of student schedules to JSON
        var jsonOutput = JsonSerializer.Serialize(studentSchedulesResponses, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(jsonOutput);
    }
}