using System;

abstract class Shape
{
    public abstract double CalculateArea();
}

class Circle : Shape
{
    public double Radius { get; set; }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

class Rectangle : Shape
{
    public double Length { get; set; }
    public double Width { get; set; }

    public override double CalculateArea()
    {
        return Length * Width;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter Radius of Circle: ");
        double r = Convert.ToDouble(Console.ReadLine());

        Circle c = new Circle();
        c.Radius = r;

        Console.WriteLine("Area of Circle = " + c.CalculateArea());
        Console.WriteLine();

        Console.Write("Enter Length of Rectangle: ");
        double l = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter Width of Rectangle: ");
        double w = Convert.ToDouble(Console.ReadLine());

        Rectangle rect = new Rectangle();
        rect.Length = l;
        rect.Width = w;

        Console.WriteLine("Area of Rectangle = " + rect.CalculateArea());
    }
}