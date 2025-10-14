using System;
using System.Collections.Generic;
using System.Text.Json;

class Program
{
    public static string Main()
    {
        var random = new Random();

        // Function to generate a random date for a student who is no more than 18 years old
        string GenerateBirthDate()
        {
            var today = DateTime.Now;
            var latestBirthDate = today.AddYears(-18);
            var randomDays = random.Next(0, 18 * 365);
            var birthDate = latestBirthDate.AddDays(-randomDays);
            return birthDate.ToString("yyyy-MM-dd");
        }

        // Function to generate random student records
        List<Student> GenerateStudentsResponse(int numStudents)
        {
            var students = new List<Student>();
            for (int i = 0; i < numStudents; i++)
            {
                var student = new Student
                {
                    EnrolmentId = random.Next(1000, 9999),
                    EqId = $"EQ{random.Next(1000, 9999)}",
                    ImageId = random.Next(1, 11),
                    FamilyName = new[] { "Smith", "Johnson", "Williams", "Jones", "Brown" }[random.Next(5)],
                    GivenNames = new[] { "John", "James", "Robert", "Michael", "William" }[random.Next(5)],
                    BirthDate = GenerateBirthDate(),
                    Age = (2023 - DateTime.Parse(GenerateBirthDate()).Year).ToString(),
                    RollClass = new[] { "12A", "12B", "12C" }[random.Next(3)],
                    YearLevel = new YearLevel { Code = "12", Description = "Year 12" },
                    EnrolmentStatus = new EnrolmentStatus { Code = "ENROLLED", Description = "Enrolled in Course" },
                    Gender = new Gender { Code = new[] { "M", "F" }[random.Next(2)], Description = new[] { "Male", "Female" }[random.Next(2)] },
                    HasAbsentNote = random.Next(2) == 0,
                    Absences = new List<Absence>()
                };
                students.Add(student);
            }
            return students;
        }

        // Function to generate CompositeStudentInformationResponse
        CompositeStudentInformationResponse GenerateCompositeStudentResponse(List<Student> students)
        {
            return new CompositeStudentInformationResponse
            {
                Session = "2023-2024",
                IsRollMarkable = true,
                NotRollMarkableReason = null,
                IsRollMarked = false,
                RollMarkedDate = null,
                RollMarkedUser = null,
                TimetableClassIds = "TC001, TC002",
                Classes = new List<ClassAttendance>(),
                Students = students
            };
        }

        // Generate random data
        int numStudentsResponse1 = random.Next(10, 31); // Random number for CompositeStudentInformationResponse
        int numStudentsResponse2 = random.Next(30, 51); // Random number for StudentsResponse
        var studentsResponse1 = GenerateStudentsResponse(numStudentsResponse1);
        var studentsResponse2 = GenerateStudentsResponse(numStudentsResponse2);

        // Ensure eqId matches between two responses
        var eqIdMapping = new Dictionary<string, Student>();
        foreach (var student in studentsResponse1)
        {
            eqIdMapping[student.EqId] = student;
        }

        foreach (var student in studentsResponse2)
        {
            if (!eqIdMapping.ContainsKey(student.EqId))
            {
                student.EqId = random.Shuffle(eqIdMapping.Keys).First();
            }
        }

        // Serializing the final JSON strings
        var compositeResponseJson = JsonSerializer.Serialize(GenerateCompositeStudentResponse(studentsResponse1), new JsonSerializerOptions { WriteIndented = true });
        var studentsResponseJson = JsonSerializer.Serialize(new { students = studentsResponse2 }, new JsonSerializerOptions { WriteIndented = true });

        return compositeResponseJson + "
" + studentsResponseJson;
    }
}

string json = Program.Main();