using System;
using System.Collections.Generic;

public class StudentSchedulesResponse
{
    public DateTime Date { get; set; }
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
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
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
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string ClassName { get; set; }
    public Activity Activity { get; set; }
    public LearningArea LearningArea { get; set; }
    public Facility Facility { get; set; }
    public ClassType ClassType { get; set; }
    public bool IsCompositeClass { get; set; }
    public bool IsRollMarkable { get; set; }
    public NotRollMarkableReason NotRollMarkableReason { get; set; }
    public bool IsRollMarked { get; set; }
    public DateTime? RollMarkedDate { get; set; }
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

public static class SampleDataGenerator
{
    public static List<StudentSchedulesResponse> GenerateSampleData(int count)
    {
        var random = new Random();
        var schedules = new List<StudentSchedulesResponse>();

        for (int i = 0; i < count; i++)
        {
            var schedule = new StudentSchedulesResponse
            {
                Date = DateTime.Now.AddDays(random.Next(-30, 30)),
                DayType = new DayType
                {
                    Code = "DT" + random.Next(1, 100),
                    Description = "Description for day type " + random.Next(1, 100)
                },
                Schedules = new List<Schedule>
                {
                    new Schedule
                    {
                        DayCycleCode = "DCC" + random.Next(1, 100),
                        TimetableVersion = new TimetableVersion
                        {
                            Id = random.Next(1, 10),
                            Name = "Version " + random.Next(1, 10)
                        },
                        Periods = new List<Period>
                        {
                            new Period
                            {
                                DayConfigId = random.Next(1, 100),
                                DayConfigType = new DayConfigType
                                {
                                    Code = "Type" + random.Next(1, 5),
                                    Description = "Day Config Type Description"
                                },
                                StartTime = DateTime.Now.AddHours(random.Next(0, 8)),
                                EndTime = DateTime.Now.AddHours(random.Next(8, 16)),
                                ItemName = "Item " + random.Next(1, 50),
                                ShortName = "Short " + random.Next(1, 50),
                                IsTeachingAllocation = random.Next(0, 2) == 1,
                                Classes = new List<Class>
                                {
                                    new Class
                                    {
                                        HasAttendanceChanges = random.Next(0, 2) == 1,
                                        AttendanceStatus = new AttendanceStatus
                                        {
                                            Code = "AS" + random.Next(1, 3),
                                            Description = "Attendance Status " + random.Next(1, 3)
                                        },
                                        TimetableClassId = random.Next(1, 100),
                                        StartTime = DateTime.Now.AddHours(random.Next(0, 8)),
                                        EndTime = DateTime.Now.AddHours(random.Next(8, 16)),
                                        ClassName = "Class " + random.Next(1, 100),
                                        Activity = new Activity
                                        {
                                            Code = "A" + random.Next(1, 10),
                                            Description = "Activity Description"
                                        },
                                        LearningArea = new LearningArea
                                        {
                                            Code = "LA" + random.Next(1, 10),
                                            Description = "Learning Area Description"
                                        },
                                        Facility = new Facility
                                        {
                                            Code = "F" + random.Next(1, 10),
                                            Description = "Facility Description"
                                        },
                                        ClassType = new ClassType
                                        {
                                            Code = "CT" + random.Next(1, 10),
                                            Description = "Class Type Description"
                                        },
                                        IsCompositeClass = random.Next(0, 2) == 1,
                                        IsRollMarkable = random.Next(0, 2) == 1,
                                        NotRollMarkableReason = new NotRollMarkableReason
                                        {
                                            Code = "NR" + random.Next(1, 5),
                                            Description = "Not Roll Markable Reason"
                                        },
                                        IsRollMarked = random.Next(0, 2) == 1,
                                        RollMarkedDate = random.Next(0, 2) == 1 ? (DateTime?)DateTime.Now : null,
                                        RollMarkedUser = random.Next(0, 2) == 1 ? "User" + random.Next(1, 100) : null,
                                        Session = "Session " + random.Next(1, 5),
                                        YearLevel = new YearLevel
                                        {
                                            Code = "YL" + random.Next(1, 10),
                                            Description = "Year Level Description"
                                        },
                                        Teachers = new List<Teacher>
                                        {
                                            new Teacher
                                            {
                                                StaffCentreId = random.Next(1, 100),
                                                Title = "Mr",
                                                FamilyName = "Smith" + random.Next(1, 100),
                                                GivenNames = "John" + random.Next(1, 100),
                                                TimetableCode = "T" + random.Next(1, 10)
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            schedules.Add(schedule);
        }

        return schedules;
    }
}

// Usage
var sampleData = SampleDataGenerator.GenerateSampleData(1000);