using System;
using System.Collections.Generic;
using System.Text.Json;

class Schedule
{
    public string dayCycleCode { get; set; }
    public TimetableVersion timetableVersion { get; set; }
    public List<Period> periods { get; set; }
}

class TimetableVersion
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Period
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

class DayConfigType
{
    public string Code { get; set; }
    public string Description { get; set; }
}

class Class
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
}

class AttendanceStatus
{
    public string Code { get; set; }
    public string Description { get; set; }
}

class Activity
{
    public string Code { get; set; }
    public string Description { get; set; }
}

class LearningArea
{
    public string Code { get; set; }
    public string Description { get; set; }
}

class Facility
{
    public string Code { get; set; }
    public string Description { get; set; }
}

class ClassType
{
    public string Code { get; set; }
    public string Description { get; set; }
}

class StudentSchedulesResponse
{
    public string date { get; set; }
    public DayType dayType { get; set; }
    public List<Schedule> schedules { get; set; }
}

class DayType
{
    public string Code { get; set; }
    public string Description { get; set; }
}

static void Main()
{
    var response = new StudentSchedulesResponse
    {
        date = "2023-01-01T00:00:00",
        dayType = new DayType
        {
            Code = "WEEKDAY",
            Description = "Regular Day"
        },
        schedules = new List<Schedule>
        {
            new Schedule
            {
                dayCycleCode = "A",
                timetableVersion = new TimetableVersion { Id = 1, Name = "Version 1" },
                periods = new List<Period>
                {
                    new Period
                    {
                        dayConfigId = 1,
                        dayConfigType = new DayConfigType { Code = "TYPE1", Description = "Description 1" },
                        startTime = "2023-01-02T08:00:00",
                        endTime = "2023-01-02T09:00:00",
                        itemName = "Math",
                        shortName = "M",
                        isTeachingAllocation = true,
                        classes = new List<Class>
                        {
                            new Class
                            {
                                hasAttendanceChanges = true,
                                attendanceStatus = new AttendanceStatus { Code = "P", Description = "Present" },
                                timetableClassId = 1,
                                startTime = "2023-01-02T08:00:00",
                                endTime = "2023-01-02T09:00:00",
                                className = "Math 101",
                                activity = new Activity { Code = "LEC", Description = "Lecture" },
                                learningArea = new LearningArea { Code = "MA", Description = "Mathematics" },
                                facility = new Facility { Code = "RM101", Description = "Room 101" },
                                classType = new ClassType { Code = "REG", Description = "Regular" },
                                isCompositeClass = false,
                                isRollMarkable = true,
                                notRollMarkableReason = new NotRollMarkableReason { Code = "REASON1", Description = "Reason 1" },
                                isRollMarked = true,
                                rollMarkedDate = "2023-01-01T00:00:00",
                                rollMarkedUser = "User1",
                                session = "SESSION1",
                                yearLevel = new YearLevel { Code = "YEAR1", Description = "Year 1" }
                            }
                        }
                    }
                }
            }
        }
    };

    var jsonString = JsonSerializer.Serialize(response);
    Console.WriteLine(jsonString);
}