using System;

class Student
{
    public string Name;
    public int RollNumber;
    public string Course;

    public void DisplayDetails()
    {
        Console.WriteLine("Student Details");
        Console.WriteLine("Name       : " + Name);
        Console.WriteLine("Roll Number: " + RollNumber);
        Console.WriteLine("Course     : " + Course);
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Student s1 = new Student {Name = "Parth", RollNumber = 027, Course = "Computer Engineering"};

        Student s2 = new Student();
        s2.Name = "Rahul";
        s2.RollNumber = 102;
        s2.Course = "Information Technology";

        s1.DisplayDetails();
        s2.DisplayDetails();
    }
}