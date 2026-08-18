using System;

class Student
{
    private string name;
    private int rollNumber;
    private string course;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int RollNumber
    {
        get { return rollNumber; }
        set
        {
            if (value > 0) rollNumber = value;
            else Console.WriteLine("Roll Number must be positive.");
        }
    }
    public string Course
    {
        get { return course; }
        set { course = value; }
    }

    public void DisplayDetails()
    {
        Console.WriteLine("\nStudent Details");
        Console.WriteLine("Name       : " + Name);
        Console.WriteLine("Roll Number: " + RollNumber);
        Console.WriteLine("Course     : " + Course);
    }
}

class Program
{
    static void Main()
    {
        Student s = new Student();

        s.Name = "Parth";
        s.RollNumber = -5;
        s.RollNumber = 027;
        s.Course = "Computer Engineering";

        s.DisplayDetails();
    }
}