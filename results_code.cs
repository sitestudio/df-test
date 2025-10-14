using System;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static string Main()
    {
        var random = new Random();
        var studentInformationResponses = new List<StudentInformationResponse>();
        
        // Generate 5 sample data records with varying number of students
        for (int i = 0; i < 5; i++)
        {
            var numberOfStudents = random.Next(1, 11); // Random number between 1 and 10
            var students = new List<Student>();
            
            for (int j = 0; j < numberOfStudents; j++)
            {
                students.Add(new Student
                {
                    enrolmentId = random.Next(1000, 9999),
                    eqId = Guid.NewGuid().ToString(),
                    imageId = random.Next(1, 100),
                    familyName = $"FamilyName{j}",
                    givenNames = $"GivenName{j}",
                    birthDate = DateTime.Now.AddYears(-random.Next(6, 18)).ToString("yyyy-MM-dd"),
                    age = (DateTime.Now.Year - DateTime.Now.AddYears(-random.Next(6, 18)).Year).ToString(),
                    rollClass = $"RollClass{random.Next(1, 5)}",
                    yearLevel = new YearLevel
                    {
                        code = $"YL{random.Next(1, 13)}",
                        description = $"Year Level {random.Next(1, 13)}"
                    },
                    enrolmentStatus = new EnrolmentStatus
                    {
                        code = $"ES{random.Next(1, 4)}",
                        description = "Enrolment Status " + random.Next(1, 4)
                    },
                    gender = new Gender
                    {
                        code = random.Next(0, 2) == 0 ? "M" : "F",
                        description = random.Next(0, 2) == 0 ? "Male" : "Female"
                    },
                    hasAbsentNote = random.Next(0, 2) == 0,
                    absences = new List<object>() // Empty list for absences
                });
            }
            
            studentInformationResponses.Add(new StudentInformationResponse { students = students });
        }

        // Serialize to JSON with pretty print
        var options = new JsonSerializerOptions { WriteIndented = true };
        return JsonSerializer.Serialize(studentInformationResponses, options);
    }
}

string json = Program.Main();