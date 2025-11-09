using System;
using System.Collections.Generic;
using System.Text.Json;

public class Program
{
    public static string Main()
    {
        var random = new Random();
        var sampleData = new List<object>();

        for (int i = 0; i < 5; i++)
        {
            int numStudents = random.Next(1, 11); // Random number of students between 1 and 10
            var students = new List<Student>();

            for (int j = 0; j < numStudents; j++)
            {
                students.Add(new Student
                {
                    enrolmentId = random.Next(1000, 9999),
                    eqId = "EQ" + random.Next(10000, 99999),
                    imageId = random.Next(1, 101),
                    familyName = random.Choose(new[] { "Smith", "Johnson", "Williams", "Jones", "Brown" }),
                    givenNames = random.Choose(new[] { "John", "Jane", "Alex", "Emily", "Chris" }),
                    birthDate = DateTime.Now.AddYears(-random.Next(10, 21)).ToString("o"), // ISO 8601 format, 10 to 20 years ago
                    age = (random.Next(10, 20)).ToString(),
                    rollClass = random.Choose(new[] { "10A", "10B", "11A", "11B", "12A" }),
                    yearLevel = new YearLevel
                    {
                        code = random.Next(10, 13).ToString(),
                        description = "Year " + random.Next(10, 13)
                    },
                    enrolmentStatus = new Status
                    {
                        code = "ENR",
                        description = "Enrolled"
                    },
                    gender = new Gender
                    {
                        code = random.Choose(new[] { "M", "F" }),
                        description = random.Choose(new[] { "Male", "Female" })
                    },
                    hasAbsentNote = random.NextDouble() > 0.5,
                    absences = new List<object>() // For simplicity, we won't generate absences
                });
            }

            sampleData.Add(new { students });
        }

        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        return JsonSerializer.Serialize(sampleData, jsonOptions);
    }
}

public static class RandomExtensions
{
    public static T Choose<T>(this Random random, T[] array)
    {
        return array[random.Next(array.Length)];
    }
}

string json = Program.Main();