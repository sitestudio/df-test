using System;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static string Main()
    {
        var studentSchedulesResponses = new List<StudentSchedulesResponse>();
        
        for (int i = 0; i < 100; i++)
        {
            var response = new StudentSchedulesResponse
            {
                date = DateTime.Now.AddDays(i).ToString("o"), // ISO 8601 format
                dayType = new DayType
                {
                    code = "D",
                    description = "Regular Day"
                },
                schedules = new List<Schedule>
                {
                    new Schedule
                    {
                        dayCycleCode = "A",
                        timetableVersion = new TimetableVersion
                        {
                            id = i,
                            name = "Version " + i
                        },
                        periods = new List<Period>
                        {
                            new Period
                            {
                                dayConfigId = i,
                                dayConfigType = new DayConfigType
                                {
                                    code = "L",
                                    description = "Lecture"
                                },
                                startTime = DateTime.Now.AddHours(i).ToString("o"),
                                endTime = DateTime.Now.AddHours(i + 1).ToString("o"),
                                itemName = "Math " + i,
                                shortName = "M" + i,
                                isTeachingAllocation = true,
                                classes = new List<Class>
                                {
                                    new Class
                                    {
                                        hasAttendanceChanges = false,
                                        attendanceStatus = new AttendanceStatus
                                        {
                                            code = "A",
                                            description = "Present"
                                        },
                                        timetableClassId = i,
                                        startTime = DateTime.Now.AddHours(i).ToString("o"),
                                        endTime = DateTime.Now.AddHours(i + 1).ToString("o"),
                                        className = "Class " + i,
                                        activity = new Activity
                                        {
                                            code = "ACT" + i,
                                            description = "Activity " + i
                                        },
                                        learningArea = new LearningArea
                                        {
                                            code = "MATH",
                                            description = "Mathematics"
                                        },
                                        facility = new Facility
                                        {
                                            code = "R101",
                                            description = "Room 101"
                                        },
                                        classType = new ClassType
                                        {
                                            code = "C",
                                            description = "Core"
                                        },
                                        isCompositeClass = false,
                                        isRollMarkable = true,
                                        notRollMarkableReason = null,
                                        isRollMarked = true,
                                        rollMarkedDate = DateTime.Now.ToString("o"),
                                        rollMarkedUser = "admin",
                                        session = "Session " + i,
                                        yearLevel = new YearLevel
                                        {
                                            code = "Y" + (i % 12),
                                            description = "Year " + (i % 12)
                                        },
                                        teachers = new List<Teacher>
                                        {
                                            new Teacher
                                            {
                                                staffCentreId = i,
                                                title = "Mr.",
                                                familyName = "Smith",
                                                givenNames = "John",
                                                timetableCode = "T" + i
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            studentSchedulesResponses.Add(response);
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
    public object notRollMarkableReason { get; set; }
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