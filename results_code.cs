using System;
using System.Collections.Generic;
using System.Text.Json;

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

public class Absence
{
    public int StudentAbsenceId { get; set; }
    public int EnrolmentId { get; set; }
    public string AbsenceDate { get; set; }
    public AbsenceReason AbsenceReason { get; set; }
    public PartOfDayAbsence PartOfDayAbsence { get; set; }
    public string LateEarlyTime { get; set; }
    public string Note { get; set; }
    public string ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
}

public class Gender
{
    public string Code { get; set; }
    public string Description { get; set; }
}

public class EnrollmentStatus
{
    public string Code { get; set; }
    public string Description { get; set; }
}

public class YearLevel
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
    public string BirthDate { get; set; }
    public string Age { get; set; }
    public string RollClass { get; set; }
    public YearLevel YearLevel { get; set; }
    public EnrollmentStatus EnrolmentStatus { get; set; }
    public Gender Gender { get; set; }
    public bool HasAbsentNote { get; set; }
    public List<Absence> Absences { get; set; }
}
  
public class StudentSchedulesResponse
{
    public List<Student> Students { get; set; }
}

public static StudentSchedulesResponse GenerateSampleData()
{
    var response = new StudentSchedulesResponse { Students = new List<Student>() };

    Random random = new Random();
    for (int i = 0; i < 100; i++)
    {
        var student = new Student
        {
            EnrolmentId = i + 1,
            EqId = Guid.NewGuid().ToString(),
            ImageId = random.Next(1, 100),
            FamilyName = "Family" + i,
            GivenNames = "Given" + i,
            BirthDate = DateTime.Now.AddYears(-random.Next(5, 18)).ToString("o"),
            Age = (random.Next(5, 18)).ToString(),
            RollClass = "Class" + random.Next(1, 10),
            YearLevel = new YearLevel
            {
                Code = "Y" + random.Next(1, 13),
                Description = "Year " + random.Next(1, 13)
            },
            EnrolmentStatus = new EnrollmentStatus
            {
                Code = random.Next(0, 2) == 0 ? "Active" : "Inactive",
                Description = "Status " + random.Next(1, 4)
            },
            Gender = new Gender
            {
                Code = random.Next(0, 2) == 0 ? "M" : "F",
                Description = random.Next(0, 2) == 0 ? "Male" : "Female"
            },
            HasAbsentNote = random.Next(0, 2) == 0,
            Absences = new List<Absence>()
        };

        // Adding some example absences for this student
        for (int j = 0; j < random.Next(0, 5); j++)
        {
            student.Absences.Add(new Absence
            {
                StudentAbsenceId = random.Next(1, 1000),
                EnrolmentId = student.EnrolmentId,
                AbsenceDate = DateTime.Now.AddDays(-random.Next(1, 30)).ToString("o"),
                AbsenceReason = new AbsenceReason
                {
                    Code = "Reason" + random.Next(1, 5),
                    Description = "Reason description " + random.Next(1, 5)
                },
                PartOfDayAbsence = new PartOfDayAbsence
                {
                    Code = "FullDay",
                    Description = "Full Day"
                },
                LateEarlyTime = random.Next(0, 2) == 0 ? null : "10:00 AM",
                Note = "Note " + random.Next(1, 10),
                ModifiedDate = DateTime.Now.ToString("o"),
                ModifiedBy = "User" + random.Next(1, 10)
            });
        }

        response.Students.Add(student);
    }

    return response;
}

public static void Main()
{
    var json = JsonSerializer.Serialize(GenerateSampleData());
    Console.WriteLine(json);
    return json;
}

json = Main();