using System;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static string Main()
    {
        var random = new Random();
        var compositeStudents = new List<CompositeStudentInformationResponse>();
        var students = new List<StudentsResponse>();

        // Generate 50 composite student entries
        for (int i = 0; i < 50; i++)
        {
            var eqId = Guid.NewGuid().ToString();
            var compositeStudent = new CompositeStudentInformationResponse
            {
                session = $"Session_{i + 1}",
                isRollMarkable = random.Next(0, 2) == 1,
                notRollMarkableReason = null,
                isRollMarked = random.Next(0, 2) == 1,
                rollMarkedDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                rollMarkedUser = $"User_{random.Next(1, 100)}",
                timetableClassIds = $"Class_{random.Next(1, 10)}",
                students = new List<StudentResponse>
                {
                    new StudentResponse
                    {
                        eqId = eqId,
                        familyName = $"FamilyName_{i}",
                        givenNames = $"GivenNames_{random.Next(1, 100)}",
                        birthDate = DateTime.Now.AddYears(-random.Next(17, 18)).ToString("yyyy-MM-dd"),
                        age = (DateTime.Now.Year - DateTime.Now.AddYears(-random.Next(17, 18)).Year).ToString(),
                        rollClass = $"Class_{random.Next(1, 10)}",
                        yearLevel = new YearLevel { code = "12", description = "Year 12" },
                        enrolmentStatus = new Status { code = "active", description = "Active" },
                        gender = new Gender { code = random.Next(0, 2) == 0 ? "M" : "F", description = random.Next(0, 2) == 0 ? "Male" : "Female" },
                        hasAbsentNote = random.Next(0, 2) == 1,
                        absences = GenerateAbsences(random.Next(0, 5), eqId)
                    }
                }
            };
            compositeStudents.Add(compositeStudent);
        }

        // Generate student responses based on the composite records
        foreach (var composite in compositeStudents)
        {
            var studentResponse = new StudentsResponse
            {
                students = new List<Student>
                {
                    new Student
                    {
                        enrolmentId = random.Next(1, 1000),
                        eqId = composite.students[0].eqId,
                        imageId = random.Next(1, 1000),
                        familyName = composite.students[0].familyName,
                        givenNames = composite.students[0].givenNames,
                        birthDate = composite.students[0].birthDate,
                        age = composite.students[0].age,
                        rollClass = composite.students[0].rollClass,
                        yearLevel = new YearLevel { code = composite.students[0].yearLevel.code, description = composite.students[0].yearLevel.description },
                        enrolmentStatus = new Status { code = composite.students[0].enrolmentStatus.code, description = composite.students[0].enrolmentStatus.description },
                        gender = new Gender { code = composite.students[0].gender.code, description = composite.students[0].gender.description },
                        hasAbsentNote = composite.students[0].hasAbsentNote,
                        absences = composite.students[0].absences
                    }
                }
            };
            students.Add(studentResponse);
        }

        var jsonComposite = JsonSerializer.Serialize(compositeStudents, new JsonSerializerOptions { WriteIndented = true });
        var jsonStudents = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });

        return jsonComposite + "

" + jsonStudents;
    }

    private static List<Absence> GenerateAbsences(int count, string eqId)
    {
        var random = new Random();
        var absences = new List<Absence>();

        for (var j = 0; j < count; j++)
        {
            absences.Add(new Absence
            {
                studentAbsenceId = random.Next(1, 1000),
                enrolmentId = random.Next(1, 1000),
                absenceDate = DateTime.Now.ToString("yyyy-MM-dd"),
                absenceReason = new Reason { code = "SICK", description = "Sick" },
                partOfDayAbsence = new PartOfDay { code = "FULLDAY", description = "Full Day" },
                note = "Note for absence",
                modifiedDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                modifiedBy = $"User_{random.Next(1, 100)}"
            });
        }

        return absences;
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
        public List<StudentResponse> students { get; set; }
    }

    public class StudentResponse
    {
        public string eqId { get; set; }
        public string familyName { get; set; }
        public string givenNames { get; set; }
        public string birthDate { get; set; }
        public string age { get; set; }
        public string rollClass { get; set; }
        public YearLevel yearLevel { get; set; }
        public Status enrolmentStatus { get; set; }
        public Gender gender { get; set; }
        public bool hasAbsentNote { get; set; }
        public List<Absence> absences { get; set; }
    }

    public class YearLevel
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    public class Status
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    public class Gender
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    public class Absence
    {
        public int studentAbsenceId { get; set; }
        public int enrolmentId { get; set; }
        public string absenceDate { get; set; }
        public Reason absenceReason { get; set; }
        public PartOfDay partOfDayAbsence { get; set; }
        public string note { get; set; }
        public string modifiedDate { get; set; }
        public string modifiedBy { get; set; }
    }
    
    public class Reason
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    public class PartOfDay
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    public class StudentsResponse
    {
        public List<Student> students { get; set; }
    }

    public class Student
    {
        public int enrolmentId { get; set; }
        public string eqId { get; set; }
        public int imageId { get; set; }
        public string familyName { get; set; }
        public string givenNames { get; set; }
        public string birthDate { get; set; }
        public string age { get; set; }
        public string rollClass { get; set; }
        public YearLevel yearLevel { get; set; }
        public Status enrolmentStatus { get; set; }
        public Gender gender { get; set; }
        public bool hasAbsentNote { get; set; }
        public List<Absence> absences { get; set; }
    }
}

string json = Program.Main();