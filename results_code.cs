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

public class Period
{
    public int DayConfigId { get; set; }
    public DayType DayConfigType { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string ItemName { get; set; }
    public string ShortName { get; set; }
    public bool IsTeachingAllocation { get; set; }
    public List<Class> Classes { get; set; }
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

public class StudentSchedulesResponse
{
    public string Date { get; set; }
    public DayType DayType { get; set; }
    public List<Schedule> Schedules { get; set; }
}

public class Schedule
{
    public string DayCycleCode { get; set; }
    public TimetableVersion TimetableVersion { get; set; }
    public List<Period> Periods { get; set; }
}

public class Program
{
    public static void Main()
    {
        var studentSchedules = new List<StudentSchedulesResponse>();
        var random = new Random();

        for (int i = 0; i < 100; i++)
        {
            var studentSchedule = new StudentSchedulesResponse
            {
                Date = DateTime.Now.AddDays(random.Next(0, 30)).ToString("o"),
                DayType = new DayType
                {
                    Code = "DayType" + i,
                    Description = "Description for DayType " + i
                },
                Schedules = new List<Schedule>
                {
                    new Schedule
                    {
                        DayCycleCode = "Cycle" + i,
                        TimetableVersion = new TimetableVersion
                        {
                            Id = random.Next(1, 10),
                            Name = "Version " + i
                        },
                        Periods = new List<Period>
                        {
                            new Period
                            {
                                DayConfigId = random.Next(1, 10),
                                DayConfigType = new DayType { Code = "Config" + i, Description = "Day Config Type " + i },
                                StartTime = DateTime.Now.AddHours(random.Next(0, 24)).ToString("o"),
                                EndTime = DateTime.Now.AddHours(random.Next(0, 24)).ToString("o"),
                                ItemName = "Item " + i,
                                ShortName = "Short " + i,
                                IsTeachingAllocation = random.Next(0, 2) == 0,
                                Classes = new List<Class>
                                {
                                    new Class
                                    {
                                        HasAttendanceChanges = random.Next(0, 2) == 0,
                                        AttendanceStatus = new AttendanceStatus { Code = "Status" + i, Description = "Status Description" },
                                        TimetableClassId = random.Next(1, 100),
                                        StartTime = DateTime.Now.AddHours(random.Next(0, 24)).ToString("o"),
                                        EndTime = DateTime.Now.AddHours(random.Next(0, 24)).ToString("o"),
                                        ClassName = "Class " + i,
                                        Activity = new Activity { Code = "Activity" + i, Description = "Activity Description" },
                                        LearningArea = new LearningArea { Code = "Learning" + i, Description = "Learning Description" },
                                        Facility = new Facility { Code = "Facility" + i, Description = "Facility Description" },
                                        ClassType = new ClassType { Code = "ClassType" + i, Description = "Class Type Description" },
                                        IsCompositeClass = random.Next(0, 2) == 0,
                                        IsRollMarkable = random.Next(0, 2) == 0,
                                        IsRollMarked = random.Next(0, 2) == 0,
                                        RollMarkedDate = DateTime.Now.AddDays(random.Next(-30, 0)).ToString("o"),
                                        RollMarkedUser = "User" + i,
                                        Session = "Session" + i,
                                        YearLevel = new YearLevel { Code = "Year" + i, Description = "Year Description" },
                                        Teachers = new List<Teacher>
                                        {
                                            new Teacher
                                            {
                                                StaffCentreId = random.Next(1, 100),
                                                Title = "Title" + i,
                                                FamilyName = "Family" + i,
                                                GivenNames = "Given" + i,
                                                TimetableCode = "Code" + i
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            studentSchedules.Add(studentSchedule);
        }

        var json = JsonSerializer.Serialize(studentSchedules);
        Console.WriteLine(json); // Here json is printed
    }

    public static string json;
}