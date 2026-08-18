namespace Calulator
{
    class Program
    {

        delegate double Calculate(double a, double b);

        static double Add(double a, double b) { return a + b; }
        static double Subtract(double a, double b) { return a - b; }
        static double Multiply(double a, double b) { return a * b; }
        static double Divide(double a, double b) { return a / b; }

        static void Main(string[] args)
        {
            Console.Write("Enter 1st number : ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter 2nd number : ");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine("Select Operation to Calculate : ");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.Write("Enter your choice : ");
            int c = int.Parse(Console.ReadLine());
            while (c > 4 || c < 1)
            {
                Console.WriteLine("Invalid choice. Select again : ");
                c = int.Parse(Console.ReadLine());
            }

            Calculate Cal = c switch
            {
                1 => Add,
                2 => Subtract,
                3 => Multiply,
                4 => Divide,
            };

            Console.WriteLine("Result : " + Cal(a, b));
        }
    }
}
