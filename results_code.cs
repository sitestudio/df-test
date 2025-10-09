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

public class Class
{
    public bool HasAttendanceChanges { get; set; }
    public ClassAttendanceStatus AttendanceStatus { get; set; }
    public int TimetableClassId { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string ClassName { get; set; }
    public object Activity { get; set; }
    public object LearningArea { get; set; }
    public object Facility { get; set; }
    public object ClassType { get; set; }
    public bool IsCompositeClass { get; set; }
    public bool IsRollMarkable { get; set; }
    public object NotRollMarkableReason { get; set; }
    public bool IsRollMarked { get; set; }
    public string RollMarkedDate { get; set; }
    public string RollMarkedUser { get; set; }
    public string Session { get; set; }
    public object YearLevel { get; set; }
    public List<Teacher> Teachers { get; set; }
}

public class Teacher
{
    public int StaffCentreId { get; set; }
    public string Title { get; set; }
    public string FamilyName { get; set; }
    public string GivenNames { get; set; }
    public string TimetableCode { get; set; }
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

public class StudentSchedulesResponse
{
    public string Date { get; set; }
    public DayType DayType { get; set; }
    public List<Schedule> Schedules { get; set; }
}

public class Schedule
{
    public string DayCycleCode { get; set; }
    public TimetableVersion TimetableVersion { get; set; }
    public List<Period> Periods { get; set; }
}

public class Program
{
    public static string Main()
    {
        List<StudentSchedulesResponse> responses = new List<StudentSchedulesResponse>();
        Random rnd = new Random();

        for (int i = 0; i < 100; i++)
        {
            var schedule = new StudentSchedulesResponse
            {
                Date = DateTime.Now.AddDays(i).ToString("o"), // ISO 8601 format
                DayType = new DayType
                {
                    Code = "D" + rnd.Next(1, 10),
                    Description = "Description for day type " + i
                },
                Schedules = new List<Schedule> 
                {
                    new Schedule
                    {
                        DayCycleCode = "Cycle" + rnd.Next(1, 5),
                        TimetableVersion = new TimetableVersion
                        {
                            Id = rnd.Next(1, 100),
                            Name = "Version " + rnd.Next(1, 10)
                        },
                        Periods = new List<Period> 
                        {
                            new Period
                            {
                                DayConfigId = rnd.Next(1, 50),
                                DayConfigType = new DayConfigType
                                {
                                    Code = "Type" + rnd.Next(1, 5),
                                    Description = "Type description " + rnd.Next(1, 5)
                                },
                                StartTime = DateTime.Now.AddHours(rnd.Next(8, 14)).ToString("o"), // ISO 8601 format
                                EndTime = DateTime.Now.AddHours(rnd.Next(15, 20)).ToString("o"), // ISO 8601 format
                                ItemName = "Item " + i,
                                ShortName = "Short " + i,
                                IsTeachingAllocation = rnd.Next(0, 2) == 0,
                                Classes = new List<Class> 
                                {
                                    new Class
                                    {
                                        HasAttendanceChanges = rnd.Next(0, 2) == 0,
                                        AttendanceStatus = new ClassAttendanceStatus
                                        {
                                            Code = "Status" + rnd.Next(1, 5),
                                            Description = "Status description " + i
                                        },
                                        TimetableClassId = rnd.Next(1, 100),
                                        StartTime = DateTime.Now.AddHours(rnd.Next(8, 14)).ToString("o"),
                                        EndTime = DateTime.Now.AddHours(rnd.Next(15, 20)).ToString("o"),
                                        ClassName = "Class " + i,
                                        Activity = null,
                                        LearningArea = null,
                                        Facility = null,
                                        ClassType = null,
                                        IsCompositeClass = rnd.Next(0, 2) == 0,
                                        IsRollMarkable = rnd.Next(0, 2) == 0,
                                        NotRollMarkableReason = null,
                                        IsRollMarked = rnd.Next(0, 2) == 0,
                                        RollMarkedDate = rnd.Next(0, 2) == 0 ? DateTime.Now.AddDays(-1).ToString("o") : null,
                                        RollMarkedUser = rnd.Next(0, 2) == 0 ? "User" + i : null,
                                        Session = "Session " + i,
                                        YearLevel = null,
                                        Teachers = new List<Teacher>
                                        {
                                            new Teacher
                                            {
                                                StaffCentreId = rnd.Next(1, 1000),
                                                Title = "Mr./Ms.",
                                                FamilyName = "Family" + i,
                                                GivenNames = "Given" + i,
                                                TimetableCode = "TCode" + i
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            
            responses.Add(schedule);
        }

        return JsonSerializer.Serialize(responses);
    }

    static string json = Main(); // Store result outside Main method
}