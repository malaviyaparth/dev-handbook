using System;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public virtual void DisplayInfo()
    {
        Console.WriteLine("Name : " + Name);
        Console.WriteLine("Age  : " + Age);
    }
}

class Teacher : Person
{
    public string Subject { get; set; }
    public double Salary { get; set; }

    public override void DisplayInfo()
    {
        Console.WriteLine("Teacher Information");
        Console.WriteLine("Name    : " + Name);
        Console.WriteLine("Age     : " + Age);
        Console.WriteLine("Subject : " + Subject);
        Console.WriteLine("Salary  : " + Salary);
    }
}

class Program
{
    static void Main()
    {
        Teacher t = new Teacher { Name = "Amit", Age = 40, Subject = "C# Programming", Salary = 55000 };
        t.DisplayInfo();
    }
}