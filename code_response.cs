using System;
using System.Collections.Generic;
using Bogus;

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

class Program
{
    static void Main(string[] args)
    {
        var faker = new Faker();

        var studentSchedulesResponses = new List<StudentSchedulesResponse>();

        for (int i = 0; i < 100; i++)
        {
            var response = new StudentSchedulesResponse
            {
                Date = faker.Date.Recent(),
                DayType = new DayType
                {
                    Code = faker.Lorem.Word(),
                    Description = faker.Lorem.Sentence()
                },
                Schedules = new List<Schedule>
                {
                    new Schedule
                    {
                        DayCycleCode = faker.Lorem.Word(),
                        TimetableVersion = new TimetableVersion
                        {
                            Id = faker.Random.Int(1, 100),
                            Name = faker.Lorem.Sentence()
                        },
                        Periods = new List<Period>
                        {
                            new Period
                            {
                                DayConfigId = faker.Random.Int(1, 100),
                                DayConfigType = new DayConfigType
                                {
                                    Code = faker.Lorem.Word(),
                                    Description = faker.Lorem.Sentence()
                                },
                                StartTime = faker.Date.Recent(),
                                EndTime = faker.Date.Future(),
                                ItemName = faker.Lorem.Word(),
                                ShortName = faker.Lorem.Word(),
                                IsTeachingAllocation = faker.Random.Bool(),
                                Classes = new List<Class>
                                {
                                    new Class
                                    {
                                        HasAttendanceChanges = faker.Random.Bool(),
                                        AttendanceStatus = new AttendanceStatus
                                        {
                                            Code = faker.Lorem.Word(),
                                            Description = faker.Lorem.Sentence()
                                        },
                                        TimetableClassId = faker.Random.Int(1, 1000),
                                        StartTime = faker.Date.Recent(),
                                        EndTime = faker.Date.Future(),
                                        ClassName = faker.Lorem.Word(),
                                        Activity = new Activity
                                        {
                                            Code = faker.Lorem.Word(),
                                            Description = faker.Lorem.Sentence()
                                        },
                                        LearningArea = new LearningArea
                                        {
                                            Code = faker.Lorem.Word(),
                                            Description = faker.Lorem.Sentence()
                                        },
                                        Facility = new Facility
                                        {
                                            Code = faker.Lorem.Word(),
                                            Description = faker.Lorem.Sentence()
                                        },
                                        ClassType = new ClassType
                                        {
                                            Code = faker.Lorem.Word(),
                                            Description = faker.Lorem.Sentence()
                                        },
                                        IsCompositeClass = faker.Random.Bool(),
                                        IsRollMarkable = faker.Random.Bool(),
                                        NotRollMarkableReason = new NotRollMarkableReason
                                        {
                                            Code = faker.Lorem.Word(),
                                            Description = faker.Lorem.Sentence()
                                        },
                                        IsRollMarked = faker.Random.Bool(),
                                        RollMarkedDate = faker.Random.Bool() ? (DateTime?)faker.Date.Recent() : null,
                                        RollMarkedUser = faker.Random.Bool() ? faker.Name.FullName() : null,
                                        Session = faker.Lorem.Word(),
                                        YearLevel = new YearLevel
                                        {
                                            Code = faker.Lorem.Word(),
                                            Description = faker.Lorem.Sentence()
                                        },
                                        Teachers = new List<Teacher>
                                        {
                                            new Teacher
                                            {
                                                StaffCentreId = faker.Random.Int(1, 100),
                                                Title = faker.Name.Title(),
                                                FamilyName = faker.Name.LastName(),
                                                GivenNames = faker.Name.FirstName(),
                                                TimetableCode = faker.Lorem.Word()
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

        // Output the generated records (this is just a demonstration, modify as needed)
        foreach (var record in studentSchedulesResponses)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(record));
        }
    }
}