using System;
using System.Collections.Generic;
using System.Text.Json;

public class StudentInformationResponse
{
    public List<StudentGroup> Students { get; set; }
}

public class StudentGroup
{
    public List<Student> Students { get; set; }
}

public class Student
{
    public int EnrolmentId { get; set; }
    public string EqId { get; set; }
    public int ImageId { get; set; }
    public string FamilyName { get; set; }
    public string GivenNames { get; set; }
    public DateTime BirthDate { get; set; }
    public string Age { get; set; }
    public string RollClass { get; set; }
    public YearLevel YearLevel { get; set; }
    public EnrolmentStatus EnrolmentStatus { get; set; }
    public Gender Gender { get; set; }
    public bool HasAbsentNote { get; set; }
    public List<object> Absences { get; set; }
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

public class Program
{
    public static string Main()
    {
        string jsonData = System.IO.File.ReadAllText("path_to_your_json_file.json");
        
        try
        {
            var studentGroups = JsonSerializer.Deserialize<List<StudentGroup>>(jsonData);
            
            foreach (var studentGroup in studentGroups)
            {
                foreach (var student in studentGroup.Students)
                {
                    // Validate eqId
                    if (!Guid.TryParse(student.EqId, out Guid _))
                    {
                        return $"Failed: Invalid Guid for eqId: {student.EqId}";
                    }

                    // Validate familyName
                    if (!student.FamilyName.StartsWith("Family"))
                    {
                        return $"Failed: Family name does not start with 'Family': {student.FamilyName}";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return $"Failed: Exception occurred - {ex.Message}";
        }

        return "Success";
    }
}

string json = Program.Main();