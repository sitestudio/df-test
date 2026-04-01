using System;
using System.Collections.Generic;
using System.Text.Json;

class Program
{
    public static string Main()
    {
        var responses = new List<StudentInformationResponse>
        {
            new StudentInformationResponse
            {
                attendanceId = 1,
                version = 1,
                isRollMarkable = true,
                notRollMarkableReason = new NotRollMarkableReason 
                {
                    code = "Code1",
                    description = "Roll is markable"
                },
                isRollMarked = true,
                rollMarkedDate = "2023-10-01T12:00:00Z",
                rollMarkedUser = "User1",
                students = new List<Student>
                {
                    new Student
                    {
                        enrolmentId = 101,
                        attendanceStatus = new AttendanceStatus
                        {
                            code = "Present",
                            description = "Student is present"
                        },
                        hasAttendanceChanges = false,
                        hasAbsentNote = false,
                        eqId = "E123",
                        imageId = null,
                        familyName = "Doe",
                        givenNames = "John",
                        birthDate = "2005-05-15T00:00:00Z",
                        age = "18",
                        rollClass = "10A",
                        yearLevel = new YearLevel
                        {
                            code = "10",
                            description = "Year 10"
                        },
                        enrolmentStatus = new EnrolmentStatus
                        {
                            code = "Enrolled",
                            description = "The student is enrolled"
                        },
                        gender = new Gender
                        {
                            code = "M",
                            description = "Male"
                        },
                        absences = new List<Absence>()
                    }
                }
            },
            new StudentInformationResponse
            {
                attendanceId = 2,
                version = 1,
                isRollMarkable = true,
                notRollMarkableReason = null,
                isRollMarked = false,
                rollMarkedDate = null,
                rollMarkedUser = null,
                students = new List<Student>
                {
                    new Student
                    {
                        enrolmentId = 102,
                        attendanceStatus = new AttendanceStatus
                        {
                            code = "Absent",
                            description = "Student is absent"
                        },
                        hasAttendanceChanges = true,
                        hasAbsentNote = true,
                        eqId = "E124",
                        imageId = null,
                        familyName = "Doe",
                        givenNames = "Jane",
                        birthDate = "2005-10-20T00:00:00Z",
                        age = "17",
                        rollClass = "10B",
                        yearLevel = new YearLevel
                        {
                            code = "10",
                            description = "Year 10"
                        },
                        enrolmentStatus = new EnrolmentStatus
                        {
                            code = "Enrolled",
                            description = "The student is enrolled"
                        },
                        gender = new Gender
                        {
                            code = "F",
                            description = "Female"
                        },
                        absences = new List<Absence>
                        {
                            new Absence 
                            {
                                studentAbsenceId = 201,
                                enrolmentId = 102,
                                absenceDate = "2023-10-01T00:00:00Z",
                                absenceReason = new AbsenceReason
                                {
                                    code = "Sick",
                                    description = "Student is sick"
                                },
                                partOfDayAbsence = new PartOfDayAbsence
                                {
                                    code = "FullDay",
                                    description = "Absent for the full day"
                                },
                                lateEarlyTime = null,
                                note = "Doctor's appointment",
                                modifiedDate = "2023-10-01T12:00:00Z",
                                modifiedBy = "Admin"
                            }
                        }
                    },
                    new Student
                    {
                        enrolmentId = 103,
                        attendanceStatus = new AttendanceStatus
                        {
                            code = "Present",
                            description = "Student is present"
                        },
                        hasAttendanceChanges = false,
                        hasAbsentNote = false,
                        eqId = "E125",
                        imageId = null,
                        familyName = "Smith",
                        givenNames = "Alex",
                        birthDate = "2006-01-05T00:00:00Z",
                        age = "17",
                        rollClass = "10B",
                        yearLevel = new YearLevel
                        {
                            code = "10",
                            description = "Year 10"
                        },
                        enrolmentStatus = new EnrolmentStatus
                        {
                            code = "Enrolled",
                            description = "The student is enrolled"
                        },
                        gender = new Gender
                        {
                            code = "M",
                            description = "Male"
                        },
                        absences = new List<Absence>()
                    }
                }
            },
            new StudentInformationResponse
            {
                attendanceId = 3,
                version = 1,
                isRollMarkable = false,
                notRollMarkableReason = new NotRollMarkableReason 
                {
                    code = "Code3",
                    description = "Roll not markable due to holiday"
                },
                isRollMarked = false,
                rollMarkedDate = null,
                rollMarkedUser = null,
                students = new List<Student>
                {
                    new Student
                    {
                        enrolmentId = 104,
                        attendanceStatus = new AttendanceStatus
                        {
                            code = "Present",
                            description = "Student is present"
                        },
                        hasAttendanceChanges = false,
                        hasAbsentNote = false,
                        eqId = "E126",
                        imageId = null,
                        familyName = "Brown",
                        givenNames = "Chris",
                        birthDate = "2004-08-10T00:00:00Z",
                        age = "19",
                        rollClass = "11A",
                        yearLevel = new YearLevel
                        {
                            code = "11",
                            description = "Year 11"
                        },
                        enrolmentStatus = new EnrolmentStatus
                        {
                            code = "Enrolled",
                            description = "The student is enrolled"
                        },
                        gender = new Gender
                        {
                            code = "M",
                            description = "Male"
                        },
                        absences = new List<Absence>()
                    },
                    new Student
                    {
                        enrolmentId = 105,
                        attendanceStatus = new AttendanceStatus
                        {
                            code = "Absent",
                            description = "Student is absent"
                        },
                        hasAttendanceChanges = true,
                        hasAbsentNote = true,
                        eqId = "E127",
                        imageId = null,
                        familyName = "Taylor",
                        givenNames = "Emma",
                        birthDate = "2005-12-22T00:00:00Z",
                        age = "17",
                        rollClass = "11A",
                        yearLevel = new YearLevel
                        {
                            code = "11",
                            description = "Year 11"
                        },
                        enrolmentStatus = new EnrolmentStatus
                        {
                            code = "Enrolled",
                            description = "The student is enrolled"
                        },
                        gender = new Gender
                        {
                            code = "F",
                            description = "Female"
                        },
                        absences = new List<Absence>
                        {
                            new Absence 
                            {
                                studentAbsenceId = 202,
                                enrolmentId = 105,
                                absenceDate = "2023-09-29T00:00:00Z",
                                absenceReason = new AbsenceReason
                                {
                                    code = "Vacation",
                                    description = "On vacation"
                                },
                                partOfDayAbsence = new PartOfDayAbsence
                                {
                                    code = "Partial",
                                    description = "Partial absence"
                                },
                                lateEarlyTime = null,
                                note = "Family trip",
                                modifiedDate = "2023-09-30T12:00:00Z",
                                modifiedBy = "Admin"
                            }
                        }
                    }
                }
            },
            new StudentInformationResponse
            {
                attendanceId = 4,
                version = 1,
                isRollMarkable = true,
                notRollMarkableReason = null,
                isRollMarked = true,
                rollMarkedDate = "2023-10-01T12:00:00Z",
                rollMarkedUser = "User2",
                students = new List<Student>()
            },
            new StudentInformationResponse
            {
                attendanceId = 5,
                version = 1,
                isRollMarkable = true,
                notRollMarkableReason = new NotRollMarkableReason 
                {
                    code = "Code5",
                    description = "Roll not markable due to policy"
                },
                isRollMarked = false,
                rollMarkedDate = null,
                rollMarkedUser = null,
                students = new List<Student>
                {
                    new Student
                    {
                        enrolmentId = 106,
                        attendanceStatus = new AttendanceStatus
                        {
                            code = "Present",
                            description = "Student is present"
                        },
                        hasAttendanceChanges = false,
                        hasAbsentNote = false,
                        eqId = "E128",
                        imageId = null,
                        familyName = "Wilson",
                        givenNames = "Liam",
                        birthDate = "2005-05-05T00:00:00Z",
                        age = "18",
                        rollClass = "12A",
                        yearLevel = new YearLevel
                        {
                            code = "12",
                            description = "Year 12"
                        },
                        enrolmentStatus = new EnrolmentStatus
                        {
                            code = "Enrolled",
                            description = "The student is enrolled"
                        },
                        gender = new Gender
                        {
                            code = "M",
                            description = "Male"
                        },
                        absences = new List<Absence>()
                    },
                    new Student
                    {
                        enrolmentId = 107,
                        attendanceStatus = new AttendanceStatus
                        {
                            code = "Absent",
                            description = "Student is absent"
                        },
                        hasAttendanceChanges = false,
                        hasAbsentNote = true,
                        eqId = "E129",
                        imageId = null,
                        familyName = "Clark",
                        givenNames = "Isabella",
                        birthDate = "2005-09-21T00:00:00Z",
                        age = "18",
                        rollClass = "12A",
                        yearLevel = new YearLevel
                        {
                            code = "12",
                            description = "Year 12"
                        },
                        enrolmentStatus = new EnrolmentStatus
                        {
                            code = "Enrolled",
                            description = "The student is enrolled"
                        },
                        gender = new Gender
                        {
                            code = "F",
                            description = "Female"
                        },
                        absences = new List<Absence>
                        {
                            new Absence 
                            {
                                studentAbsenceId = 203,
                                enrolmentId = 107,
                                absenceDate = "2023-09-15T00:00:00Z",
                                absenceReason = new AbsenceReason
                                {
                                    code = "Sick",
                                    description = "Student is sick"
                                },
                                partOfDayAbsence = new PartOfDayAbsence
                                {
                                    code = "FullDay",
                                    description = "Absent for the full day"
                                },
                                lateEarlyTime = null,
                                note = "Flu",
                                modifiedDate = "2023-09-16T12:00:00Z",
                                modifiedBy = "Admin"
                            }
                        }
                    }
                }
            },
        };

        return JsonSerializer.Serialize(responses, new JsonSerializerOptions{ WriteIndented = true });
    }
}

string json = Program.Main();