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

public class DayConfigType
{
    public string Code { get; set; }
    public string Description { get; set; }
}

public class ClassAttendanceStatus
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

public class Class
{
    public bool HasAttendanceChanges { get; set; }
    public ClassAttendanceStatus AttendanceStatus { get; set; }
    public int TimetableClassId { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string ClassName { get; set; }
    public object Activity { get; set; } // Contains code and description
    public object LearningArea { get; set; } // Contains code and description
    public object Facility { get; set; } // Contains code and description
    public object ClassType { get; set; } // Contains code and description
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

public class Schedule
{
    public string DayCycleCode { get; set; }
    public TimetableVersion TimetableVersion { get; set; }
    public List<Period> Periods { get; set; }
}

public class StudentSchedulesResponse
{
    public string Date { get; set; }
    public DayType DayType { get; set; }
    public List<Schedule> Schedules { get; set; }
}

public static class Program
{
    public static void Main()
    {
        var studentSchedulesResponses = new List<StudentSchedulesResponse>();
        var random = new Random();

        for (int i = 0; i < 100; i++)
        {
            var studentSchedulesResponse = new StudentSchedulesResponse
            {
                Date = DateTime.UtcNow.ToString("o"),
                DayType = new DayType
                {
                    Code = "DT" + random.Next(1, 100),
                    Description = "Description " + random.Next(1, 100)
                },
                Schedules = new List<Schedule>
                {
                    new Schedule
                    {
                        DayCycleCode = "Cycle" + random.Next(1, 10),
                        TimetableVersion = new TimetableVersion
                        {
                            Id = random.Next(1, 10),
                            Name = "Timetable " + random.Next(1, 10),
                        },
                        Periods = new List<Period>
                        {
                            new Period
                            {
                                DayConfigId = random.Next(1, 100),
                                DayConfigType = new DayConfigType
                                {
                                    Code = "Type" + random.Next(1, 10),
                                    Description = "Description " + random.Next(1, 10),
                                },
                                StartTime = DateTime.UtcNow.AddHours(random.Next(-10, 10)).ToString("o"),
                                EndTime = DateTime.UtcNow.AddHours(random.Next(1, 10)).ToString("o"),
                                ItemName = "Item " + random.Next(1, 100),
                                ShortName = "Short " + random.Next(1, 100),
                                IsTeachingAllocation = random.Next(0, 2) == 0,
                                Classes = new List<Class>
                                {
                                    new Class
                                    {
                                        HasAttendanceChanges = random.Next(0, 2) == 0,
                                        AttendanceStatus = new ClassAttendanceStatus
                                        {
                                            Code = "Status" + random.Next(1, 10),
                                            Description = "Attendance Status " + random.Next(1, 10),
                                        },
                                        TimetableClassId = random.Next(1, 100),
                                        StartTime = DateTime.UtcNow.ToString("o"),
                                        EndTime = DateTime.UtcNow.ToString("o"),
                                        ClassName = "Class " + random.Next(1, 100),
                                        Activity = new { Code = "Activity" + random.Next(1, 10), Description = "Activity Description " + random.Next(1, 10) },
                                        LearningArea = new { Code = "Area" + random.Next(1, 10), Description = "Learning Area " + random.Next(1, 10) },
                                        Facility = new { Code = "Facility" + random.Next(1, 10), Description = "Facility Description " + random.Next(1, 10) },
                                        ClassType = new { Code = "Type" + random.Next(1, 10), Description = "Class Type " + random.Next(1, 10) },
                                        IsCompositeClass = random.Next(0, 2) == 0,
                                        IsRollMarkable = random.Next(0, 2) == 0,
                                        NotRollMarkableReason = new NotRollMarkableReason
                                        {
                                            Code = "Reason" + random.Next(1, 10),
                                            Description = "Not Roll Markable Reason " + random.Next(1, 10),
                                        },
                                        IsRollMarked = random.Next(0, 2) == 0,
                                        RollMarkedDate = random.Next(0, 2) == 0 ? (DateTime.UtcNow.ToString("o")) : null,
                                        RollMarkedUser = random.Next(0, 2) == 0 ? "User" + random.Next(1, 10) : null,
                                        Session = "Session " + random.Next(1, 10),
                                        YearLevel = new YearLevel
                                        {
                                            Code = "Year" + random.Next(1, 10),
                                            Description = "Year Level " + random.Next(1, 10),
                                        },
                                        Teachers = new List<Teacher>
                                        {
                                            new Teacher
                                            {
                                                StaffCentreId = random.Next(1, 100),
                                                Title = "Mr",
                                                FamilyName = "Smith",
                                                GivenNames = "John",
                                                TimetableCode = "Timetable" + random.Next(1, 10)
                                            },
                                            new Teacher
                                            {
                                                StaffCentreId = random.Next(1, 100),
                                                Title = "Miss",
                                                FamilyName = "Johnson",
                                                GivenNames = "Emily",
                                                TimetableCode = "Timetable" + random.Next(1, 10)
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

        var json = JsonSerializer.Serialize(studentSchedulesResponses, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(json);
        // To return the variable for further processing
        json = json; // This line is to ensure json is returned
    }
}