using System;
using System.Threading.Tasks;

class Program
{
    static async Task<string> Addition(double x, double y)
    {
        Console.WriteLine("Start Addition : ");
        await Task.Delay(2000);
        Console.WriteLine("End Addition : ");
        return "Addition : " + (x + y).ToString();
    }
    static async Task<string> Subraction(double x, double y)
    {
        Console.WriteLine("Start Subraction : ");
        await Task.Delay(2000);
        Console.WriteLine("End Subraction : ");
        return "Subtraction : " + (x - y).ToString();
    }
    static async Task<string> Multiplication(double x, double y)
    {
        Console.WriteLine("Start Multiplication : ");
        await Task.Delay(2000);
        Console.WriteLine("End Multiplication : ");
        return "Multiplication : " + (x * y).ToString();
    }
    static async Task<string> Division(double x, double y)
    {
        Console.WriteLine("Start Division : ");
        await Task.Delay(2000);
        Console.WriteLine("End Division : ");
        return "Division : " + (x / y).ToString();
    }

    static async Task Main()
    {
        Console.WriteLine("Calculator : Start");

        Task<string> t1 = Addition(1, 2);
        Task<string> t2 = Subraction(1, 2);
        Task<string> t3 = Multiplication(1, 2);
        Task<string> t4 = Division(1, 2);

        string[] results = await Task.WhenAll(t1, t2, t3, t4);

        foreach (var item in results)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Calculator : End");
    }
}