Console.WriteLine("Welcome to Calculator!");
int choice = 0;

while (choice != 6)
{
    Console.WriteLine("\nSelect one : ");
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");
    Console.WriteLine("5. Modulus");
    Console.WriteLine("6. Exit\n");

    Console.Write("Enter your choice : ");
    choice = int.Parse(Console.ReadLine());

    if (choice == 6)
    {
        break;
    }
    if (choice <= 0 || choice >= 7)
    {
        Console.WriteLine("Incorrect choice please select between (1 to 6)");
        continue;
    }

    Console.Write("Enter 1st number : ");
    int a = int.Parse(Console.ReadLine());
    Console.Write("Enter 2nd number : ");
    int b = int.Parse(Console.ReadLine());

    int ans = choice switch
    {
        1 => ans = a + b,
        2 => ans = a - b,
        3 => ans = a * b,
        4 => ans = a / b,
        5 => ans = a % b
    };

    Console.WriteLine($"Result : {ans}");
}
