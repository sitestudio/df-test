using System;
using System.Collections.Generic;
using System.Text.Json;

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
        List<StudentSchedulesResponse> studentSchedulesResponses = new List<StudentSchedulesResponse>();

        for (int i = 0; i < 100; i++)
        {
            var studentSchedule = new StudentSchedulesResponse
            {
                Date = DateTime.Now.AddDays(i).ToString("yyyy-MM-ddTHH:mm:ss"),
                DayType = new DayType
                {
                    Code = "Day" + i,
                    Description = "Description for day " + i
                },
                Schedules = new List<Schedule>
                {
                    new Schedule
                    {
                        DayCycleCode = "Cycle" + i,
                        TimetableVersion = new TimetableVersion
                        {
                            Id = i,
                            Name = "Timetable " + i
                        },
                        Periods = new List<Period>
                        {
                            new Period
                            {
                                DayConfigId = i,
                                DayConfigType = new DayConfigType
                                {
                                    Code = "Type" + i,
                                    Description = "Type description " + i
                                },
                                StartTime = DateTime.Now.AddHours(i).ToString("yyyy-MM-ddTHH:mm:ss"),
                                EndTime = DateTime.Now.AddHours(i + 1).ToString("yyyy-MM-ddTHH:mm:ss"),
                                ItemName = "Item" + i,
                                ShortName = "Short" + i,
                                IsTeachingAllocation = (i % 2 == 0),
                                Classes = new List<Class>
                                {
                                    new Class
                                    {
                                        HasAttendanceChanges = (i % 2 == 1),
                                        AttendanceStatus = new AttendanceStatus
                                        {
                                            Code = "Status" + i,
                                            Description = "Attendance status description " + i
                                        },
                                        TimetableClassId = i,
                                        StartTime = DateTime.Now.AddHours(i).ToString("yyyy-MM-ddTHH:mm:ss"),
                                        EndTime = DateTime.Now.AddHours(i + 1).ToString("yyyy-MM-ddTHH:mm:ss"),
                                        ClassName = "Class" + i,
                                        Activity = new Activity
                                        {
                                            Code = "Activity" + i,
                                            Description = "Activity description " + i
                                        },
                                        LearningArea = new LearningArea
                                        {
                                            Code = "LearningArea" + i,
                                            Description = "Learning area description " + i
                                        },
                                        Facility = new Facility
                                        {
                                            Code = "Facility" + i,
                                            Description = "Facility description " + i
                                        },
                                        ClassType = new ClassType
                                        {
                                            Code = "ClassType" + i,
                                            Description = "Class type description " + i
                                        },
                                        IsCompositeClass = (i % 2 == 0),
                                        IsRollMarkable = (i % 2 == 1),
                                        NotRollMarkableReason = new NotRollMarkableReason
                                        {
                                            Code = "Reason" + i,
                                            Description = "Not roll markable reason " + i
                                        },
                                        IsRollMarked = (i % 2 == 0),
                                        RollMarkedDate = (i % 3 == 0) ? DateTime.Now.AddDays(i).ToString("yyyy-MM-ddTHH:mm:ss") : null,
                                        RollMarkedUser = (i % 4 == 0) ? "User" + i : null,
                                        Session = "Session" + i,
                                        YearLevel = new YearLevel
                                        {
                                            Code = "YearLevel" + i,
                                            Description = "Year level description " + i
                                        },
                                        Teachers = new List<Teacher>
                                        {
                                            new Teacher
                                            {
                                                StaffCentreId = i,
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

            studentSchedulesResponses.Add(studentSchedule);
        }

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(studentSchedulesResponses, options);
        Console.WriteLine(json);
    }
}