using System;
using System.Collections.Generic;
using System.Text.Json;

public static class Program
{
    public static string Main()
    {
        var random = new Random();
        var studentSchedulesResponses = new List<StudentSchedulesResponse>();

        for (int i = 0; i < 100; i++)
        {
            var studentSchedulesResponse = new StudentSchedulesResponse
            {
                date = DateTime.UtcNow.AddDays(random.Next(-30, 30)).ToString("o"),
                dayType = new DayType
                {
                    code = "DT" + random.Next(1, 5),
                    description = "Day Type " + random.Next(1, 5)
                },
                schedules = new List<Schedule>
                {
                    new Schedule
                    {
                        dayCycleCode = "DCC" + random.Next(1, 10),
                        timetableVersion = new TimetableVersion
                        {
                            id = random.Next(1, 100),
                            name = "Version " + random.Next(1, 10)
                        },
                        periods = new List<Period>
                        {
                            new Period
                            {
                                dayConfigId = random.Next(1, 50),
                                dayConfigType = new DayConfigType
                                {
                                    code = "Type" + random.Next(1, 5),
                                    description = "Configuration " + random.Next(1, 5),
                                },
                                startTime = DateTime.UtcNow.AddHours(random.Next(0, 10)).ToString("o"),
                                endTime = DateTime.UtcNow.AddHours(random.Next(10, 15)).ToString("o"),
                                itemName = "Item " + random.Next(1, 10),
                                shortName = "SN" + random.Next(1, 10),
                                isTeachingAllocation = random.Next(0, 2) == 1,
                                classes = new List<Class>
                                {
                                    new Class
                                    {
                                        hasAttendanceChanges = random.Next(0, 2) == 1,
                                        attendanceStatus = new AttendanceStatus
                                        {
                                            code = "ASC" + random.Next(1, 5),
                                            description = "Attendance Status " + random.Next(1, 5),
                                        },
                                        timetableClassId = random.Next(1, 100),
                                        startTime = DateTime.UtcNow.AddHours(random.Next(0, 10)).ToString("o"),
                                        endTime = DateTime.UtcNow.AddHours(random.Next(10, 15)).ToString("o"),
                                        className = "Class " + random.Next(1, 10),
                                        activity = new Activity
                                        {
                                            code = "ACT" + random.Next(1, 5),
                                            description = "Activity " + random.Next(1, 5)
                                        },
                                        learningArea = new LearningArea
                                        {
                                            code = "LA" + random.Next(1, 5),
                                            description = "Learning Area " + random.Next(1, 5)
                                        },
                                        facility = new Facility
                                        {
                                            code = "FAC" + random.Next(1, 5),
                                            description = "Facility " + random.Next(1, 5)
                                        },
                                        classType = new ClassType
                                        {
                                            code = "CT" + random.Next(1, 5),
                                            description = "Class Type " + random.Next(1, 5)
                                        },
                                        isCompositeClass = random.Next(0, 2) == 1,
                                        isRollMarkable = random.Next(0, 2) == 1,
                                        notRollMarkableReason = new NotRollMarkableReason
                                        {
                                            code = "NR" + random.Next(1, 5),
                                            description = "Reason " + random.Next(1, 5)
                                        },
                                        isRollMarked = random.Next(0, 2) == 1,
                                        rollMarkedDate = random.Next(0, 2) == 1 ? DateTime.UtcNow.ToString("o") : null,
                                        rollMarkedUser = random.Next(0, 2) == 1 ? "User" + random.Next(1, 10) : null,
                                        session = "Session " + random.Next(1, 10),
                                        yearLevel = new YearLevel
                                        {
                                            code = "YL" + random.Next(1, 5),
                                            description = "Year Level " + random.Next(1, 5)
                                        },
                                        teachers = new List<Teacher>
                                        {
                                            new Teacher
                                            {
                                                staffCentreId = random.Next(1, 100),
                                                title = "Title " + random.Next(1, 5),
                                                familyName = "Family " + random.Next(1, 10),
                                                givenNames = "Given " + random.Next(1, 10),
                                                timetableCode = "TC" + random.Next(1, 5)
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            studentSchedulesResponses.Add(studentSchedulesResponse);
        }

        return JsonSerializer.Serialize(studentSchedulesResponses);
    }
}

public class StudentSchedulesResponse
{
    public string date { get; set; }
    public DayType dayType { get; set; }
    public List<Schedule> schedules { get; set; }
}

public class DayType
{
    public string code { get; set; }
    public string description { get; set; }
}

public class Schedule
{
    public string dayCycleCode { get; set; }
    public TimetableVersion timetableVersion { get; set; }
    public List<Period> periods { get; set; }
}

public class TimetableVersion
{
    public int id { get; set; }
    public string name { get; set; }
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

public class DayConfigType
{
    public string code { get; set; }
    public string description { get; set; }
}

public class Class
{
    public bool hasAttendanceChanges { get; set; }
    public AttendanceStatus attendanceStatus { get; set; }
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

public class AttendanceStatus
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

public class ClassType
{
    public string code { get; set; }
    public string description { get; set; }
}

public class NotRollMarkableReason
{
    public string code { get; set; }
    public string description { get; set; }
}

public class YearLevel
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

string json = Program.Main();