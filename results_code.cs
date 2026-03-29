using System;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        var studentSchedulesResponseList = new List<StudentSchedulesResponse>();

        for (int i = 0; i < 100; i++)
        {
            var studentSchedulesResponse = new StudentSchedulesResponse
            {
                Date = DateTime.UtcNow.AddDays(i).ToString("yyyy-MM-ddTHH:mm:ssZ"),
                DayType = new DayType
                {
                    Code = $"DayTypeCode{RandomString(5)}",
                    Description = $"Description for Day Type {i}"
                },
                Schedules = GenerateSchedules(i)
            };
            studentSchedulesResponseList.Add(studentSchedulesResponse);
        }

        string json = JsonSerializer.Serialize(studentSchedulesResponseList, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(json);
    }

    private static List<Schedule> GenerateSchedules(int index)
    {
        var schedules = new List<Schedule>();
        for (int j = 0; j < 3; j++) // Generating 3 schedules per response
        {
            schedules.Add(new Schedule
            {
                DayCycleCode = $"CycleCode{index}-{j}",
                TimetableVersion = new TimetableVersion
                {
                    Id = index * 10 + j,
                    Name = $"TimetableVersionName{index}-{j}"
                },
                Periods = GeneratePeriods(index, j)
            });
        }
        return schedules;
    }

    private static List<Period> GeneratePeriods(int index, int scheduleIndex)
    {
        var periods = new List<Period>();
        for (int k = 0; k < 2; k++) // Generating 2 periods per schedule
        {
            periods.Add(new Period
            {
                DayConfigId = index * 100 + scheduleIndex * 10 + k,
                DayConfigType = new DayConfigType
                {
                    Code = $"ConfigCode{index}{scheduleIndex}{k}",
                    Description = $"Description for Config {index}{scheduleIndex}{k}"
                },
                StartTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                EndTime = DateTime.UtcNow.AddHours(1).ToString("yyyy-MM-ddTHH:mm:ssZ"),
                ItemName = $"ItemName{index}-{scheduleIndex}-{k}",
                ShortName = $"ShortName{index}-{scheduleIndex}-{k}",
                IsTeachingAllocation = (k % 2 == 0),
                Classes = GenerateClasses(index, scheduleIndex, k)
            });
        }
        return periods;
    }

    private static List<Class> GenerateClasses(int index, int scheduleIndex, int periodIndex)
    {
        var classes = new List<Class>();
        for (int m = 0; m < 2; m++) // Generating 2 classes per period
        {
            classes.Add(new Class
            {
                HasAttendanceChanges = (m % 2 == 0),
                AttendanceStatus = new AttendanceStatus
                {
                    Code = $"StatusCode{index}-{scheduleIndex}-{periodIndex}-{m}",
                    Description = $"Attendance Status {index}-{scheduleIndex}-{periodIndex}-{m}"
                },
                TimetableClassId = index * 1000 + scheduleIndex * 100 + periodIndex * 10 + m,
                StartTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                EndTime = DateTime.UtcNow.AddHours(1).ToString("yyyy-MM-ddTHH:mm:ssZ"),
                ClassName = $"ClassName{index}-{scheduleIndex}-{periodIndex}-{m}",
                Activity = new Activity
                {
                    Code = $"ActivityCode{index}-{scheduleIndex}-{periodIndex}-{m}",
                    Description = $"Activity Description {index}-{scheduleIndex}-{periodIndex}-{m}"
                },
                LearningArea = new LearningArea
                {
                    Code = $"LearningAreaCode{index}-{scheduleIndex}-{periodIndex}-{m}",
                    Description = $"Learning Area Description {index}-{scheduleIndex}-{periodIndex}-{m}"
                },
                Facility = new Facility
                {
                    Code = $"FacilityCode{index}-{scheduleIndex}-{periodIndex}-{m}",
                    Description = $"Facility Description {index}-{scheduleIndex}-{periodIndex}-{m}"
                },
                ClassType = new ClassType
                {
                    Code = $"ClassTypeCode{index}-{scheduleIndex}-{periodIndex}-{m}",
                    Description = $"Class Type Description {index}-{scheduleIndex}-{periodIndex}-{m}"
                },
                IsCompositeClass = (m % 2 == 0),
                IsRollMarkable = true,
                NotRollMarkableReason = new NotRollMarkableReason
                {
                    Code = $"ReasonCode{index}-{scheduleIndex}-{periodIndex}-{m}",
                    Description = $"Reason Description {index}-{scheduleIndex}-{periodIndex}-{m}"
                },
                IsRollMarked = false,
                RollMarkedDate = null,
                RollMarkedUser = null,
                Session = $"Session{index}-{scheduleIndex}-{periodIndex}-{m}",
                YearLevel = new YearLevel
                {
                    Code = $"YearLevelCode{index}-{scheduleIndex}-{periodIndex}-{m}",
                    Description = $"Year Level Description {index}-{scheduleIndex}-{periodIndex}-{m}"
                },
                Teachers = new List<Teacher>
                {
                    new Teacher
                    {
                        StaffCentreId = 1,
                        Title = "Mr.",
                        FamilyName = $"FamilyName{index}-{scheduleIndex}-{periodIndex}-{m}",
                        GivenNames = $"GivenNames{index}-{scheduleIndex}-{periodIndex}-{m}",
                        TimetableCode = $"TimetableCode{index}-{scheduleIndex}-{periodIndex}-{m}"
                    }
                }
            });
        }
        return classes;
    }

    private static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        Random random = new Random();
        char[] stringChars = new char[length];
        for (int i = 0; i < length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }
        return new string(stringChars);
    }
}

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