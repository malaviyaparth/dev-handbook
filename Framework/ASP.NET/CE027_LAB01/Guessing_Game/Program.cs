Console.WriteLine("Hello, Welcome to number guessing Game!");

int key = 567, choice = 0;
Console.Write("Guess a number : ");

do
{
    choice = int.Parse(Console.ReadLine());
    if (choice < key)
    {
        Console.WriteLine(choice + " is less than secret number");
        Console.Write("Guess a number : ");
    }
    else if (choice > key)
    {
        Console.WriteLine(choice + " is greater than secret number");
        Console.Write("Guess a number : ");
    }
    else
    {
        Console.WriteLine("Congratulations! You got it right.");
    }
} while (key != choice);
