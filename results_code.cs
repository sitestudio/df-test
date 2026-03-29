string json = System.Text.Json.JsonSerializer.Serialize(new List<StudentSchedulesResponse>
{
    new StudentSchedulesResponse
    {
        date = "2023-11-19T12:00:00",
        dayType = new DayType
        {
            code = "A",
            description = "Regular Day"
        },
        schedules = new List<Schedule>
        {
            new Schedule
            {
                dayCycleCode = "Cycle 1",
                timetableVersion = new TimetableVersion
                {
                    id = 1,
                    name = "Version 1"
                },
                periods = new List<Period>
                {
                    new Period
                    {
                        dayConfigId = 101,
                        dayConfigType = new DayConfigType
                        {
                            code = "Standard",
                            description = "Standard Day Configuration"
                        },
                        startTime = "2023-11-19T08:00:00",
                        endTime = "2023-11-19T15:00:00",
                        itemName = "Morning Classes",
                        shortName = "MC",
                        isTeachingAllocation = true,
                        classes = new List<Class>
                        {
                            new Class
                            {
                                hasAttendanceChanges = true,
                                attendanceStatus = new AttendanceStatus
                                {
                                    code = "P",
                                    description = "Present"
                                },
                                timetableClassId = 202,
                                startTime = "2023-11-19T08:00:00",
                                endTime = "2023-11-19T09:00:00",
                                className = "Math",
                                activity = new Activity
                                {
                                    code = "MATH",
                                    description = "Mathematics Class"
                                },
                                learningArea = new LearningArea
                                {
                                    code = "Math",
                                    description = "Mathematics"
                                },
                                facility = new Facility
                                {
                                    code = "Room 101",
                                    description = "Primary Math Classroom"
                                },
                                classType = new ClassType
                                {
                                    code = "Lecture",
                                    description = "Lecture Class"
                                },
                                isCompositeClass = false,
                                isRollMarkable = true,
                                notRollMarkableReason = null,
                                isRollMarked = false,
                                rollMarkedDate = null,
                                rollMarkedUser = null,
                                session = "Morning Session",
                                yearLevel = new YearLevel
                                {
                                    code = "Year 10",
                                    description = "Year 10"
                                },
                                teachers = new List<Teacher>
                                {
                                    new Teacher
                                    {
                                        staffCentreId = 1,
                                        title = "Mr.",
                                        familyName = "Smith",
                                        givenNames = "John",
                                        timetableCode = "T1"
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    },
    // More sample records...
});