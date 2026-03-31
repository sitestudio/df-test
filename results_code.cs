using System;
using System.Collections.Generic;
using System.Text.Json;

string json;

List<StudentSchedulesResponse> samples = new List<StudentSchedulesResponse>();
Random random = new Random();

for (int i = 0; i < 100; i++)
{
    samples.Add(new StudentSchedulesResponse
    {
        Date = DateTime.Now.AddDays(random.Next(-365, 0)).ToString("o"),
        DayType = new DayType
        {
            Code = $"DT{random.Next(1, 4)}",
            Description = $"Day Type {random.Next(1, 4)}"
        },
        Schedules = new List<Schedule>()
    });

    int scheduleCount = random.Next(1, 6);
    for (int j = 0; j < scheduleCount; j++)
    {
        var schedule = new Schedule
        {
            DayCycleCode = $"CC{random.Next(1, 11)}",
            TimetableVersion = new TimetableVersion
            {
                Id = random.Next(1, 101),
                Name = $"Version {random.Next(1, 6)}"
            },
            Periods = new List<Period>()
        };

        int periodCount = random.Next(1, 11);
        for (int k = 0; k < periodCount; k++)
        {
            var period = new Period
            {
                DayConfigId = random.Next(1, 201),
                DayConfigType = new DayConfigType
                {
                    Code = $"Type{random.Next(1, 4)}",
                    Description = $"Type Description {random.Next(1, 4)}"
                },
                StartTime = DateTime.Now.AddHours(random.Next(-2, 0)).ToString("o"),
                EndTime = DateTime.Now.AddHours(random.Next(0, 2)).ToString("o"),
                ItemName = $"Item {random.Next(1, 51)}",
                ShortName = $"Short {random.Next(1, 51)}",
                IsTeachingAllocation = random.Next(0, 2) == 0,
                Classes = new List<Class>()
            };

            int classCount = random.Next(1, 6);
            for (int l = 0; l < classCount; l++)
            {
                var classInfo = new Class
                {
                    HasAttendanceChanges = random.Next(0, 2) == 0,
                    AttendanceStatus = new AttendanceStatus
                    {
                        Code = $"AS{random.Next(1, 4)}",
                        Description = $"Status Description {random.Next(1, 4)}"
                    },
                    TimetableClassId = random.Next(1, 501),
                    StartTime = DateTime.Now.AddHours(random.Next(-2, 0)).ToString("o"),
                    EndTime = DateTime.Now.AddHours(random.Next(0, 2)).ToString("o"),
                    ClassName = $"Class {random.Next(1, 101)}",
                    Activity = new Activity
                    {
                        Code = $"ACT{random.Next(1, 11)}",
                        Description = $"Activity {random.Next(1, 11)}"
                    },
                    LearningArea = new LearningArea
                    {
                        Code = $"LA{random.Next(1, 11)}",
                        Description = $"Learning Area {random.Next(1, 11)}"
                    },
                    Facility = new Facility
                    {
                        Code = $"FAC{random.Next(1, 11)}",
                        Description = $"Facility {random.Next(1, 11)}"
                    },
                    ClassType = new ClassType
                    {
                        Code = $"CT{random.Next(1, 4)}",
                        Description = $"Class Type {random.Next(1, 4)}"
                    },
                    IsCompositeClass = random.Next(0, 2) == 0,
                    IsRollMarkable = random.Next(0, 2) == 0,
                    NotRollMarkableReason = new NotRollMarkableReason
                    {
                        Code = $"Reason{random.Next(1, 4)}",
                        Description = $"Not Roll Markable Reason {random.Next(1, 4)}"
                    },
                    IsRollMarked = random.Next(0, 2) == 0,
                    RollMarkedDate = random.Next(0, 2) == 0 ? (DateTime?)DateTime.Now.AddDays(random.Next(-10, 0)) : null,
                    RollMarkedUser = random.Next(0, 2) == 0 ? $"User {random.Next(1, 51)}" : null,
                    Session = $"Session {random.Next(1, 6)}",
                    YearLevel = new YearLevel
                    {
                        Code = $"YL{random.Next(1, 7)}",
                        Description = $"Year Level {random.Next(1, 7)}"
                    },
                    Teachers = new List<Teacher>()
                };

                int teacherCount = random.Next(1, 4);
                for (int m = 0; m < teacherCount; m++)
                {
                    classInfo.Teachers.Add(new Teacher
                    {
                        StaffCentreId = random.Next(1, 1001),
                        Title = $"Title {random.Next(1, 6)}",
                        FamilyName = $"FamilyName {random.Next(1, 101)}",
                        GivenNames = $"GivenName {random.Next(1, 101)}",
                        TimetableCode = $"TC{random.Next(1, 21)}"
                    });
                }

                period.Classes.Add(classInfo);
            }

            schedule.Periods.Add(period);
        }

        samples[i].Schedules.Add(schedule);
    }
}

json = JsonSerializer.Serialize(samples, new JsonSerializerOptions { WriteIndented = true });