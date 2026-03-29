using System;
using System.Collections.Generic;
using System.Text.Json;

public class DayType
{
    public string code { get; set; }
    public string description { get; set; }
}

public class TimetableVersion
{
    public int id { get; set; }
    public string name { get; set; }
}

public class DayConfigType
{
    public string code { get; set; }
    public string description { get; set; }
}

public class ClassType
{
    public string code { get; set; }
    public string description { get; set; }
}

public class YearLevel
{
    public string code { get; set; }
    public string description { get; set; }
}

public class Activity
{
    public string code { get; set; }
    public string description { get; set; }
}

public class LearningArea
{
    public string code { get; set; }
    public string description { get; set; }
}

public class Facility
{
    public string code { get; set; }
    public string description { get; set; }
}

public class NotRollMarkableReason
{
    public string code { get; set; }
    public string description { get; set; }
}

public class Teacher
{
    public int staffCentreId { get; set; }
    public string title { get; set; }
    public string familyName { get; set; }
    public string givenNames { get; set; }
    public string timetableCode { get; set; }
}

public class Class
{
    public bool hasAttendanceChanges { get; set; }
    public object attendanceStatus { get; set; } // Can be 'null' so keep it as object for now
    public int timetableClassId { get; set; }
    public string startTime { get; set; }
    public string endTime { get; set; }
    public string className { get; set; }
    public Activity activity { get; set; }
    public LearningArea learningArea { get; set; }
    public Facility facility { get; set; }
    public ClassType classType { get; set; }
    public bool isCompositeClass { get; set; }
    public bool isRollMarkable { get; set; }
    public NotRollMarkableReason notRollMarkableReason { get; set; }
    public bool isRollMarked { get; set; }
    public string rollMarkedDate { get; set; }
    public string rollMarkedUser { get; set; }
    public string session { get; set; }
    public YearLevel yearLevel { get; set; }
    public List<Teacher> teachers { get; set; }
}

public class Period
{
    public int dayConfigId { get; set; }
    public DayConfigType dayConfigType { get; set; }
    public string startTime { get; set; }
    public string endTime { get; set; }
    public string itemName { get; set; }
    public string shortName { get; set; }
    public bool isTeachingAllocation { get; set; }
    public List<Class> classes { get; set; }
}

public class Schedule
{
    public string dayCycleCode { get; set; }
    public TimetableVersion timetableVersion { get; set; }
    public List<Period> periods { get; set; }
}

public class StudentSchedulesResponse
{
    public string date { get; set; }
    public DayType dayType { get; set; }
    public List<Schedule> schedules { get; set; }
}

public static class Program
{
    public static string Main()
    {
        var responses = new List<StudentSchedulesResponse>();
        var random = new Random();

        for (int i = 0; i < 100; i++)
        {
            var response = new StudentSchedulesResponse
            {
                date = DateTime.UtcNow.AddDays(i).ToString("o"),
                dayType = new DayType
                {
                    code = "Weekday",
                    description = "Regular school day"
                },
                schedules = new List<Schedule>
                {
                    new Schedule
                    {
                        dayCycleCode = "A",
                        timetableVersion = new TimetableVersion
                        {
                            id = random.Next(1, 100),
                            name = "Version " + random.Next(1, 10)
                        },
                        periods = new List<Period>
                        {
                            new Period
                            {
                                dayConfigId = random.Next(1, 10),
                                dayConfigType = new DayConfigType
                                {
                                    code = "Standard",
                                    description = "Standard day configuration"
                                },
                                startTime = DateTime.UtcNow.ToString("o"),
                                endTime = DateTime.UtcNow.AddHours(1).ToString("o"),
                                itemName = "Period " + (i + 1),
                                shortName = "P" + (i + 1),
                                isTeachingAllocation = true,
                                classes = new List<Class>
                                {
                                    new Class
                                    {
                                        hasAttendanceChanges = random.Next(0, 2) == 1,
                                        attendanceStatus = null,
                                        timetableClassId = random.Next(1, 1000),
                                        startTime = DateTime.UtcNow.ToString("o"),
                                        endTime = DateTime.UtcNow.AddHours(1).ToString("o"),
                                        className = "Class " + (i + 1),
                                        activity = new Activity { code = "ACT", description = "Class activity" },
                                        learningArea = new LearningArea { code = "LA", description = "Learning area" },
                                        facility = new Facility { code = "FAC", description = "Facility" },
                                        classType = new ClassType { code = "CT", description = "Class type" },
                                        isCompositeClass = false,
                                        isRollMarkable = true,
                                        notRollMarkableReason = null,
                                        isRollMarked = false,
                                        rollMarkedDate = null,
                                        rollMarkedUser = null,
                                        session = "Session " + (i + 1),
                                        yearLevel = new YearLevel { code = "YL", description = "Year level" },
                                        teachers = new List<Teacher>
                                        {
                                            new Teacher
                                            {
                                                staffCentreId = random.Next(1, 100),
                                                title = "Mr.",
                                                familyName = "Smith",
                                                givenNames = "John",
                                                timetableCode = "T" + (i + 1)
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            responses.Add(response);
        }
        return JsonSerializer.Serialize(responses);
    }
}

string json = Program.Main();