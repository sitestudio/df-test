using System;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        var studentSchedules = new List<StudentSchedulesResponse>();

        for (int i = 0; i < 100; i++)
        {
            var studentSchedule = new StudentSchedulesResponse
            {
                date = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                dayType = new DayType
                {
                    code = "DT" + i,
                    description = "Description for day type " + i
                },
                schedules = new List<Schedule>
                {
                    new Schedule
                    {
                        dayCycleCode = "DCC" + i,
                        timetableVersion = new TimetableVersion
                        {
                            id = 1,
                            name = "Version 1"
                        },
                        periods = new List<Period>
                        {
                            new Period
                            {
                                dayConfigId = i,
                                dayConfigType = new DayConfigType
                                {
                                    code = "DCT" + i,
                                    description = "Description for day config type " + i
                                },
                                startTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                                endTime = DateTime.UtcNow.AddHours(1).ToString("yyyy-MM-ddTHH:mm:ssZ"),
                                itemName = "Item " + i,
                                shortName = "Short " + i,
                                isTeachingAllocation = true,
                                classes = new List<Class>
                                {
                                    new Class
                                    {
                                        hasAttendanceChanges = false,
                                        attendanceStatus = new AttendanceStatus
                                        {
                                            code = "AS" + i,
                                            description = "Attendance status for class " + i
                                        },
                                        timetableClassId = i,
                                        startTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                                        endTime = DateTime.UtcNow.AddHours(1).ToString("yyyy-MM-ddTHH:mm:ssZ"),
                                        className = "Class " + i,
                                        activity = new Activity
                                        {
                                            code = "ACT" + i,
                                            description = "Description for activity " + i
                                        },
                                        learningArea = new LearningArea
                                        {
                                            code = "LA" + i,
                                            description = "Description for learning area " + i
                                        },
                                        facility = new Facility
                                        {
                                            code = "FAC" + i,
                                            description = "Description for facility " + i
                                        },
                                        classType = new ClassType
                                        {
                                            code = "CT" + i,
                                            description = "Description for class type " + i
                                        },
                                        isCompositeClass = false,
                                        isRollMarkable = true,
                                        notRollMarkableReason = new NotRollMarkableReason
                                        {
                                            code = "NR" + i,
                                            description = "Not roll markable reason " + i
                                        },
                                        isRollMarked = false,
                                        rollMarkedDate = null,
                                        rollMarkedUser = null,
                                        session = "Session " + i,
                                        yearLevel = new YearLevel
                                        {
                                            code = "YL" + i,
                                            description = "Description for year level " + i
                                        },
                                        teachers = new List<Teacher>
                                        {
                                            new Teacher
                                            {
                                                staffCentreId = i,
                                                title = "Title " + i,
                                                familyName = "Family " + i,
                                                givenNames = "Given " + i,
                                                timetableCode = "TC" + i
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
        Console.WriteLine(json);
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