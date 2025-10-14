using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

public class Program
{
    public class StudentsResponse
    {
        public List<Student> students { get; set; }
    }

    public class Student
    {
        public int enrolmentId { get; set; }
        public string eqId { get; set; }
        public string familyName { get; set; }
        public string givenNames { get; set; }
        public DateTime birthDate { get; set; }
        // Additional properties omitted for brevity
    }

    public static string Main()
    {
        string filePath = "results_response.json";
        if (!File.Exists(filePath))
        {
            return $"Failed: File '{filePath}' not found.";
        }

        string jsonString = File.ReadAllText(filePath);
        
        StudentsResponse response;

        try
        {
            response = JsonSerializer.Deserialize<StudentsResponse>(jsonString);
        }
        catch (JsonException ex)
        {
            return $"Failed: JSON deserialization error - {ex.Message}";
        }

        if (response.students == null || !response.students.Any())
        {
            return $"Failed: No student records found.";
        }

        foreach (var student in response.students)
        {
            if (!Guid.TryParse(student.eqId, out _))
            {
                return $"Failed: Student with enrolmentId {student.enrolmentId} has an invalid eqId '{student.eqId}'.";
            }

            if (!student.familyName.StartsWith("Family", StringComparison.OrdinalIgnoreCase))
            {
                return $"Failed: Student with enrolmentId {student.enrolmentId} has a familyName '{student.familyName}' that does not start with 'Family'.";
            }
        }
        
        return "Success";
    }
}

string json = Program.Main();