using System;
using System.Collections.Generic;

public class StudentSchedulesResponse {
    public string date { get; set; }
    public DayType dayType { get; set; }
    public List<Schedule> schedules { get; set; }
}

public class DayType {
    public string code { get; set; }
    public string description { get; set; }
}

public class Schedule {
    public string dayCycleCode { get; set; }
    public TimetableVersion timetableVersion { get; set; }
    public List<Period> periods { get; set; }
}

public class TimetableVersion {
    public int id { get; set; }
    public string name { get; set; }
}

public class Period {
    public int dayConfigId { get; set; }
    public DayConfigType dayConfigType { get; set; }
    public string startTime { get; set; }
    public string endTime { get; set; }
    public string itemName { get; set; }
    public string shortName { get; set; }
    public bool isTeachingAllocation { get; set; }
    public List<Class> classes { get; set; }
}

public class DayConfigType {
    public string code { get; set; }
    public string description { get; set; }
}

public class Class {
    public bool hasAttendanceChanges { get; set; }
    public AttendanceStatus attendanceStatus { get; set; }
    public int timetableClassId { get; set; }
    public string startTime { get; set; }
    public string endTime { get; set; }
    public string className { get; set; }
    public Activity activity { get; set; }
    public LearningArea learningArea { get; set; }
    public Facility facility { get; set; }
    public ClassType classType { get; set; }
    public bool isCompositeClass { get; set; }
    public bool isRollMarkable { get; set; }
    public NotRollMarkableReason notRollMarkableReason { get; set; }
    public bool isRollMarked { get; set; }
    public string rollMarkedDate { get; set; }
    public string rollMarkedUser { get; set; }
    public string session { get; set; }
    public YearLevel yearLevel { get; set; }
    public List<Teacher> teachers { get; set; }
}

public class AttendanceStatus {
    public string code { get; set; }
    public string description { get; set; }
}

public class Activity {
    public string code { get; set; }
    public string description { get; set; }
}

public class LearningArea {
    public string code { get; set; }
    public string description { get; set; }
}

public class Facility {
    public string code { get; set; }
    public string description { get; set; }
}

public class ClassType {
    public string code { get; set; }
    public string description { get; set; }
}

public class NotRollMarkableReason {
    public string code { get; set; }
    public string description { get; set; }
}

public class YearLevel {
    public string code { get; set; }
    public string description { get; set; }
}

public class Teacher {
    public int staffCentreId { get; set; }
    public string title { get; set; }
    public string familyName { get; set; }
    public string givenNames { get; set; }
    public string timetableCode { get; set; }
}

public class Main {
    public static void Main() {
        List<StudentSchedulesResponse> responses = new List<StudentSchedulesResponse>();
        for (int i = 0; i < 100; i++) {
            responses.Add(new StudentSchedulesResponse {
                date = "2025-10-09T01:50:10",
                dayType = new DayType {
                    code = "Event",
                    description = "Regular school day"
                },
                schedules = new List<Schedule> {
                    // Add schedules here
                }
            });
        }
    }
}