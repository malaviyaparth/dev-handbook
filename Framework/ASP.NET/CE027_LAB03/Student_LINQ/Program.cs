namespace LINQLab
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Semester { get; set; }
        public int Age { get; set; }
        public double CGPA { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student {Id = 1, Name = "Parth", Department = "Computer", Semester = 5, Age = 20, CGPA = 8.96},
                new Student {Id = 2, Name = "Rishi", Department = "Computer", Semester = 5, Age = 19, CGPA = 9.02},
                new Student {Id = 3, Name = "Jeel", Department = "Computer", Semester = 3, Age = 18, CGPA = 8.52},
                new Student {Id = 4, Name = "Yash", Department = "Chemical", Semester = 3, Age = 17, CGPA = 7.36},
                new Student {Id = 5, Name = "Rutvik", Department = "Civil", Semester = 7, Age = 22, CGPA = 8.60}
            };

            var result1 = from student in students
                          where student.CGPA > 8.00
                          select student;

            Console.WriteLine("Names of students whose CGPA is greater than 8.0 : ");
            foreach (var item in result1)
            {
                Console.WriteLine(item.Name);
            }

            var result2 = from student in students
                          where student.Department == "Computer"
                          orderby student.CGPA descending
                          select student;

            Console.WriteLine("\nNames of students belonging to the Computer Engineering department, sorted by CGPA in descending order : ");
            foreach (var item in result2)
            {
                Console.WriteLine(item.Name + " " + item.CGPA);
            }

            var result3 = students
                         .OrderByDescending(s => s.CGPA)
                         .Take(3);

            Console.WriteLine("\nTop three students based on CGPA : ");
            foreach (var item in result3)
            {
                Console.WriteLine(item.Name + " " + item.CGPA);
            }

            var result4 = students
                         .GroupBy(s => s.Department)
                         .Select(s => new
                         {
                             Department = s.Key,
                             StudentCount = s.Count(),
                         });

            Console.WriteLine("\nThe number of students in each department : ");
            foreach (var item in result4)
            {
                Console.WriteLine(item.Department + " " + item.StudentCount);
            }

        }
    }
}
