using System;
using System.Collections.Generic;
using System.Text.Json;

public class GeneratedCode
{
    public static void Main(string[] args)
    {
        var studentSchedules = GenerateSampleStudentSchedules(100);
        var json = JsonSerializer.Serialize(studentSchedules, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(json);
    }

    private static List<StudentSchedulesResponse> GenerateSampleStudentSchedules(int count)
    {
        var random = new Random();
        var schedules = new List<StudentSchedulesResponse>();
        
        for (int i = 0; i < count; i++)
        {
            schedules.Add(new StudentSchedulesResponse
            {
                date = DateTime.Now.AddDays(random.Next(-365, 365)).ToString("o"),
                dayType = new DayType 
                {
                    code = "DT" + random.Next(1, 5),
                    description = "Description for day type " + random.Next(1, 5)
                },
                schedules = GenerateSampleSchedules(random)
            });
        }
        return schedules;
    }

    private static List<Schedule> GenerateSampleSchedules(Random random)
    {
        int numberOfSchedules = random.Next(1, 5);
        var scheduleList = new List<Schedule>();

        for (int j = 0; j < numberOfSchedules; j++)
        {
            scheduleList.Add(new Schedule
            {
                dayCycleCode = "DCC" + random.Next(1, 10),
                timetableVersion = new TimetableVersion
                {
                    id = random.Next(1, 100),
                    name = "Version " + random.Next(1, 20)
                },
                periods = GenerateSamplePeriods(random)
            });
        }
        return scheduleList;
    }

    private static List<Period> GenerateSamplePeriods(Random random)
    {
        int numberOfPeriods = random.Next(1, 8);
        var periodList = new List<Period>();

        for (int k = 0; k < numberOfPeriods; k++)
        {
            periodList.Add(new Period
            {
                dayConfigId = random.Next(1, 1000),
                dayConfigType = new DayConfigType
                {
                    code = "DCT" + random.Next(1, 5),
                    description = "Description for day config type " + random.Next(1, 5)
                },
                startTime = DateTime.Now.AddHours(random.Next(-12, 12)).ToString("o"),
                endTime = DateTime.Now.AddHours(random.Next(1, 12)).ToString("o"),
                itemName = "Item " + random.Next(1, 100),
                shortName = "Short " + random.Next(1, 100),
                isTeachingAllocation = random.Next(0, 2) == 1,
                classes = GenerateSampleClasses(random)
            });
        }
        return periodList;
    }

    private static List<Class> GenerateSampleClasses(Random random)
    {
        int numberOfClasses = random.Next(1, 5);
        var classList = new List<Class>();

        for (int l = 0; l < numberOfClasses; l++)
        {
            classList.Add(new Class
            {
                hasAttendanceChanges = random.Next(0, 2) == 1,
                attendanceStatus = new AttendanceStatus
                {
                    code = "AS" + random.Next(1, 5),
                    description = "Attendance status description " + random.Next(1, 5)
                },
                timetableClassId = random.Next(1, 1000),
                startTime = DateTime.Now.AddHours(random.Next(-12, 12)).ToString("o"),
                endTime = DateTime.Now.AddHours(random.Next(1, 12)).ToString("o"),
                className = "Class " + random.Next(1, 100),
                activity = new Activity
                {
                    code = "Activity" + random.Next(1, 5),
                    description = "Activity description " + random.Next(1, 5)
                },
                learningArea = new LearningArea
                {
                    code = "LA" + random.Next(1, 5),
                    description = "Learning area description " + random.Next(1, 5)
                },
                facility = new Facility
                {
                    code = "FC" + random.Next(1, 5),
                    description = "Facility description " + random.Next(1, 5)
                },
                classType = new ClassType
                {
                    code = "CT" + random.Next(1, 5),
                    description = "Class type description " + random.Next(1, 5)
                },
                isCompositeClass = random.Next(0, 2) == 1,
                isRollMarkable = random.Next(0, 2) == 1,
                notRollMarkableReason = new NotRollMarkableReason
                {
                    code = "NR" + random.Next(1, 5),
                    description = "Not roll markable reason " + random.Next(1, 5)
                },
                isRollMarked = random.Next(0, 2) == 1,
                rollMarkedDate = random.Next(0, 2) == 0 ? (DateTime?)null : DateTime.Now.ToString("o"),
                rollMarkedUser = random.Next(0, 2) == 0 ? null : "User" + random.Next(1, 10),
                session = "Session " + random.Next(1, 5),
                yearLevel = new YearLevel
                {
                    code = "YL" + random.Next(1, 5),
                    description = "Year level description " + random.Next(1, 5)
                },
                teachers = GenerateSampleTeachers(random)
            });
        }
        return classList;
    }

    private static List<Teacher> GenerateSampleTeachers(Random random)
    {
        int numberOfTeachers = random.Next(1, 4);
        var teacherList = new List<Teacher>();

        for (int m = 0; m < numberOfTeachers; m++)
        {
            teacherList.Add(new Teacher
            {
                staffCentreId = random.Next(1, 100),
                title = "Dr.",
                familyName = "Family" + random.Next(1, 100),
                givenNames = "Given" + random.Next(1, 100),
                timetableCode = "TC" + random.Next(1, 5),
            });
        }
        return teacherList;
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