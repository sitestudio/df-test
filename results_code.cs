using System;
using System.Collections.Generic;
using System.Text.Json;

namespace GeneratedCode
{
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
        public string StartTime { get; set; } // DateTime as string
        public string EndTime { get; set; }   // DateTime as string
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
        public string StartTime { get; set; } // DateTime as string
        public string EndTime { get; set; }   // DateTime as string
        public string ClassName { get; set; }
        public Activity Activity { get; set; }
        public LearningArea LearningArea { get; set; }
        public Facility Facility { get; set; }
        public ClassType ClassType { get; set; }
        public bool IsCompositeClass { get; set; }
        public bool IsRollMarkable { get; set; }
        public object NotRollMarkableReason { get; set; }
        public bool IsRollMarked { get; set; }
        public string RollMarkedDate { get; set; } // DateTime as string
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
        static void Main()
        {
            var random = new Random();
            var studentSchedulesResponses = new List<StudentSchedulesResponse>();

            for (int i = 0; i < 100; i++)
            {
                var studentSchedulesResponse = new StudentSchedulesResponse
                {
                    Date = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    DayType = new DayType
                    {
                        Code = "D",
                        Description = "Regular Day"
                    },
                    Schedules = new List<Schedule>
                    {
                        new Schedule
                        {
                            DayCycleCode = "Cycle1",
                            TimetableVersion = new TimetableVersion
                            {
                                Id = random.Next(1, 100),
                                Name = "Version " + i
                            },
                            Periods = new List<Period>
                            {
                                new Period
                                {
                                    DayConfigId = random.Next(1, 1000),
                                    DayConfigType = new DayConfigType
                                    {
                                        Code = "Type1",
                                        Description = "Normal Class"
                                    },
                                    StartTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                                    EndTime = DateTime.UtcNow.AddHours(1).ToString("yyyy-MM-ddTHH:mm:ssZ"),
                                    ItemName = "Math",
                                    ShortName = "Math",
                                    IsTeachingAllocation = true,
                                    Classes = new List<Class>
                                    {
                                        new Class
                                        {
                                            HasAttendanceChanges = false,
                                            AttendanceStatus = new AttendanceStatus
                                            {
                                                Code = "A",
                                                Description = "Present"
                                            },
                                            TimetableClassId = random.Next(1, 1000),
                                            StartTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                                            EndTime = DateTime.UtcNow.AddHours(1).ToString("yyyy-MM-ddTHH:mm:ssZ"),
                                            ClassName = "Math 101",
                                            Activity = new Activity
                                            {
                                                Code = "A1",
                                                Description = "Lecture"
                                            },
                                            LearningArea = new LearningArea
                                            {
                                                Code = "LA1",
                                                Description = "Mathematics"
                                            },
                                            Facility = new Facility
                                            {
                                                Code = "F1",
                                                Description = "Room 101"
                                            },
                                            ClassType = new ClassType
                                            {
                                                Code = "CT1",
                                                Description = "Regular"
                                            },
                                            IsCompositeClass = false,
                                            IsRollMarkable = true,
                                            NotRollMarkableReason = null,
                                            IsRollMarked = false,
                                            RollMarkedDate = null,
                                            RollMarkedUser = null,
                                            Session = "Morning",
                                            YearLevel = new YearLevel
                                            {
                                                Code = "YL1",
                                                Description = "Year 1"
                                            },
                                            Teachers = new List<Teacher>
                                            {
                                                new Teacher
                                                {
                                                    StaffCentreId = random.Next(1, 100),
                                                    Title = "Mr.",
                                                    FamilyName = "Smith",
                                                    GivenNames = "John",
                                                    TimetableCode = "TC1"
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
        }
    }
}