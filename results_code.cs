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

public class AttendanceStatus
{
    public string Code { get; set; }
    public string Description { get; set; }
}

public class ClassType
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
    public AttendanceStatus AttendanceStatus { get; set; }
    public int TimetableClassId { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string ClassName { get; set; }
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

public class Program
{
    public static void Main()
    {
        var random = new Random();
        var studentSchedulesResponses = new List<StudentSchedulesResponse>();

        for (int i = 0; i < 100; i++)
        {
            var response = new StudentSchedulesResponse
            {
                Date = DateTime.Now.AddDays(random.Next(-30, 1)).ToString("o"),
                DayType = new DayType
                {
                    Code = random.Next(0, 3) == 0 ? "WD" : random.Next(0, 2) == 0 ? "WE" : "H",
                    Description = random.Next(0, 3) == 0 ? "Weekday" : random.Next(0, 2) == 0 ? "Weekend" : "Holiday"
                },
                Schedules = new List<Schedule>()
            };

            for (int j = 0; j < random.Next(1, 4); j++)
            {
                var schedule = new Schedule
                {
                    DayCycleCode = random.Next(0, 3) == 0 ? "A" : random.Next(0, 2) == 0 ? "B" : "C",
                    TimetableVersion = new TimetableVersion
                    {
                        Id = random.Next(1, 11),
                        Name = $"Timetable {random.Next(1, 6)}"
                    },
                    Periods = new List<Period>()
                };

                for (int k = 0; k < random.Next(1, 6); k++)
                {
                    var period = new Period
                    {
                        DayConfigId = random.Next(1, 101),
                        DayConfigType = new DayConfigType
                        {
                            Code = random.Next(0, 2) == 0 ? "Regular" : "Special",
                            Description = random.Next(0, 2) == 0 ? "Regular Day" : "Special Event"
                        },
                        StartTime = DateTime.Now.AddHours(random.Next(0, 24)).ToString("o"),
                        EndTime = DateTime.Now.AddHours(random.Next(0, 24)).ToString("o"),
                        ItemName = random.Next(0, 5) == 0 ? "Math" : random.Next(0, 4) == 0 ? "Science" : random.Next(0, 3) == 0 ? "History" : random.Next(0, 2) == 0 ? "Art" : "PE",
                        ShortName = "Subject",
                        IsTeachingAllocation = random.Next(0, 2) == 0,
                        Classes = new List<Class>()
                    };

                    for (int l = 0; l < random.Next(1, 6); l++)
                    {
                        var classItem = new Class
                        {
                            HasAttendanceChanges = random.Next(0, 2) == 0,
                            AttendanceStatus = new AttendanceStatus
                            {
                                Code = random.Next(0, 3) == 0 ? "P" : random.Next(0, 2) == 0 ? "A" : "L",
                                Description = random.Next(0, 3) == 0 ? "Present" : random.Next(0, 2) == 0 ? "Absent" : "Late"
                            },
                            TimetableClassId = random.Next(1, 1001),
                            StartTime = DateTime.Now.AddHours(random.Next(0, 24)).ToString("o"),
                            EndTime = DateTime.Now.AddHours(random.Next(0, 24)).ToString("o"),
                            ClassName = $"Class {random.Next(1, 13)}",
                            Session = random.Next(0, 2) == 0 ? "Session 1" : "Session 2",
                            YearLevel = new YearLevel
                            {
                                Code = random.Next(0, 3) == 0 ? "Y1" : random.Next(0, 2) == 0 ? "Y2" : "Y3",
                                Description = random.Next(0, 3) == 0 ? "Year 1" : random.Next(0, 2) == 0 ? "Year 2" : "Year 3"
                            },
                            Teachers = new List<Teacher>()
                        };

                        for (int m = 0; m < random.Next(1, 4); m++)
                        {
                            classItem.Teachers.Add(new Teacher
                            {
                                StaffCentreId = random.Next(1, 11),
                                Title = random.Next(0, 3) == 0 ? "Mr." : random.Next(0, 2) == 0 ? "Ms." : "Dr.",
                                FamilyName = random.Next(0, 3) == 0 ? "Smith" : random.Next(0, 2) == 0 ? "Jones" : "Brown",
                                GivenNames = random.Next(0, 3) == 0 ? "John" : random.Next(0, 2) == 0 ? "Jane" : "Emily",
                                TimetableCode = $"TC{random.Next(1, 6)}"
                            });
                        }

                        period.Classes.Add(classItem);
                    }

                    schedule.Periods.Add(period);
                }

                response.Schedules.Add(schedule);
            }

            studentSchedulesResponses.Add(response);
        }

        string json = JsonSerializer.Serialize(studentSchedulesResponses);
        Console.WriteLine(json);
    }
}