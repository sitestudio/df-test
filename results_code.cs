using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

public class Program
{
    public static string Main()
    {
        var random = new Random();
        var compositeStudentInformationResponses = new List<CompositeStudentInformationResponse>();
        var studentsResponses = new List<StudentsResponse>();
        
        for (int i = 0; i < 50; i++)
        {
            var eqId = Guid.NewGuid().ToString();
            var studentList = new List<StudentInformationResponse>();
            var numberOfStudents = random.Next(5, 15); // Random count of students between 5 and 15.

            for (int j = 0; j < numberOfStudents; j++)
            {
                var birthDate = DateTime.Today.AddYears(-random.Next(15, 18)).AddDays(-random.Next(0, 365)).ToString("yyyy-MM-dd");
                var student = new StudentInformationResponse
                {
                    session = "Session" + i,
                    timetableClassId = random.Next(1, 100),
                    enrolmentId = j + 1,
                    attendanceStatus = new AttendanceStatus
                    {
                        code = "Present",
                        description = "Present"
                    },
                    hasAttendanceChanges = false,
                    hasAbsentNote = random.Next(0, 2) == 1,
                    eqId = eqId,
                    imageId = random.Next(1, 1000),
                    familyName = "FamilyName" + j,
                    givenNames = "GivenName" + j,
                    birthDate = birthDate,
                    age = (DateTime.Today.Year - DateTime.Parse(birthDate).Year).ToString(),
                    rollClass = "RollClass" + random.Next(1, 10),
                    yearLevel = new YearLevel
                    {
                        code = "Year" + (random.Next(11, 13)),
                        description = "Year " + (random.Next(11, 13)).ToString()
                    },
                    enrolmentStatus = new EnrolmentStatus
                    {
                        code = "Active",
                        description = "Active"
                    },
                    gender = new Gender
                    {
                        code = random.Next(0, 2) == 0 ? "M" : "F",
                        description = random.Next(0, 2) == 0 ? "Male" : "Female"
                    },
                    absences = new List<AbsenceRecord>()
                };
                
                // Adding random absences
                var numberOfAbsences = random.Next(0, 3);
                for (int k = 0; k < numberOfAbsences; k++)
                {
                    var absenceDate = DateTime.Today.AddDays(-random.Next(1, 30)).ToString("yyyy-MM-dd");
                    student.absences.Add(new AbsenceRecord
                    {
                        studentAbsenceId = k + 1,
                        enrolmentId = j + 1,
                        absenceDate = absenceDate,
                        absenceReason = new AbsenceReason
                        {
                            code = "Sick",
                            description = "Sick"
                        },
                        partOfDayAbsence = new PartOfDayAbsence
                        {
                            code = "Full",
                            description = "Full Day"
                        },
                        note = "No notes",
                        modifiedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        modifiedBy = "Admin"
                    });
                }
                
                studentList.Add(student);
            }

            compositeStudentInformationResponses.Add(new CompositeStudentInformationResponse
            {
                session = "Session" + i,
                isRollMarkable = true,
                notRollMarkableReason = null,
                isRollMarked = false,
                rollMarkedDate = null,
                rollMarkedUser = null,
                timetableClassIds = "TimetableClassIds" + i,
                classes = new List<ClassAttendanceResponse>(),
                students = studentList
            });

            studentsResponses.Add(new StudentsResponse
            {
                students = studentList.Select(st => new StudentResponse
                {
                    enrolmentId = st.enrolmentId,
                    eqId = eqId,
                    imageId = st.imageId,
                    familyName = st.familyName,
                    givenNames = st.givenNames,
                    birthDate = st.birthDate,
                    age = st.age,
                    rollClass = st.rollClass,
                    yearLevel = st.yearLevel,
                    enrolmentStatus = st.enrolmentStatus,
                    gender = st.gender,
                    hasAbsentNote = st.hasAbsentNote,
                    absences = st.absences
                }).ToList()
            });
        }

        return JsonSerializer.Serialize(new { compositeStudentInformationResponses, studentsResponses }, new JsonSerializerOptions { WriteIndented = true });
    }
}

public class CompositeStudentInformationResponse
{
    public string session { get; set; }
    public bool isRollMarkable { get; set; }
    public object notRollMarkableReason { get; set; }
    public bool isRollMarked { get; set; }
    public string rollMarkedDate { get; set; }
    public string rollMarkedUser { get; set; }
    public string timetableClassIds { get; set; }
    public List<ClassAttendanceResponse> classes { get; set; }
    public List<StudentInformationResponse> students { get; set; }
}

public class StudentInformationResponse
{
    public string session { get; set; }
    public int timetableClassId { get; set; }
    public int enrolmentId { get; set; }
    public AttendanceStatus attendanceStatus { get; set; }
    public bool hasAttendanceChanges { get; set; }
    public bool hasAbsentNote { get; set; }
    public string eqId { get; set; }
    public int? imageId { get; set; }
    public string familyName { get; set; }
    public string givenNames { get; set; }
    public string birthDate { get; set; }
    public string age { get; set; }
    public string rollClass { get; set; }
    public YearLevel yearLevel { get; set; }
    public EnrolmentStatus enrolmentStatus { get; set; }
    public Gender gender { get; set; }
    public List<AbsenceRecord> absences { get; set; }
}

public class AttendanceStatus
{
    public string code { get; set; }
    public string description { get; set; }
}

public class YearLevel
{
    public string code { get; set; }
    public string description { get; set; }
}

public class EnrolmentStatus
{
    public string code { get; set; }
    public string description { get; set; }
}

public class Gender
{
    public string code { get; set; }
    public string description { get; set; }
}

public class AbsenceRecord
{
    public int studentAbsenceId { get; set; }
    public int enrolmentId { get; set; }
    public string absenceDate { get; set; }
    public AbsenceReason absenceReason { get; set; }
    public PartOfDayAbsence partOfDayAbsence { get; set; }
    public string note { get; set; }
    public string modifiedDate { get; set; }
    public string modifiedBy { get; set; }
}

public class AbsenceReason
{
    public string code { get; set; }
    public string description { get; set; }
}

public class PartOfDayAbsence
{
    public string code { get; set; }
    public string description { get; set; }
}

public class StudentsResponse
{
    public List<StudentResponse> students { get; set; }
}

public class StudentResponse
{
    public int enrolmentId { get; set; }
    public string eqId { get; set; }
    public int? imageId { get; set; }
    public string familyName { get; set; }
    public string givenNames { get; set; }
    public string birthDate { get; set; }
    public string age { get; set; }
    public string rollClass { get; set; }
    public YearLevel yearLevel { get; set; }
    public EnrolmentStatus enrolmentStatus { get; set; }
    public Gender gender { get; set; }
    public bool hasAbsentNote { get; set; }
    public List<AbsenceRecord> absences { get; set; }
}

string json = Program.Main();