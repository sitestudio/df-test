using System;
using System.Collections.Generic;
using System.Linq;

public class Absence
{
    public int StudentAbsenceId { get; set; }
    public int EnrolmentId { get; set; }
    public DateTime AbsenceDate { get; set; }
    public AbsenceReason AbsenceReason { get; set; }
    public PartOfDayAbsence PartOfDayAbsence { get; set; }
    public string Note { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
}

public class AbsenceReason
{
    public string Code { get; set; }
    public string Description { get; set; }
}

public class PartOfDayAbsence
{
    public string Code { get; set; }
    public string Description { get; set; }
}

public class Student
{
    public int EnrolmentId { get; set; }
    public string EqId { get; set; }
    public int? ImageId { get; set; }
    public string FamilyName { get; set; }
    public string GivenNames { get; set; }
    public DateTime BirthDate { get; set; }
    public string Age { get; set; }
    public string RollClass { get; set; }
    public YearLevel YearLevel { get; set; }
    public EnrolmentStatus EnrolmentStatus { get; set; }
    public Gender Gender { get; set; }
    public bool HasAbsentNote { get; set; }
    public List<Absence> Absences { get; set; }
}

public class YearLevel
{
    public string Code { get; set; }
    public string Description { get; set; }
}

public class EnrolmentStatus
{
    public string Code { get; set; }
    public string Description { get; set; }
}

public class Gender
{
    public string Code { get; set; }
    public string Description { get; set; }
}

public class StudentSchedulesResponse
{
    public List<Student> Students { get; set; }
}

public class Program
{
    public static void Main()
    {
        var response = new StudentSchedulesResponse
        {
            Students = GenerateSampleStudents(100)
        };

        // Example code to display the generated students
        foreach (var student in response.Students)
        {
            Console.WriteLine($"ID: {student.EnrolmentId}, Name: {student.GivenNames} {student.FamilyName}");
        }
    }

    private static List<Student> GenerateSampleStudents(int count)
    {
        var random = new Random();
        var students = new List<Student>();
        
        for (int i = 0; i < count; i++)
        {
            students.Add(new Student
            {
                EnrolmentId = i + 1,
                EqId = Guid.NewGuid().ToString(),
                ImageId = (i % 10 == 0) ? (int?)null : random.Next(1, 100), // some have null ImageId
                FamilyName = "Family" + i,
                GivenNames = "Given" + i,
                BirthDate = DateTime.Now.AddYears(-random.Next(5, 18)), // random age between 5 and 17 years
                Age = (DateTime.Now.Year - (DateTime.Now.AddYears(-random.Next(5, 18)).Year)).ToString(),
                RollClass = "Class" + (i % 5), // Randomly assigned to 5 classes
                YearLevel = new YearLevel { Code = "Year" + (i % 12), Description = "Year " + (i % 12) + " Description" },
                EnrolmentStatus = new EnrolmentStatus { Code = "Active", Description = "Active Status" },
                Gender = new Gender { Code = (i % 2 == 0) ? "M" : "F", Description = (i % 2 == 0) ? "Male" : "Female" },
                HasAbsentNote = random.Next(0, 2) == 1,
                Absences = GenerateSampleAbsences(random.Next(0, 4)) // Randomly assign between 0 to 3 absences
            });
        }
        
        return students;
    }

    private static List<Absence> GenerateSampleAbsences(int count)
    {
        var random = new Random();
        var absences = new List<Absence>();
        
        for (int i = 0; i < count; i++)
        {
            absences.Add(new Absence
            {
                StudentAbsenceId = i + 1,
                EnrolmentId = random.Next(1, 100), // sample enrolment ID
                AbsenceDate = DateTime.Now.AddDays(-random.Next(1, 30)), // Absences from the last 30 days
                AbsenceReason = new AbsenceReason { Code = "Sick", Description = "Sick Leave" },
                PartOfDayAbsence = new PartOfDayAbsence { Code = "Full", Description = "Full Day" },
                Note = "Sample note for absence.",
                ModifiedDate = DateTime.Now,
                ModifiedBy = "Admin"
            });
        }

        return absences;
    }
}