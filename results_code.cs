using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Program
{
    public class StudentInformationResponse
    {
        public List<Student> students { get; set; }
    }

    public class Student
    {
        public string eqId { get; set; }
        public string familyName { get; set; }
    }

    public static async Task<string> Main()
    {
        try
        {
            string json = await System.IO.File.ReadAllTextAsync("results_response.json"); // replace with actual file path
            var response = JsonSerializer.Deserialize<List<StudentInformationResponse>>(json);

            if (response == null)
            {
                return "Failed: Unable to deserialize JSON.";
            }

            foreach (var studentInfo in response)
            {
                foreach (var student in studentInfo.students)
                {
                    // Validate GUID format for eqId
                    if (!Guid.TryParse(student.eqId, out _))
                    {
                        return $"Failed: eqId '{student.eqId}' is not a valid GUID.";
                    }

                    // Validate familyName starts with "Family"
                    if (!student.familyName.StartsWith("Family", StringComparison.OrdinalIgnoreCase))
                    {
                        return $"Failed: familyName '{student.familyName}' does not start with 'Family'.";
                    }
                }
            }

            return "Success";
        }
        catch (Exception ex)
        {
            return $"Failed: {ex.Message}";
        }
    }
}

string json = Program.Main();