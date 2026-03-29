using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SampleDataGenerator
{
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

    public class StudentSchedulesResponse
    {
        public List<Student> Students { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();
            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                var student = new Student
                {
                    EnrolmentId = random.Next(1000, 9999),
                    EqId = GenerateRandomString(8),
                    ImageId = random.Next(1, 100) > 50 ? (int?)null : random.Next(1, 100),
                    FamilyName = GenerateRandomString(random.Next(3, 10)),
                    GivenNames = GenerateRandomString(random.Next(3, 10)),
                    BirthDate = DateTime.Now.AddYears(-random.Next(10, 20)),
                    Age = random.Next(10, 20).ToString(),
                    RollClass = GenerateRandomString(random.Next(3, 10)),
                    YearLevel = new YearLevel
                    {
                        Code = GenerateRandomString(2),
                        Description = GenerateRandomString(10)
                    },
                    EnrolmentStatus = new EnrolmentStatus
                    {
                        Code = GenerateRandomString(2),
                        Description = GenerateRandomString(10)
                    },
                    Gender = new Gender
                    {
                        Code = random.Next(0, 2) == 0 ? "M" : "F",
                        Description = random.Next(0, 2) == 0 ? "Male" : "Female"
                    },
                    HasAbsentNote = random.Next(0, 2) == 0,
                    Absences = new List<Absence>()
                };

                students.Add(student);
            }

            var response = new StudentSchedulesResponse { Students = students };
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }
            return new string(result).ToLower();
        }
    }
}