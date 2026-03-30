using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

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

public class Program
{
    public static void Main()
    {
        var studentSchedulesResponses = new List<StudentSchedulesResponse>();
        var random = new Random();

        for (int i = 0; i < 100; i++)
        {
            var response = new StudentSchedulesResponse
            {
                Date = DateTime.Now.ToString("o"), // ISO 8601 format string
                DayType = new DayType
                {
                    Code = "Weekday",
                    Description = "Standard weekday"
                },
                Schedules = new List<Schedule>
                {
                    new Schedule
                    {
                        DayCycleCode = "A",
                        TimetableVersion = new TimetableVersion
                        {
                            Id = random.Next(1, 1000),
                            Name = "Version " + random.Next(1, 10)
                        },
                        Periods = new List<Period>
                        {
                            new Period
                            {
                                DayConfigId = random.Next(1, 100),
                                DayConfigType = new DayConfigType
                                {
                                    Code = "Regular",
                                    Description = "Regular class period"
                                },
                                StartTime = DateTime.Now.AddHours(random.Next(1, 6)).ToString("o"),
                                EndTime = DateTime.Now.AddHours(random.Next(7, 12)).ToString("o"),
                                ItemName = "Math Class",
                                ShortName = "Math",
                                IsTeachingAllocation = random.Next(0, 2) == 1,
                                Classes = new List<Class>
                                {
                                    new Class
                                    {
                                        HasAttendanceChanges = random.Next(0, 2) == 1,
                                        AttendanceStatus = new AttendanceStatus
                                        {
                                            Code = "Present",
                                            Description = "Student is present"
                                        },
                                        TimetableClassId = random.Next(1, 100),
                                        StartTime = DateTime.Now.AddHours(random.Next(1, 6)).ToString("o"),
                                        EndTime = DateTime.Now.AddHours(random.Next(7, 12)).ToString("o"),
                                        ClassName = "Math",
                                        Activity = new Activity
                                        {
                                            Code = "Math101",
                                            Description = "Introduction to Math"
                                        },
                                        LearningArea = new LearningArea
                                        {
                                            Code = "Math",
                                            Description = "Mathematics"
                                        },
                                        Facility = new Facility
                                        {
                                            Code = "Room 101",
                                            Description = "First floor Math room"
                                        },
                                        ClassType = new ClassType
                                        {
                                            Code = "Lecture",
                                            Description = "Standard lecture class"
                                        },
                                        IsCompositeClass = false,
                                        IsRollMarkable = true,
                                        NotRollMarkableReason = null,
                                        IsRollMarked = true,
                                        RollMarkedDate = DateTime.Now.ToString("o"),
                                        RollMarkedUser = "Admin",
                                        Session = "2023-2024",
                                        YearLevel = new YearLevel
                                        {
                                            Code = "10",
                                            Description = "Year 10"
                                        },
                                        Teachers = new List<Teacher>
                                        {
                                            new Teacher
                                            {
                                                StaffCentreId = random.Next(1, 100),
                                                Title = "Mr.",
                                                FamilyName = "Smith",
                                                GivenNames = "John",
                                                TimetableCode = "T1"
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

        string json = JsonSerializer.Serialize(studentSchedulesResponses, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(json);
    }
}