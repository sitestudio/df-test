using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RandomNameGenerator;
using System.Linq;

class Program
{
    public class StudentPersonalDetailResponse
    {
        public string LocalId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ParentLocalId { get; set; }
        public bool IsEnrolled { get; set; }
    }

    public class ParentPersonalsForStudentResponse
    {
        public string LocalId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Relationship { get; set; }
        public bool IsGuardian { get; set; }
    }

    static void Main()
    {
        var rng = new Random();
        int studentCount = rng.Next(5, 11);
        int parentCount = studentCount;

        var parents = new List<ParentPersonalsForStudentResponse>();
        var students = new List<StudentPersonalDetailResponse>();
        
        // Generate Parent records
        for (int i = 0; i < parentCount; i++)
        {
            string localId = Guid.NewGuid().ToString();
            string fullName = NameGenerator.GenerateFullName();
            DateTime birthDate = DateTime.Now.AddYears(-(rng.Next(18, 60))); // Parent must be older.
            
            parents.Add(new ParentPersonalsForStudentResponse
            {
                LocalId = localId,
                FullName = fullName,
                BirthDate = birthDate,
                Relationship = "Parent",
                IsGuardian = rng.Next(0, 2) == 1
            });
        }

        // Generate Student records
        for (int i = 0; i < studentCount; i++)
        {
            string localId = Guid.NewGuid().ToString();
            string fullName = NameGenerator.GenerateFullName();
            DateTime birthDate = DateTime.Now.AddYears(-(rng.Next(5, 19))); // Student must be between 5 and 18 years old.
            var parent = parents[rng.Next(parentCount)]; // Randomly assign a parent.
            
            students.Add(new StudentPersonalDetailResponse
            {
                LocalId = localId,
                FullName = fullName,
                BirthDate = birthDate,
                ParentLocalId = parent.LocalId,
                IsEnrolled = rng.Next(0, 2) == 1
            });
        }

        var combinedResults = new {
            STUDENTPERSONALDETAILRESPONSE = students,
            PARENTPERSONALSFORSTUDENTRESPONSE = parents
        };

        string json = JsonConvert.SerializeObject(combinedResults, Formatting.Indented);
        Console.WriteLine(json);
    }
}